using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

    private Rigidbody2D rbtiro;
    public Vector2 speed = new Vector2(15, 0);



    void Start()
    {
        rbtiro = GetComponent<Rigidbody2D>();
        rbtiro.velocity = speed * this.transform.localScale.x;
        Destroy(gameObject, 2f);
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mob")

        {
            Destroy(gameObject);       
        }


    }
}
