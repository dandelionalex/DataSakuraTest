using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zoo.Config;
using Zoo.Signals;

namespace Zoo
{
    public sealed class AnimalSpawner : MonoBehaviour
    {
        [Inject] private GameConfig _gameConfig;
        [Inject] private AnimalFactory _amimalFactory;
        [Inject] private SignalBus _signalBus;

        List<IAnimalPresenter> _animals = new List<IAnimalPresenter>();
        bool _shouldSpawn;

        void Start()
        {
            _shouldSpawn = true;

            StartCoroutine(SpawnRoutine());
        }

        IEnumerator SpawnRoutine()
        {
            while (_shouldSpawn)
            {
                SpawnNextAnimal();
                var delay = Random.Range(_gameConfig.minDelayBeforeSpawn, _gameConfig.maxDelayBeforeSpawn);
                yield return new WaitForSeconds(delay);
            }
        }

        void SpawnNextAnimal()
        {
            var animalId = Random.Range(0, _gameConfig.animals.Length);
            var animalConfig = _gameConfig.animals[animalId];
            var width = _gameConfig.mapSize.x / 2 - _gameConfig.spawnPadding.x;
            var height = _gameConfig.mapSize.y / 2 - _gameConfig.spawnPadding.x;

            var amnimalPos = new Vector3(Random.Range(-width, width),
                                                0,
                                                Random.Range(-height, height));

            var animalPresenter = _amimalFactory.Spawn(animalConfig, amnimalPos, this.transform);
            animalPresenter.OnDie += OnAnimalDie;

            _animals.Add(animalPresenter);
            animalPresenter.StartMove();
        }

        void OnAnimalDie(IAnimalPresenter presenter)
        {
            presenter.OnDie -= OnAnimalDie;
            _animals.Remove(presenter);

            _signalBus.Fire( new AnimalDiedSignal(presenter.AnimalType) );
        }
    }
}
