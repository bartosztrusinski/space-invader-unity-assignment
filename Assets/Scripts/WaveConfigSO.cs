using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private WaypointsContainer pathPrefab;
    [SerializeField] private float moveSpeed = 5, intervalBetweenEnemySpawns = 1f, spawnTimeVariance = 0f;
    [SerializeField] private float minimumSpawnTime = 0.2f;

    public Transform GetFirstWaypoint()
    {
        return pathPrefab.waypoints[0];
    }

    public List<Transform> GetWaypoints()
    {
        return pathPrefab.waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(intervalBetweenEnemySpawns - spawnTimeVariance,
            intervalBetweenEnemySpawns + spawnTimeVariance);

        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
    
}
