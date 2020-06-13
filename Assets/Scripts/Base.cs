using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public static float CurrentHealth = 100;
    private float startHealth = 100;

    private void Start()
    {
        CurrentHealth = startHealth;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log(other);
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();
            enemy.Die();
            CurrentHealth -= 10;
        }
    }
}
