using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] float bullteSpeed;

    public AudioClip explosionSoundEffect;

    void FixedUpdate(){
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
            AudioSource.PlayClipAtPoint(explosionSoundEffect, transform.position);

            GameManager manager = FindFirstObjectByType<GameManager>();
            manager.AddKill();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
