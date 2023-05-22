using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushing : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public LayerMask boxLayer; // Layer mask for detecting boxes

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal and vertical input values
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    private void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Check for box interaction
        if (movement.y != 0)
        {
            // Calculate a position in front of the player
            Vector2 pushPosition = rb.position + new Vector2(0f, movement.y);

            // Check if there's a box in front of the player
            Collider2D boxCollider = Physics2D.OverlapCircle(pushPosition, 0.2f, boxLayer);
            if (boxCollider != null)
            {
                // Push the box
                Rigidbody2D boxRb = boxCollider.GetComponent<Rigidbody2D>();
                boxRb.MovePosition(boxRb.position + movement * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
