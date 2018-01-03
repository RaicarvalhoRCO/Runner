using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

    [SerializeField]
    private statbar health;
    [SerializeField]
    private statbar energy;
    [SerializeField]
    private player player;


    private void Awake()
    {    
        health.Init();
        energy.Init();
    }

    void Update ()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            health.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            health.CurrentVal += 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            energy.CurrentVal += 10;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            energy.CurrentVal -= 10;
        }

    }
}
