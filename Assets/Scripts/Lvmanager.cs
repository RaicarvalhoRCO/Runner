using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvmanager : MonoBehaviour
{
    private float transit;
    public Text scoretx;
    private int score;
    private Pause P;

    void Start()
    {
        score = 0;

    }


    void Update()
    {
        transit -= Time.deltaTime;
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
