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




    public void ctrol() // ¾À 1¿¡¼­ ¹öÆ° ´©¸¦¶§ À×¿¨¤·
    {
        SceneManager.LoadScene("2");
    }

    public void dtrol() // ¾À 2¿¡¼­ ¹öÆ° ´©¸¦¶§ 
    {
        SceneManager.LoadScene("3");
    }
}
