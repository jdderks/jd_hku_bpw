using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timerUntillNextWave = 1f;
    public int normalEnemies = 1;
    public int speedyEnemies = 0;
    public int tankyEnemies = 0;
    public static int currentWave = 0;

    [SerializeField] private List<Transform> spawningPositions = new List<Transform>();

    public List<EnemyBehaviour> enemiesInScene = new List<EnemyBehaviour>();

    [SerializeField] private GameObject normalEnemy;
    [SerializeField] private GameObject speedyEnemy;
    [SerializeField] private GameObject tankyEnemy;

    private void Start()
    {
        currentWave = 0;
    }

    private void Update()
    {
        timerUntillNextWave -= Time.deltaTime;
        if (timerUntillNextWave < 0)
        {
            currentWave++;
            SpawnEnemies();
            timerUntillNextWave = 7f;
        }
    }


    void SpawnEnemies()
    {
        if (normalEnemies >= 5)
        {
            normalEnemies -= 5;
            speedyEnemies++;
        }
        if (speedyEnemies >= 10)
        {
            speedyEnemies -= 5;
            tankyEnemies++;
        }

        for (int i = 0; i < normalEnemies; i++)
        {
            Instantiate(normalEnemy, GetRandomSpawningPosition());
        }
        for (int i = 0; i < speedyEnemies; i++)
        {
            Instantiate(speedyEnemy, GetRandomSpawningPosition());
        }
        for (int i = 0; i < tankyEnemies; i++)
        {
            Instantiate(tankyEnemy, GetRandomSpawningPosition());
        }

        normalEnemies++;
    }

    Transform GetRandomSpawningPosition()
    {
        List<Transform> transforms = new List<Transform>();
        for (int i = 0; i < spawningPositions.Count; i++)
        {
            transforms.Add(spawningPositions[i]);
        }
        return transforms[Random.Range(0, spawningPositions.Count)];
    }
}
