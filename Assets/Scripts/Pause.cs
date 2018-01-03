using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public bool paused = false;
    public GameObject pausemenu;
    public string mainMenu;



	void Start ()
    {

		
	}
	

	void Update ()
    {
		if(paused)
        {
            pausemenu.SetActive(true);
        }
        else
        {
            pausemenu.SetActive(false);
        }
    }

    public void PauseGame()
    {

            paused = !paused;
 

        if(paused)
        {
            Time.timeScale = 0;
        }
        else if(!paused)
        {
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
