using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvmanager : MonoBehaviour
{

    public Text scoretx;
    private int score;
    private Pause P;

    void Start()
    {
        score = 0;
    }


    void Update()
    {

        if (Time.timeScale == 0)
        {
            scoretx.text = "Pts: " + score;
            score += 0;
        }
        else
        {
            scoretx.text = "Pts: " + score;
            score += 1;
        }
    }
}
