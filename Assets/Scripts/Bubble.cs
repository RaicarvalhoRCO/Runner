using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    private Rigidbody2D rbtiro;
    public Vector2 speed;

    void Start()
    {
        rbtiro = GetComponent<Rigidbody2D>();
        speed = new Vector2(1f, Random.Range(-1f, 1f));

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
