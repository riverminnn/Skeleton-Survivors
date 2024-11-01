using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private float m_Speed = 3.0f;
    // [ENCAPSULATION]
    protected float speed
    {
        get { return m_Speed; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("Negative Value Is Not Available");
            }
            else
            {
                m_Speed = value;
            }
        }
    }

    private KeyCode sprintKey = KeyCode.LeftShift;
    private KeyCode crouchKey = KeyCode.LeftControl;

    public CharacterController controller;
    private float gravity = -9.81f * 2;
    protected float jumpHeight = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;
    private float groundDistance = 0.4f;

    protected bool isSprinting = false;
    protected float sprintSpeed = 1f;

    protected bool isCrouching = false;
    protected float crouchingHeight = 1.25f;
    protected float standingHeight = 3.64f;
    protected float crouchingSpeed = 0.5f;

    Vector3 velocity;
    bool isGrounded;

    
    // Update is called once per frame
    void Update()
    {
        
    }

    // [POLYMORPHISM]
    protected void PlayerMove()
    {
        // Check if player is on the ground and set isGrounded to TRUE
        GroundCheck();
        // Reset velocity.y 
        ResetPlayerVelocity();
        // Move player with specific way
        Walk();
        // Sprint
        Sprinting();
        // Crouching
        Crouching();
        // Make player jump
        Jump();
        // Gravity for player: v = 1/2 g*t^2
        Gravity();
        
    }

    private void Gravity()
    {
        
        velocity.y += gravity * Time.deltaTime; // g * t
        controller.Move(velocity * Time.deltaTime); //
    }

    private void Jump()
    {
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }

    private void Sprinting()
    {
        if (Input.GetKey(sprintKey))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void Crouching()
    {
        if (Input.GetKey(crouchKey))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
    }

    private void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;    
        if (isSprinting == true)
        {
            move *= sprintSpeed;
        }
        if (isCrouching == true)
        {
            controller.height = crouchingHeight;
            move *= crouchingSpeed;
        }
        else
        {
            controller.height = standingHeight;
        }
        controller.Move(move * speed * Time.deltaTime);
    }

    private void ResetPlayerVelocity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}
