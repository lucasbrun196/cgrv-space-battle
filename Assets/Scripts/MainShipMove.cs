using UnityEngine;

public class MainShipMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 mov;
    private float rotationAngle = 0;
    [SerializeField]  float rotationSpeed;
    [SerializeField] float speed;
    
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
        ClampToCameraBounds();
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
        if(currentSpeed >= 5.5 || currentSpeed <= -5.5) return;
        rb.AddForce(transform.up * mov.y, ForceMode2D.Force);
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

    void ClampToCameraBounds()
    {
        Vector3 pos = transform.position;

        // camera limits
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // if the plane hits the left/right/bottom border, stop its movement
        if (pos.x < bottomLeft.x)
        {
            pos.x = bottomLeft.x;
            rb.linearVelocity = Vector2.zero;
        }

        if (pos.x > topRight.x)
        {
            pos.x = topRight.x;
            rb.linearVelocity = Vector2.zero;
        }

        if (pos.y < bottomLeft.y)
        {
            pos.y = bottomLeft.y;
            rb.linearVelocity = Vector2.zero;
        }

        transform.position = pos;
    }

}
