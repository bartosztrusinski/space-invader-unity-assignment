using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 50;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        DamageDealer damageDealer = col.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
