using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float axish = 0.0f;
    public float jump;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
	

    

	void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,groundLayer);
        axish = Input.GetAxisRaw("Horizontal");

        if(axish > 0.0f)
        {
            transform.localScale = new Vector2(1,1);
        }
        else if(axish < 0.0f)
        {
            transform.localScale = new Vector2(-1,1);
        }
        if(Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        
    }

    void FixedUpdate()
    {
       rb.velocity = new Vector2(axish * speed, rb.velocity.y);

    }
   
}
