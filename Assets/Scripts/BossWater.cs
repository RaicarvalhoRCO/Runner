using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWater : MonoBehaviour
{
    private player player;
    private Animator anim;
    private GameObject clone;
    private Transform mob;
    private Transform ShotSpawn;
    private Transform ShotSpawn2;
    public GameObject Shot;
    private Rigidbody2D rbmob;


    private float drop;
    public float shootingrate;
    public float shootcd;
    public float vida = 5f;
    private bool death = false;
    private float bubles = 0;


    void Start()
    {

        rbmob = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ShotSpawn = GetComponent<Transform>();
        mob = GetComponent<Transform>();

    }

    void Update()
    {
        if (shootcd > 0)
        {
            shootcd -= Time.deltaTime;
        }
        
        Fire();
    }

    void Fire()
    {
        if (shootcd <= 0f)
        {
            while(bubles<6)
            {
                var clone = Instantiate(Shot, ShotSpawn.position, Quaternion.identity) as GameObject;
                clone.transform.localScale = this.transform.localScale;
                bubles++;
            }
            bubles = 0f;
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
