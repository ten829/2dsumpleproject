using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    [SerializeField]
    public int HP;
    [SerializeField]
    public int MaxHP;
    [SerializeField]
    private slidercontroller slidercontroller;
    [SerializeField]
    private GameOvercanvas GameOvercanvasPrefab;
    private bool isGameOver = false;
    public bool IsGameOver { get => isGameOver; }
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
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
            HP = Mathf.Clamp(HP, 0, MaxHP);
            slidercontroller.updateslidervalue(HP);
            if (HP > 0)
            {
                return;
            }
            if (isGameOver == true)
            {
                return;
            }
            Instantiate(GameOvercanvasPrefab);
            isGameOver = true;
        }

    }
}
