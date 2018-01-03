using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvmanager : MonoBehaviour
{

    public Text scoretx;
    private int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoretx.text = "Pts: " + score;
        score += 1;
    }
}
