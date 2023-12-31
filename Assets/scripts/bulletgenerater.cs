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
    private penetratebulletcontroller penetrationbullet;
    [SerializeField]
    private GameObject generateposition;
    [SerializeField]
    private float bulletspeed;
    [SerializeField]
    public int extrarequirepoint = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            generatebullet();
        }
        if (pointmanager.instance.firepoint < extrarequirepoint)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z) && pointmanager.instance.playerelementtype == elementtype.fire)
        {
            generatepenetratebullet();
            pointmanager.instance.calcfirepoint(-extrarequirepoint);

        }
        
        
    }
    
    private void generatebullet()
    {
        bulletcontroller bullet =
            Instantiate(pointmanager.instance.playerelementtype == elementtype.fire ? FireBullet : IceBullet,
            generateposition.transform.position, Quaternion.identity);
        bullet.Shoot(new Vector2(-transform.localScale.x, 0) * bulletspeed);
    }
    private void generatepenetratebullet()
    {
        //新しく貫通弾用のプレハブを作って生成
        penetratebulletcontroller bullet = Instantiate(penetrationbullet, generateposition.transform.position, Quaternion.identity);
        bullet.Shoot(new Vector2(-transform.localScale.x, 0) * bulletspeed);
    }
}
