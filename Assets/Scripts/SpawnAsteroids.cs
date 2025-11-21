using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int numberOfAsteroids;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    void Start()
    {
        for (int i = 0; i < numberOfAsteroids; i++) {
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(asteroidPrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}