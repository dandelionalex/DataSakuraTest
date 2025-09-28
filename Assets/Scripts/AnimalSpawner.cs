using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zoo;
using Zoo.Config;

namespace Zoo
{
    public sealed class AnimalSpawner : MonoBehaviour
    {
        [Inject] private GameConfig _gameConfig;
        [Inject] private AnimalFactory _amimalFactory;

        List<AnimalPresenter> _animals = new List<AnimalPresenter>();
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

            _animals.Add(animalPresenter);
            animalPresenter.StartMove();
        }
    }
}
