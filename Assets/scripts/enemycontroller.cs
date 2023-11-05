using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemycontroller : enemybase
{
    //[SerializeField]
    //private GameObject Fireeffectprefab;
    
    //private GameObject Iceeffectprefab;
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

}
