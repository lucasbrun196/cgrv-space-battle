using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        rb.linearVelocity = Vector2.left * speed;
    }

    public void StopAndPushBack(Vector2 pushDirection, float pushForce)
    {
        speed = 0;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }

    public void Die()
    {
        GameManager gm = FindFirstObjectByType<GameManager>();
        gm.EnemyKilled();

        Destroy(gameObject);
    }

}
