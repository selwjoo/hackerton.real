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

    // Start �޼��忡�� �г��� ��Ȱ��ȭ
    void Start()
    {
        // ���� ���� �� �г��� ��Ȱ��ȭ
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
            talkText.text = "�� ���� ����";
        }

        talkPanel.SetActive(isAction);
    }

    public void Sus()
    {

        spacePanel.SetActive(true);
        
        
    }
}

