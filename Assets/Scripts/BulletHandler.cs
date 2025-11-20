using UnityEngine;

public class BulletHandler : MonoBehaviour
{

    [SerializeField] float bullteSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.up * bullteSpeed * Time.deltaTime);
    }
}
