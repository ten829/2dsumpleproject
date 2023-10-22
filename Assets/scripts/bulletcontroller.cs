using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    [SerializeField]
    private GameObject effectprefab;
    [SerializeField]
    private GameObject player;
    public int bulletpower = 10;
    [SerializeField]
    private elementtype elementtype;
    public elementtype Elementtype { get => elementtype; set => elementtype = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void Shoot(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction);
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(effectprefab, transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        Destroy(gameObject);
    }
}
