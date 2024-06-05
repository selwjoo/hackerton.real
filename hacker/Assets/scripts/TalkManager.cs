using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public Text talkText;
    public GameObject talkPanel;
    public GameObject spacePanel;
    public bool isAction;
    //public GameObject scanObject;

    // Start 메서드에서 패널을 비활성화
    void Start()
    {
        // 게임 시작 시 패널을 비활성화
        talkPanel.SetActive(false);
        spacePanel.SetActive(false);
    }

    public void Action() //GameObject scanObj
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            //scanObject = scanObj; 
            isAction = true;
            talkText.text = "아 나도 몰라";
        }

        talkPanel.SetActive(isAction);
    }

    public void Sus()
    {

        spacePanel.SetActive(true);
        
        
    }
}

