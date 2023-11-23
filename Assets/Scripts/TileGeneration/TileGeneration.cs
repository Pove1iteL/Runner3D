using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] _tilePrefab;
    [SerializeField] private Transform _player;

    private List<GameObject> _tiles;
    private float _spawnPosiition = 0;
    private float _titleLength = 72.5f;
    private int _startTitle = 6;

    private void Start()
    {
        _tiles = new List<GameObject>();

        for (int i = 0; i < _startTitle; i++)
        {
            RandomTitleSpawn();
        }
    }

    private void Update()
    {
        if (_player.position.z - _titleLength > _spawnPosiition - (_startTitle * _titleLength))
        {
            RandomTitleSpawn();
            DeliteTile();
        }
    }

    private void RandomTitleSpawn()
    {
        int randomTitle = Random.Range(0, _tilePrefab.Length);
        SpawnTitle(randomTitle);
    }

    private void SpawnTitle(int titleIndex)
    {
        var title = Instantiate(_tilePrefab[titleIndex], transform.forward * _spawnPosiition, transform.rotation);

        _tiles.Add(title);

        _spawnPosiition += _titleLength;
    }

    private void DeliteTile()
    {
        Destroy(_tiles[0]);
        _tiles.RemoveAt(0);
    }
}
