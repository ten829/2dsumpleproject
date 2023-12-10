using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybase : MonoBehaviour
{
    [SerializeField]
    protected int enemyHP;
    [SerializeField]
    public int enemyattackpower = 5;
    [SerializeField]
    protected elementtype enemyelementtype;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
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
                //GameObject effect = Instantiate(bullet.Elementtype == elementtype.fire ? Fireeffectprefab: Iceeffectprefab, transform.position, Quaternion.identity);

                //Destroy(effect, 1.0f);
                effectmanager.instance.playeffect(transform, bullet.Elementtype == elementtype.fire ? effecttype.firedestroyeffect : effecttype.icedestroyeffect, 1.0f);
                dropitemmanager.instance.Generatedropitem(transform, bullet.Elementtype);
                Destroy(gameObject);

            }

        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
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
                //GameObject effect = Instantiate(bullet.Elementtype == elementtype.fire ? Fireeffectprefab: Iceeffectprefab, transform.position, Quaternion.identity);

                //Destroy(effect, 1.0f);
                effectmanager.instance.playeffect(transform, bullet.Elementtype == elementtype.fire ? effecttype.firedestroyeffect : effecttype.icedestroyeffect, 1.0f);
                dropitemmanager.instance.Generatedropitem(transform, bullet.Elementtype);
                Destroy(gameObject);

            }

        }
    }
}
