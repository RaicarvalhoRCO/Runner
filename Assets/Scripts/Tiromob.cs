using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiromob : MonoBehaviour
{

    private Rigidbody2D rbtiro;
    public Vector2 speed = new Vector2(3f, 0);

    void Start()
    {
        rbtiro = GetComponent<Rigidbody2D>();
        rbtiro.velocity = speed * this.transform.localScale.x;
        Destroy(gameObject, 7f);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")

        {
            Destroy(gameObject);
        }


    }
}
