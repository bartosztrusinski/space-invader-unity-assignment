using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeTime = 5f;
    [SerializeField] private float baseFiringRate = 0.2f;
    [SerializeField] private float firingRateVariance = 0;
    [SerializeField] private float minimumFiringRate = 0.1f;
    [SerializeField] private bool useAI;
    
    [HideInInspector]
    public bool isFiring;

    private Coroutine firingCor;
    private Vector2 moveDirection;
    private void Start()
    {
        if (useAI)
        {
            isFiring = true;
            moveDirection = transform.up * -1;
        }
        else
        {
            moveDirection = transform.up;
        }
    }

    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCor == null)
        {
            firingCor = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCor != null)
        {
            StopCoroutine(firingCor);
            firingCor = null;
        }
        
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = moveDirection * projectileSpeed;
            }
            
            Destroy(projectile, projectileLifeTime);

            float timeToNextProjectile =
                Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
            
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
