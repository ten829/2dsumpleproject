using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointmanager : MonoBehaviour
{
    public int firepoint;
    public int icepoint;
    public static pointmanager instance;
    [SerializeField]
    public slidercontroller fireslidercontroller;
    [SerializeField]
    public slidercontroller iceslidercontroller;
    [SerializeField]
    public int firemaxpoint;
    [SerializeField]
    public int icemaxpoint;
    [SerializeField]
    public elementtype playerelementtype;
    [SerializeField]
    private chengeskillicon chengeskillicon;
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

    private void Start()
    {
        fireslidercontroller.setuppointslidervalue(firemaxpoint,firepoint);
        iceslidercontroller.setuppointslidervalue(icemaxpoint,icepoint);
        chengeskillicon.changeicon(playerelementtype);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switchelementtype();
        }
    }

    private void switchelementtype()
    {
        playerelementtype = playerelementtype == elementtype.fire ? elementtype.ice : elementtype.fire; //三項演算子
        chengeskillicon.changeicon(playerelementtype);
    }

    public void calcfirepoint(int point)
    {
        firepoint += point;
        fireslidercontroller.updateslidervalue(firepoint);
    }
    public void calcicepoint(int point)
    {
        icepoint += point;
        iceslidercontroller.updateslidervalue(icepoint);
    }
    
}
