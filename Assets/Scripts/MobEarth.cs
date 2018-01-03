using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobEarth : MonoBehaviour
{
    private Animator anim;
    public GameObject HPdrop;
    public GameObject ENdrop;
    private GameObject clone;
    private Transform mob;
    private Transform SpawnPos;
    public GameObject Boulder;
    private Rigidbody2D rbmob;
    public Vector2 speed;

    private float spd = -1f;
    private float incamera = 1f;
    private float drop;
    public float shootingrate;
    private float shootcd = 0f;
    public float vida = 5;
    private bool death = false;

    void Start()
    {

        rbmob = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SpawnPos = GetComponent<Transform>();
        mob = GetComponent<Transform>();

    }

    void Update()
    {
        speed = new Vector2(spd, 0);
        rbmob.velocity = speed;
        incamera -= Time.deltaTime;
        if (shootcd > 0)
        {
            shootcd -= Time.deltaTime;
        }
        if(incamera <= 0)
        {
            spd = 0;
        }
        //BoulderThrow();
    }

    void BoulderThrow()
    {
        if (shootcd <= 0f)
        {
            var clone = Instantiate(Boulder, SpawnPos.position, Quaternion.identity) as GameObject;
            
            shootcd = shootingrate;
        }
    }

    void Wall()
    {
        if (shootcd <= 0f)
        {
            var clone = Instantiate(Boulder, SpawnPos.position, Quaternion.identity) as GameObject;
            clone.transform.localScale = this.transform.localScale;
            shootcd = shootingrate;
        }
    }



    void spawn()
    {
        drop = Random.Range(0.0f, 2.0f);
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
                death = true;
                anim.SetBool("death", death);
                Destroy(gameObject, 1f);
                spawn();
            }
        }
    }
}
