using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] float bullteSpeed;

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.up * bullteSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShip"))
        {
            var enemy = collision.GetComponent<EnemyShip>();
            if (enemy != null)
            {
                enemy.Die();
            }

            Destroy(gameObject);
        }
    }
}
