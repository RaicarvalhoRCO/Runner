using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWater : MonoBehaviour
{
    private player player;
    private Animator anim;
    private GameObject clone;
    private Transform mob;
    private Transform spawntiro;
    public GameObject tiro;
    private Rigidbody2D rbmob;


    private float drop;
    public float shootingrate;
    private float shootcd = 0f;
    public float vida = 5;
    private bool death = false;


    void Start()
    {

        rbmob = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawntiro = GetComponent<Transform>();
        mob = GetComponent<Transform>();

    }

    void Update()
    {
        if (shootcd > 0)
        {
            shootcd -= Time.deltaTime;
        }
        if (vida < 6)
        {
            anim.SetBool("shieldanim", false);
        }
        Fire();
    }

    void Fire()
    {
        if (shootcd <= 0f)
        {
            var clone = Instantiate(tiro, spawntiro.position, Quaternion.identity) as GameObject;
            clone.transform.localScale = this.transform.localScale;
            shootcd = shootingrate;
        }
    }


    void spawn()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "tiro")
        {
            vida--;
            if (vida == 0)
            {
                anim.SetBool("death", true);
                Destroy(gameObject, 1f);
                spawn();
            }
        }
    }


}
