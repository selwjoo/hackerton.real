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
    public string textMessage;
    public float delay = 0.1f;
    public bool isTalk;

    private string currentText = "";

    void Start()
    {
        if (isTalk)
        {
            // 게임 시작 시 패널을 비활성화
            talkPanel.SetActive(false);
            spacePanel.SetActive(false);
        }else
        {
            talkPanel.SetActive(true);
            spacePanel.SetActive(true);
            StartCoroutine(ShowText());
        }
    }

    void Update()
    {
        if (!isTalk && Input.GetKeyDown("f"))
        {
            talkPanel.SetActive(false);
            spacePanel.SetActive(false);
        }
    }

    // 대화 내용을 매개변수로 받아 대화 패널을 토글
    public void Action()
    {
        StartCoroutine(ShowText());
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            talkText.text = textMessage;
        }
        talkPanel.SetActive(isAction);
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= textMessage.Length; i++)
        {
            currentText = textMessage.Substring(0, i);
            talkText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
