using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceitem : itembase
{
    protected override void getitem()
    {
        pointmanager.instance.Addicepoint(point);
        base.getitem();
    }
}
