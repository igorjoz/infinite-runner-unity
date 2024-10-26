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
        rb = gameObject.GetComponent<Rigidbody2D>();    // get Rigidbody2D component
        boxCollider2D = GetComponent<BoxCollider2D>();  // get BoxCollider2D component
    }

    // Update is called once per frame
    void Update()
    {
        //Jeœli aktualnie nie trwa gra nie wykonuj reszty metody; lesson8 change
        if (!GameManager.instance.isInGame)
        {
            return;
        }

        // check if 1 second (timestamp time) has passed
        if (IsGrounded() && Time.time >= timestamp)
        {
            if (jumped || doubleJumped)
            {
                jumped = false;
                doubleJumped = false;
            }

            timestamp = Time.time + 1f; // current time + 1 second
        }

        // GetMouseButtonDown != GetMouseButton
        if (Input.GetMouseButtonDown(0)) 
            {
            if (!jumped)
            {
                rb.velocity = (new Vector2(0f, jumpForce)); // set force upwards
                //rb.AddForce(new Vector2(0f, jumpForce * 40)); // alternative way: add force instead of setting it
                jumped = true;
            }
            else if (!doubleJumped)
            {
                rb.velocity = (new Vector2(0f, doubleJumpForce)); // set force upwards
                //rb.AddForce(new Vector2(0f, jumpForce * 40)); // alternative way: add force instead of setting it
                doubleJumped = true;
            }
        }

        // holding left mouse button slows down falling
        if (Input.GetMouseButton(0) && rb.velocity.y <= 0)
        {
            rb.AddForce(new Vector2(0f, liftingForce * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //sprawdzamy czy zderzyliœmy siê z przeszkod¹
        if (other.CompareTag("Obstacle"))
        {
            //Wywo³ujemy metodê odpowiedzialn¹ za œmieræ gracza
            HandlePlayerDeath();
        }
    }

    // check whether player touched ground: could be floor, platform, etc.
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, whatIsFloor);

        return hit.collider != null;
    }

    void HandlePlayerDeath()
    {
        //Zamra¿amy fizykê gracza (pozostanie on wtedy w miejscu w którym przegra³
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //Wywo³ujemy Game Over na managerze gry:
        GameManager.instance.GameOver();
    }

}
