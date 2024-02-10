using UnityEngine;
using System.Collections;

public class BeatriseMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed of movement
    public float moveTime = 4f;
    private bool movingRight = true; // Initial movement direction
    private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirection());
    }

    void Update()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, Physics.gravity.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, Physics.gravity.y);
            spriteRenderer.flipX = false;
        }
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTime);
            movingRight = !movingRight; // Change direction
        }
    }
}