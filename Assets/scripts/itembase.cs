using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itembase : MonoBehaviour
{
    public int point;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out playercontroller playercontroller))
        {
            getitem();
        }
    }
    protected virtual void getitem()
    {
        Destroy(gameObject);
    }
}
