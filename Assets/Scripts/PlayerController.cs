using Unity.VisualScripting;
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
    public bool platformer;
    public Singleton st;
    private TopDown_AnimatorController TD;
    private EnemyAI eai;
    public bool daxe = false;
    public float jumpforce = .15f;
    public float decayrate = 1;
    private 
    
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        st = FindObjectOfType<Singleton>();
        TD = FindObjectOfType<TopDown_AnimatorController>();
        eai = FindObjectOfType<EnemyAI>();
    }
    void Update()
    {
        Debug.Log(jumpforce);
        Debug.DrawRay(transform.position + new Vector3(0.2f, 0, 0), Vector2.down, Color.red);
        if (Physics2D.Raycast(transform.position + new Vector3(0.2f, 0, 0), Vector2.down, 1f) && Input.GetKey(KeyCode.Space) ||Physics2D.Raycast(transform.position - new Vector3(0.2f, 0, 0), Vector2.down, 1f)  && Input.GetKey(KeyCode.Space))
        {
            jumpforce = .15f;
            Debug.Log("raycasted");
            jump();
        }
        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            ySpeed = 5f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            ySpeed = 0f;
            
        }

        // Handle input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Your code here: Detect input for left and right movement
        xVector = xSpeed * horizontalInput * Time.deltaTime;
        yVector = ySpeed * verticalInput * Time.deltaTime;
        transform.Translate(xVector, yVector, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin")) {
            st.coin = (st.coin + 1);
            print("I have " + st.coin + " Coins");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Axe"))
        {
            TD.SwitchToAxe();
            daxe = true;
        }
    }

    void jump()
    {
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }
}