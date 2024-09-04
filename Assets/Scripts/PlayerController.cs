using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Movement variables
    public float xSpeed = 5f;
    private float xVector = 0f;
    private Rigidbody2D rb;
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Handle input
        float horizontalInput = Input.GetAxis("Horizontal");
        // Your code here: Detect input for left and right movement
        xVector = xSpeed * horizontalInput;

        Vector2 movement = new Vector2(xVector, 0);
        rb.AddForce(movement);
        // Hint: Use Input.GetAxis("Horizontal") to get smooth input
        // Calculate xVector based on input
        // Your code here: Set xVector based on the input
    }
}