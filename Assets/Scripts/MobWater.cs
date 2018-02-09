using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobWater : MonoBehaviour
{
    private player player;
    private Transform drag;
    private Animator anim;
    public GameObject HPdrop;
    public GameObject ENdrop;
    private GameObject clone;
    private Transform mob;
    private Transform spawntiro;
    public GameObject tiro;
    private Rigidbody2D rbmob;
    public Vector2 speed;

    private float incamera = 1f;
    private float spd = -1f;
    private float ifshield;
    private float drop;
    public float shootingrate;
    private float shootcd = 0f;
    public float vida = 5;
    private float startanim;
    private bool death = false;
    private bool shieldanim = false;

    void Start()
    {

        rbmob = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawntiro = GetComponent<Transform>();
        mob = GetComponent<Transform>();
        anim.SetBool("Start", true);
        startanim = 1f;

        shield();

    }

    void Update()
    {
        startanim -= Time.deltaTime;
        if(startanim<=0)
        {
            anim.SetBool("Start", false);
            anim.SetBool("Run", true);
            anim.SetBool("Atk", false);
        }
    
        incamera -= Time.deltaTime;
        if (incamera <= 0)
        {
            spd = 0;
        }
        speed = new Vector2(spd, 0);
        rbmob.velocity = speed;
        if (shootcd > 0)
        {
            shootcd -= Time.deltaTime;
        }
        if (vida < 6)
        {
            
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
            anim.SetBool("Atk", true);
            startanim = 1f;
        }
    }


    void shield()
    {
        ifshield = Random.Range(0.0f, 2.0f);
        if (ifshield <= 1)
        {
            vida++;
            anim.SetBool("shieldanim", true);
        }
    }

    void spawn()
    {
        drop = Random.Range(0.0f, 4.0f);
        if (drop <= 1)
        {
            clone = Instantiate(HPdrop, mob.transform.position, Quaternion.identity) as GameObject;
        }
        if (drop <= 2 && drop > 1)
        {
            clone = Instantiate(ENdrop, mob.transform.position, Quaternion.identity) as GameObject;
        }
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
