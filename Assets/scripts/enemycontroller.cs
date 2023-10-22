using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemycontroller : MonoBehaviour
{
    [SerializeField]
    private int enemyHP;
    [SerializeField]
    private GameObject Fireeffectprefab;
    [SerializeField]
    private GameObject Iceeffectprefab;
    [SerializeField]
    private float moveposition;
    [SerializeField]
    private float moveduration;
    [SerializeField]
    private Ease ease;
    [SerializeField]
    public int enemyattackpower = 5;
    [SerializeField]
    private elementtype enemyelementtype;
    // Start is called before the first frame update
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(GetComponent<Rigidbody2D>().DOMoveX(transform.position.x + moveposition, moveduration).SetEase(ease));
        sequence.Append(GetComponent<Rigidbody2D>().DOMoveX(- moveposition, moveduration).SetEase(ease).SetRelative()).SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out bulletcontroller bullet))
        {
            if(bullet.Elementtype == enemyelementtype)
            {
                enemyHP -= bullet.bulletpower;
            }
            else
            {
                enemyHP -= 2 * bullet.bulletpower;
                Debug.Log("弱点");
            }
            if(enemyHP <= 0)
            {
                GameObject effect = Instantiate(bullet.Elementtype == elementtype.fire ? Fireeffectprefab: Iceeffectprefab, transform.position, Quaternion.identity);
                Destroy(effect, 1.0f);
                Destroy(gameObject);
            }
            
        }
    }
}
