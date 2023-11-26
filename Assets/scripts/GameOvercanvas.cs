using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOvercanvas : MonoBehaviour
{
    [SerializeField]
    public Text gameovertext;
    [SerializeField]
    public Button retrybutton;
    [SerializeField]
    public Image retrybuttonimage;
    [SerializeField]
    public Text retrybuttontext;
    // Start is called before the first frame update
    void Start()
    {
        ShowGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ShowGameOver()
    {
        gameovertext.color = new Color(1,1,1,0);
        retrybuttonimage.color = new Color(1, 1, 1, 0);
        retrybuttontext.color = new Color(0, 0, 0, 0);
        retrybutton.interactable = false;

        Sequence sequence = DOTween.Sequence();
        //GAMEOVERtextを表示
        sequence.Append(gameovertext.DOFade(1.0f, 1.0f));
        //interval
        sequence.AppendInterval(1.0f);
        //GAMEOVERtextを上へ移動
        sequence.Append(gameovertext.rectTransform.DOAnchorPos(new Vector2(0, 100), 1.0f)).SetRelative();
        //RestartButtonを表示
        sequence.Join(retrybuttontext.DOFade(1.0f, 0.5f));
        sequence.Join(retrybuttonimage.DOFade(1.0f, 0.5f))
            .OnComplete(() => retrybutton.interactable = true); ;
    }
}
