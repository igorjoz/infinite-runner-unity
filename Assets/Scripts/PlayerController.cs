using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float doubleJumpForce;
    public float liftingForce;

    public bool jumped;
    public bool doubleJumped;

    public LayerMask whatIsFloor;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private float timestamp;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Time.time >= timestamp)
        {
            if (jumped || doubleJumped)
            {
                jumped = false;
                doubleJumped = false;
            }

            timestamp = Time.time + 1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!jumped)
            {
                rb.velocity = (new Vector2(0f, jumpForce));
                jumped = true;
            }
            else if (!doubleJumped)
            {
                rb.velocity = (new Vector2(0f, doubleJumpForce));
                doubleJumped = true;
            }
        }

        if (Input.GetMouseButton(0) && rb.velocity.y <= 0)
        {
            rb.AddForce(new Vector2(0f, liftingForce * Time.deltaTime));
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, whatIsFloor);

        return hit.collider != null;
    }
}
