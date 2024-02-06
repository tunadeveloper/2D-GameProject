using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb2D;
    private Animator animator;
    public bool isGrounded = false;
    

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) {
        gameObject.transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            animator.SetBool("Run", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector2(transform.position.x - speed, transform.position.y);
            animator.SetBool("WrongWay", true);
        }
        else { animator.SetBool("Run", false); animator.SetBool("WrongWay", false); }
      
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded = true;
        }else
        
        { isGrounded = false; }
    }

   

    private void FixedUpdate()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            isGrounded = false;
        }
    }
}
