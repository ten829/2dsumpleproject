using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireitem : itembase
{
    protected override void getitem()
    {
        pointmanager.instance.Addfirepoint(point);
        base.getitem();
    }
}
