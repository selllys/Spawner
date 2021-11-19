using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField, Min(0)] private float _spawnDelay = 2f;

    private List<SpawnPoint> _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();

        if (_spawnPoints.Count > 0)
        {
            StartCoroutine(SpawnEnemies());
        }
        else
        {
            Debug.LogError("Add spawn points!");
        }
    }

    private IEnumerator SpawnEnemies()
    {
        var delay = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            foreach (SpawnPoint nextSpawnPoint in _spawnPoints)
            {
                yield return delay;
                nextSpawnPoint.SpawnEnemy();
            }
        }
    }
}