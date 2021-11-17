using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField, Min(0)]
    private float _startTime = 3f;

    [SerializeField, Min(0)]
    private float _spawnDelay = 2f;

    private List<SpawnPoint> _spawnPoints;
    private Queue<SpawnPoint> _spawnQueue;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();
        _spawnQueue = new Queue<SpawnPoint>();

        InvokeRepeating(nameof(SpawnEnemy), _startTime, _spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints.Count == 0)
        {
            Debug.LogError("Add spawn points!");
            return;
        }

        if (_spawnQueue.Count == 0)
        {
            _spawnQueue = new Queue<SpawnPoint>(_spawnPoints);
        }

        SpawnPoint nextSpawnPoint = _spawnQueue.Dequeue();
        nextSpawnPoint.SpawnEnemy();
    }
}