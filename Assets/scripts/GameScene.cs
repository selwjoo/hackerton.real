using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene("4");
           
        }

        if (collision.gameObject.name == "Player2")
        {
            SceneManager.LoadScene("5");

        }


        if (collision.gameObject.name == "Player3")
        {
            SceneManager.LoadScene("6");

        }
    }




    public void ctrol() // �� 1���� ��ư ������ �׿���
    {
        SceneManager.LoadScene("2");
    }

    public void dtrol() // �� 2���� ��ư ������ 
    {
        SceneManager.LoadScene("3");
    }
}
