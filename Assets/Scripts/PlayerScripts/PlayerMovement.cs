using JetBrains.Annotations;
using System;
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
    [SerializeField] private float jumpForce = 5.0f;

    public bool groundCheck = false;
    private bool wallCheck;
    private bool canJump;

    [SerializeField] private float _sprintMultiplier = 3.0f;
    bool _isSprinting = false;

    private bool canDash;
    private float dashCooldown;

    private float fastFallSpeed;
    private float coyoteTime;
    private float wallSlideSpeed;

    [SerializeField] private float _friction = 0;

    private float gravity = -9.8f;

    Vector2 _inputVector;

    void Awake()
    {
        //Gather components 
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (groundCheck == false)
        {
            rb.AddForceY(gravity);
        }

        if (!(_inputVector == Vector2.zero)) {
            float inputForce = _inputVector.x * 100;
            inputForce = _isSprinting ? inputForce * _sprintMultiplier : inputForce;
            rb.AddForce(new Vector2(inputForce, 0), ForceMode2D.Force);
        } else if (Mathf.Abs(rb.linearVelocityX) > 1) {
            rb.AddForce(new Vector2(-1 * Mathf.Sign(rb.linearVelocityX) * _friction, 0), ForceMode2D.Force);
        } else {
            rb.linearVelocityX = 0;
        }

        if (Mathf.Abs(rb.linearVelocityX) > maxSpeed)
            rb.linearVelocityX = maxSpeed * Mathf.Sign(rb.linearVelocityX);
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

    public void OnMove(InputValue inputValue)
    {
        _inputVector = inputValue.Get<Vector2>();
    }

    public void OnJump()
    {
        if (groundCheck)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void OnSprint(InputValue value)
    {
        float boolVal = value.Get<float>();
        _isSprinting = boolVal == 1 ? true : false;
    }
}
