using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class jump : MonoBehaviour
{
    private Rigidbody2D Rb;
    [SerializeField]
    float jumppower;
    float firstSpeed = 16.0f;
    float gravity = 30.0f;
    float timer = 0f;
    bool jumpkey = false;
    Vector2 newvec = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out Rb);
    }

    // Update is called once per frame
    void Update()
    {
        jumpkey = Input.GetButtonDown("Jump");
        if (jumpkey)
        {
            Jump();
        }    
    }

    private void Jump()
    {
        Rb.AddForce(transform.up * jumppower);
        if (jumpkey && Rb.velocity.y >= 0f)
        {
            timer += Time.deltaTime;
            newvec.y = firstSpeed;
            newvec.y -= (gravity * timer);
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
            newvec.y = 0f;
            newvec.y -= (gravity * timer);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
    }

}
