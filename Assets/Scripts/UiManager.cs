using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI statText;



    public Image pausePanel, buttonTry;
    public TextMeshProUGUI textTry;


    // Start is called before the first frame update
    void Start()
    {
        StackContainer.SuccessEvent.AddListener(()=>UiUpdater(StackContainer.stat,1));
        StackContainer.FailedEvent.AddListener(() => UiUpdater(StackContainer.stat,-1));
        PlayerAnimController.DeathEventBackward.AddListener(PauseUIView);
        PlayerAnimController.DeathEventBackward.AddListener(() => UiUpdater(0, 0));
        PlayerAnimController.DeathEventForward.AddListener(PauseUIView);
    }

    // Update is called once per frame
    void PauseUIView()
    {
        pausePanel.gameObject.SetActive(true);
        pausePanel.DOColor(new Color(pausePanel.color.r, pausePanel.color.g, pausePanel.color.b,0.8f),2);
        buttonTry.DOColor(new Color(buttonTry.color.r, buttonTry.color.g, buttonTry.color.b, 1), 2);
        textTry.DOColor(new Color(textTry.color.r, textTry.color.g, textTry.color.b, 1), 2);
    }
    public void UiUpdater(int stat,int toAdd)
    {
        statText.DOCounter(stat+ toAdd, stat, 0.2f);
        if (toAdd>0)
        {
            counterText.text = ("+1");
        }
        else
        {
            counterText.text = ("-1");
        }
        counterText.DOFade(1,0.1f).OnComplete(()=>counterText.transform.DOShakeScale( 0.2f, 0.4f, 1,5).OnComplete(() => counterText.DOFade(0, 0.1f)));
    }
    public void LoadScene(int index) 
    {
        SceneManager.LoadSceneAsync(index);
    }
}
