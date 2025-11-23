using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.left;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    public void StopAndPushBack(Vector2 pushDirection, float pushForce)
    {
        speed = 0;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }

    public void ReverseDirection()
    {
        direction *= -1;
        transform.Rotate(0f, 0, 180f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            ReverseDirection();
        }
    }

}
