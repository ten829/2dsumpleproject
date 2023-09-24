using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private Rigidbody2D Rb;
    [SerializeField] float movespeed = 0f;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out Rb);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        //x = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(x) > 0)
        {
            move();
        }
        else
        {
            Rb.velocity = new Vector2(0, Rb.velocity.y);
        }
    }
    private void move()
    {
        Rb.velocity = new Vector2(x * movespeed, Rb.velocity.y);

        float scale = 0f;
        if (x > 0)
        {
            scale = 1;
        }
        else
        {
            scale = -1;
        }
        transform.localScale = new Vector3(-scale, transform.localScale.y, transform.localScale.z);
    }
}
