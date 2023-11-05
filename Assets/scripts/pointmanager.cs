using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointmanager : MonoBehaviour
{
    public int firepoint;
    public int icepoint;
    public static pointmanager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Addfirepoint(int point)
    {
        firepoint += point;
    }
    public void Addicepoint(int point)
    {
        icepoint += point;
    }
    
}
