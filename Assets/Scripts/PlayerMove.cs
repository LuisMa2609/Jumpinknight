using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 5f;
    public float jumpSpeed = 10f;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move();
        Flip();
    }

    void Move()
    {
        if(Input.GetKey("d")|| Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
        }
        else if(Input.GetKey("a")|| Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        if(Input.GetKey("space") && CheckGround.IsGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
    }


    void Flip()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // No voltear la imagen
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Voltear la imagen
        }
    }

    
}