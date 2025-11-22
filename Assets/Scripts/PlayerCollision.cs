using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager manager;

    void Start()
    {
        manager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid") || collision.CompareTag("EnemyShip"))
        {
            manager.GameOver();
            gameObject.SetActive(false);
        }
    }
}
