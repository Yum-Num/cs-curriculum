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
        if (platformer)
        {
            ySpeed = 0;
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
            Debug.Log("touched nonconsentually");
            TD.SwitchToAxe();
            Debug.Log("no switcher");
            Destroy(eai.Axe);
        }
    }
}