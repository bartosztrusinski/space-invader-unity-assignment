using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping = false;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (var wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetFirstWaypoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
        
        
    }

}
