using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WaveConfigSO waveConfigSo;

    private List<Transform> waypoints;

    private int waypointIndex = 0;
    
    void Start()
    {
        waveConfigSo = EnemySpawner.Instance.GetCurrentWave();
        waypoints = waveConfigSo.GetWaypoints();
        transform.position = waveConfigSo.GetFirstWaypoint().position;
    }
    
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPos = waypoints[waypointIndex].position;
            float delta = waveConfigSo.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
