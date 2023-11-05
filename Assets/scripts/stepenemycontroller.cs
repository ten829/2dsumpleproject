using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepenemycontroller : enemybase
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    float horizontalInput = 1.0f;
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject Fireeffectprefab;
    [SerializeField]
    private GameObject Iceeffectprefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        stepenemy stepenemy = GetComponentInChildren<stepenemy>();
        bool enemyright = stepenemy.isOnGround;
        rb.velocity = new Vector2(moveSpeed * horizontalInput, rb.velocity.y);
        if (enemyright != true)
        { 
            horizontalInput *= -1;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale; //反転
            rb.velocity = new Vector2(moveSpeed * horizontalInput, rb.velocity.y);
        }

    }
    

}
