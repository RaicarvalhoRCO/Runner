using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public player P;
    public GameObject gameovermenu;

    void Start()
    {

        gameovermenu.SetActive(false);
    }


    void Update()
    {
        if (P.Dead)
        {
            Time.timeScale = 0;
            gameovermenu.SetActive(true);
        }
    }
    
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
