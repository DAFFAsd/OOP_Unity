using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 0;
    public int totalEnemies = 0;

    private void Start()
    {

    }

    private void Update()
    {
        if (totalEnemies <= 0 || waveNumber == 0)
        {
            timer += Time.deltaTime;
            if (timer >= waveInterval)
            {
                StartNewWave();
            }
        }
    }

    private void StartNewWave()
    {
        timer = 0;
        waveNumber++;
        totalEnemies = 0;

        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.StartSpawning();
            spawner.StopSpawning();
        }
    }


    public void OnEnemyKilled()
    {
        totalEnemies--;
    }
}
