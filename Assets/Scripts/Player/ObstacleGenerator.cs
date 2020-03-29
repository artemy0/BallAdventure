using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;

    [SerializeField] private float _cooldown, _spawnDelay;

    [SerializeField] private GameObject _obstaclesStorage;

    private Coroutine _obstacleSpawner;

    private void Start()
    {
        StartSpawnObstacles();
    }

    private void OnDestroy()
    {
        StopSpawnObstacles();
    }

    public void StartSpawnObstacles()
    {
        _obstacleSpawner = StartCoroutine(ObstaclesSpawner(_cooldown));
    }

    public void StopSpawnObstacles()
    {
        StopCoroutine(_obstacleSpawner);
    }

    private IEnumerator ObstaclesSpawner(float delay)
    {
        while (true)
        {
            Vector3 spawnPosition = transform.position;

            yield return new WaitForSeconds(_spawnDelay);
            int obstacleIndex = Random.Range(0, _obstacles.Length);
            GameObject obstacle = Instantiate(_obstacles[obstacleIndex], spawnPosition, transform.rotation);
            obstacle.transform.parent = _obstaclesStorage.transform;

            yield return new WaitForSeconds(delay);
        }
    }
}
