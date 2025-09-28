using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zoo;
using Zoo.Config;

public class AnimalSpawner : MonoBehaviour
{
    [Inject] private GameConfig _gameConfig;
    [Inject] private AnimalFactory _amimalFactory;

    private List<AnimalPresenter> _animals = new List<AnimalPresenter>();

    private void Start()
    {
        SpawnNextAnimal();
    }

    private void SpawnNextAnimal()
    {
        var animalConfig = _gameConfig.animals[1];
        var amnimalPos = new Vector3(1, 0, 1);
        var animalPresenter = _amimalFactory.Spawn(animalConfig, amnimalPos);
        _animals.Add(animalPresenter);

        animalPresenter.StartMove();
    }
}
