using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 100f;
    
    GameObject player;
    private NavMeshAgent agent;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
    }

    public void Die()
    {
        EconomyManager.Money += 5;
        Destroy(gameObject);
    }
}
