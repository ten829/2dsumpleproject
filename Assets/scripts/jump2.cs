using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump2 : MonoBehaviour
{
    private Rigidbody2D Rb;
    [SerializeField] float jumppower;
    [SerializeField] bool isGrounded = true;
    public bool IsGrounded => isGrounded; //isGroundedのプロパティ
    public Transform groundCheck;
    public LayerMask groundLayer;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rb.velocity = new Vector2(Rb.velocity.x, jumppower);
        //isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //{
            //isGrounded = true;
        //}
    }
}
