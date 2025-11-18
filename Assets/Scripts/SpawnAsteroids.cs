using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float spawnInterval;
    private float spawnTime;

    void Update()
    {
        if (Time.time >= spawnTime)
        {
            SpawnAsteroid();
            spawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnAsteroid()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(asteroidPrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}