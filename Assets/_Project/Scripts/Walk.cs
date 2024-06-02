using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float speed = 5f; // Adjust the speed as needed
    public float jumpForce = 10f; // Adjust the jump force as needed
    public LayerMask groundLayer; // Layer mask for detecting ground
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] float groundDistance = 1.0f;
    public Animator animator; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the horizontal input (A and D keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector2 movement = new Vector2(horizontalInput, 0f);

        // Move the character
        transform.Translate(movement * speed * Time.deltaTime);

        // Flip the sprite based on movement direction
        if (movement.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        // Check if the player is grounded
        isGrounded = IsGrounded();

        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply a vertical force for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    
    bool IsGrounded() 
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down * groundDistance;
        
        
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, groundDistance, groundLayer);
        if (hit.collider != null) {
            return true;
        }

        return false;
    }
}