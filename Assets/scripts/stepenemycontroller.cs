using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepenemycontroller : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    float horizontalInput = 1.0f;
    private Rigidbody2D rb;

    [SerializeField]
    private int enemyHP;
    [SerializeField]
    private GameObject Fireeffectprefab;
    [SerializeField]
    private GameObject Iceeffectprefab;
    [SerializeField]
    public int enemyattackpower = 5;
    [SerializeField]
    private elementtype enemyelementtype;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out bulletcontroller bullet))
        {
            if (bullet.Elementtype == enemyelementtype)
            {
                enemyHP -= bullet.bulletpower;
            }
            else
            {
                enemyHP -= 2 * bullet.bulletpower;
                Debug.Log("弱点");
            }
            if (enemyHP <= 0)
            {
                GameObject effect = Instantiate(bullet.Elementtype == elementtype.fire ? Fireeffectprefab : Iceeffectprefab, transform.position, Quaternion.identity);
                Destroy(effect, 1.0f);
                Destroy(gameObject);
            }

        }
    }

}
