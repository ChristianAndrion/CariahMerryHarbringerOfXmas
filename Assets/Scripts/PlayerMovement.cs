using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Transform tf;
    private Rigidbody2D rb;
    private PlayerInput pi;

    [Header("Player Variables")]
    public int health = 100;
    public float maxSpeed = 5.0f;
    public float dashSpeed = 10.0f;
    //TODO: public Elf currElf;

    //Private Movement Variables
    private float moveSpeed = 0.0f;
    private float jumpForce = 10.0f;

    public bool groundCheck = false;
    private bool wallCheck;
    private bool canJump;

    private bool canDash;
    private float dashCooldown;

    private float fastFallSpeed;
    private float coyoteTime;
    private float wallSlideSpeed;

    private float gravity = -9.8f;

    void Awake()
    {
        //Gather components 
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (groundCheck == false)
        {
            rb.AddForceY(gravity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = false;
        }

    }
}
