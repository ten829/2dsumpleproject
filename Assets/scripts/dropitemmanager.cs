using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropitemmanager : MonoBehaviour
{
    public static dropitemmanager instance;
    [SerializeField]
    private itembase[] dropitemprefabs;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    public void Generatedropitem(Transform dropitemtra,elementtype elementtype)
    {
        Instantiate(dropitemprefabs[(int)elementtype], dropitemtra.position, Quaternion.identity);
    }
}
