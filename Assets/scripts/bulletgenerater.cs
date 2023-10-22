using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletgenerater : MonoBehaviour
{
    [SerializeField]
    private bulletcontroller FireBullet;
    [SerializeField]
    private bulletcontroller IceBullet;
    [SerializeField]
    private GameObject generateposition;
    [SerializeField]
    private float bulletspeed;
    [SerializeField]
    private elementtype playerelementtype;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switchelementtype();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            generatebullet();
        }
        
    }
    private void switchelementtype()
    {
        playerelementtype = playerelementtype == elementtype.fire ? elementtype.ice : elementtype.fire; //三項演算子
    }
    private void generatebullet()
    {
        bulletcontroller bullet =
            Instantiate(playerelementtype == elementtype.fire ? FireBullet : IceBullet,
            generateposition.transform.position, Quaternion.identity);
        bullet.Shoot(new Vector2(-transform.localScale.x, 0) * bulletspeed);
    }
}
