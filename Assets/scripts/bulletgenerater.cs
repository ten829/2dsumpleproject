using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletgenerater : MonoBehaviour
{
    [SerializeField]
    private bulletcontroller Bullet;
    [SerializeField]
    private GameObject generateposition;
    [SerializeField]
    private float bulletspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletcontroller bullet =  Instantiate(Bullet, generateposition.transform.position, Quaternion.identity);
            bullet.Shoot(new Vector2(-transform.localScale.x, 0) * bulletspeed);
        }
        
    }
}
