using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, transform.position, transform.rotation);

        Debug.Log($"Enemy spawned at {gameObject.name}");
    }
}