using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class slidercontroller : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Text text;
    [SerializeField]
    private  Text textmaxvalue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
    public void setupslidervalue(int defaultmaxvalue)
    {
        slider.maxValue = defaultmaxvalue;
        //slider.value = defaultvalue;
        slider.DOValue(defaultmaxvalue, 0.5f);
        //text.text = $"{slider.value} / {slider.maxValue}";

        text?.DOCounter(0, (int)slider.maxValue, 0.5f);
        textmaxvalue.text = $"/ {slider.maxValue}";
    }
    public void setuppointslidervalue(int defaultmaxvalue,int currentvalue)
    {
        slider.maxValue = defaultmaxvalue;
        //slider.value = defaultvalue;
        slider.DOValue(currentvalue, 0.5f);
        //text.text = $"{slider.value} / {slider.maxValue}";

        text?.DOCounter(0, currentvalue, 0.5f);
        textmaxvalue.text = $"/ {slider.maxValue}";
    }
    public void updateslidervalue(int newvalue)
    {
        int prevvalue = (int)slider.value;
        //slider.value = newvalue;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(slider.DOValue(newvalue, 0.5f));
        //text.text = $"{slider.value} / {slider.maxValue}";
        sequence.Join(text.DOCounter(prevvalue, newvalue, 0.5f));
    }



}
