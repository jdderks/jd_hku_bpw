using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timerUntillNextWave = 10f;
    public int difficulty = 1;

    public List<EnemyBehaviour> enemiesInScene = new List<EnemyBehaviour>();

    [SerializeField] private GameObject enemyObject;

    private void Update()
    {
        timerUntillNextWave -= Time.deltaTime;
        if (timerUntillNextWave < 0)
        {
            SpawnEnemies();
            difficulty+=3;
            timerUntillNextWave = 10f;
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < difficulty; i++)
        {
            GameObject enemy = Instantiate(enemyObject);
        }
    }
}
