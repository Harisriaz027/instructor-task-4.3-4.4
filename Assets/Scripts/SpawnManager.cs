using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] bombPowerUp;
    public int enemyCount;
    public int waveNumber = 1;
    private float spawnRange = 15f;
    public ParticleSystem powerupIndicator;
    void Start()
    {
        SpawnEnemyWaves(waveNumber);
    }


    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWaves(waveNumber);
        }
    }
    void SpawnEnemyWaves(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }

        if (waveNumber > 1)
        { 
        GameObject pos = Instantiate(bombPowerUp[Random.Range(0, 2)], new Vector3(Random.Range(-spawnRange, spawnRange), -.7f, Random.Range(-spawnRange, spawnRange)), bombPowerUp[Random.Range(0, 2)].transform.rotation);
        Instantiate(powerupIndicator, pos.transform.position + new Vector3(0, -.5f, 0), powerupIndicator.transform.rotation);
        } 
    }
    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, -1.8f, spawnPosZ);
        return spawnPos;
    }
}
