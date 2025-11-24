using UnityEngine;

public class MainShipMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 mov;
    private float rotationAngle = 0;
    [SerializeField] float rotationSpeed;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform shootPlace;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mov.y = Input.GetAxis("Vertical");
        mov.x = Input.GetAxis("Horizontal");

    }
    
    void FixedUpdate()
    {
        ApplySpeed();
        ApplyRotation();
        FixDrift();
        Shoot();
 
    }
    void ApplySpeed()
    {
        if (mov.y == 0)
        {
            rb.linearDamping = Mathf.Lerp(rb.linearDamping, 3, Time.fixedDeltaTime);
        }
        else
        {
            rb.linearDamping = 0;
        }
       
        float currentSpeed = Vector2.Dot(transform.up, rb.linearVelocity);
        if(currentSpeed >= 15 || currentSpeed <= -15) return;
        rb.AddForce(transform.up * mov.y * 5f, ForceMode2D.Force);
    }

    void ApplyRotation()
    {
        rotationAngle -= mov.x * rotationSpeed;
        rb.MoveRotation(rotationAngle);
    }

    void FixDrift()
    {
        Vector2 velocityUp = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 velocityRight = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);
        rb.linearVelocity = velocityUp + velocityRight * 0.0f;
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, shootPlace.position, shootPlace.rotation);
            
        }
    }

}
