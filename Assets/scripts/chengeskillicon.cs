using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chengeskillicon : MonoBehaviour
{
    [SerializeField]
    private Image iconimage;
    [SerializeField]
    private Image[] abilityimages;
    [SerializeField]
    private Sprite[] iconsprites;
    [SerializeField]
    private Sprite[] fireabilitysprites;
    [SerializeField]
    private Sprite[] iceabilitysprites;

    public void changeicon(elementtype elementtype)
    {
        iconimage.sprite = iconsprites[(int)elementtype];
        if (elementtype == elementtype.fire)
        {
            for (int i = 0; i < abilityimages.Length; i++)
            {
                abilityimages[i].sprite = fireabilitysprites[i];
            }   
        }
        else
        {
            for (int i = 0; i < abilityimages.Length; i++)
            {
                abilityimages[i].sprite = iceabilitysprites[i];
            }

        }
    }

}
