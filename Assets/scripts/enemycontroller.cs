using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemycontroller : MonoBehaviour
{
    [SerializeField]
    private int enemyHP;
    [SerializeField]
    private GameObject effectprefab;
    [SerializeField]
    private float moveposition;
    [SerializeField]
    private float moveduration;
    [SerializeField]
    private Ease ease;
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
            enemyHP -= bullet.bulletpower;
            if(enemyHP <= 0)
            {
                GameObject effect = Instantiate(effectprefab, transform.position, Quaternion.identity);
                Destroy(effect, 1.0f);
                Destroy(gameObject);
            }
            
        }
    }
}
