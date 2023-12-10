using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penetratebulletcontroller : bulletcontroller
{
    [SerializeField]
    public int extrabulletpower = 30;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bulletpower = extrabulletpower;
        Debug.Log(bulletpower);
        effectmanager.instance.playeffect(transform, elementtype == elementtype.fire ? effecttype.fireeffect : effecttype.iceeffect, 1.0f);

    }
}
