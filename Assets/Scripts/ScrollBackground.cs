using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float scrollSpeed;
    private bool gameOver;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();


        rb2d.velocity = new Vector2(scrollSpeed, 0);
    }

    void Update()
    {
        
        if (gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}