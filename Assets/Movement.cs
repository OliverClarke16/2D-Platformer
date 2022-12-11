using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float movementX;
    float movementY;
    bool jump;
    public float velocity = 200f;
    public Rigidbody2D rb;
    public float jumpForce = 6f;
    public Animator animator;
    bool facingRight = true; //1
    bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //moving
        movementX = Input.GetAxis("Horizontal");
        movementY = rb.velocity.y;
        print(movementX);
        animator.SetFloat("movementX", movementX);
        animator.SetFloat("movementY", movementY);
        rb.velocity = new Vector2(movementX * velocity * Time.fixedDeltaTime, rb.velocity.y);

        //jumping 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jump == false)
        {
            jump = true;
            animator.SetBool("jumpAnimation", jump);
            isGrounded = false;

            rb.velocity = Vector2.up * jumpForce; 

        }

        if (movementX < 0 && facingRight == true)
        {
            transform.Rotate(0, 180, 0);
            facingRight = false;
        }
        else if (movementX > 0 && facingRight == false)
        {

            transform.Rotate(0, 180, 0);
            facingRight = true;

        }


    }
    void FixedUpdate()
    {

        rb.velocity = new Vector2(movementX * velocity * Time.fixedDeltaTime, rb.velocity.y);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jump = false;
            animator.SetBool("jumpAnimation", jump);
        }
    }
}