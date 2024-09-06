using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Movement variables
    public float xSpeed = 5f;
    private float xVector = 0f;
    public float ySpeed = 5f;
    private float yVector = 0f;
    private Rigidbody2D rb;
    public bool overworld;
        void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Handle input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Your code here: Detect input for left and right movement
        xVector = xSpeed * horizontalInput * Time.deltaTime;
        yVector = ySpeed * verticalInput * Time.deltaTime;
        transform.Translate(xVector, yVector, 0);
    }
}
        /*
        Vector2 movement = new Vector2(xVector, yVector);
        rb.AddForce(movement);
        // Hint: Use Input.GetAxis("Horizontal") to get smooth input
        // Calculate xVector based on input
        // Your code here: Set xVector based on the input
    }
}
    */