using UnityEngine;
using System.Collections;

public class SpawnEnemyShip : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesToSpawn;
    public float minY;
    public float maxY;
    public float spawnX;
    public float spawnDelay;

    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        for (int i = 0; i < GameDifficulty.enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, y, 0);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
