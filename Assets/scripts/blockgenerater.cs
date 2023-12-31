using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockgenerater : MonoBehaviour
{
    private jump2 jump2;
    public Transform generateposition;
    public GameObject blockprefab;
    public Transform generatepositionfoot;
    public bool IsblockOn;
    public pointmanager pointmanager;
    public int requirepoint = 5;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out jump2);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsblockOn == true)
        {
            return;
        }
        if(pointmanager.icepoint < requirepoint)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Z) && pointmanager.instance.playerelementtype == elementtype.ice)
        {
            generateblock();
            pointmanager.calcicepoint(-requirepoint);

        }
    }

    public void generateblock()
    {
        if(jump2.IsGrounded == true)
        {
            Instantiate(blockprefab, generateposition.position, Quaternion.identity);
        }
        else{
            Instantiate(blockprefab, generatepositionfoot.position, Quaternion.identity);
        }

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "block")
        {
            IsblockOn = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "block")
        {
            IsblockOn = false;
        }
    }
}
