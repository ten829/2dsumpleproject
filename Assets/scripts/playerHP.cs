using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    [SerializeField]
    public int HP;
    [SerializeField]
    private slidercontroller slidercontroller;
    // Start is called before the first frame update
    void Start()
    {
        slidercontroller.setupslidervalue(HP);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out enemycontroller enemycontroller))
        {
            HP -= enemycontroller.enemyattackpower;
            slidercontroller.updateslidervalue(HP);
        }
    }
}
