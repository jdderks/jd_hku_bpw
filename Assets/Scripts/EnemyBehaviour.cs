using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float stoppingDistance;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - this.transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);
            if (Vector3.Distance(transform.position,player.transform.position) > stoppingDistance)
            {
                transform.Translate(0, 0, Time.deltaTime * movementSpeed);
            }
        }
    }
}
