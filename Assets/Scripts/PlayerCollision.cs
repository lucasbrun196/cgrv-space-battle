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
        if (collision.CompareTag("Asteroid"))
        {
            manager.GameOver();

            GetComponent<MainShipMove>().enabled = false;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyShip"))
        {
            manager.GameOver();

            GetComponent<MainShipMove>().enabled = false;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

            var enemy = collision.gameObject.GetComponent<EnemyShip>();
            if (enemy != null)
            {
                Vector2 pushDir = (enemy.transform.position - transform.position).normalized;
                enemy.StopAndPushBack(pushDir, 5f);
            }
        }
    }
}
