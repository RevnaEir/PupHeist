using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float speed = 5f; // Adjust the speed as needed
    public float jumpForce = 10f; // Adjust the jump force as needed
    private bool isGrounded;

    void Start()
    {
        // Your initialization code, if any
    }

    void Update()
    {
        // Get the horizontal input (A and D keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

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

        // Jumping logic
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Check if the character is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }

    void Jump()
    {
        // Apply a vertical force for jumping
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

