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
    public GameObject Wall;
    private Rigidbody2D rbmob;
    public Vector2 speed;

    private float spd = -1f;
    private float incamera = 1f;
    private float drop;
    public float shootingrate;
    private float shootcd = 0f;
    public float vida = 5;
    public float timeanim = 0f;

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
        if (timeanim > 0)
        {
            timeanim -= Time.deltaTime;
        }
        if (incamera <= 0)
        {
            spd = 0;
            
        }
        ResetAnim();
        //WallSpell();
        //BoulderThrow();
    }

    void BoulderThrow()
    {
        if (shootcd <= 0f)
        {
            anim.SetBool("Atk", true);
            var clone = Instantiate(Boulder, SpawnPos.position, Quaternion.identity) as GameObject;
            shootcd = shootingrate;
            timeanim = 1f;
        }
    }

    void WallSpell()
    {
        if (shootcd <= 0f)
        {
            var clone = Instantiate(Wall, SpawnPos.position, Quaternion.identity) as GameObject;

            shootcd = shootingrate;
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


    void ResetAnim()
    {

        if (timeanim <= 0f)
        {
            anim.SetBool("Dmg", false);
            anim.SetBool("Atk", false);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "tiro")
        {
            vida--;
            timeanim = 1f;
            if (vida == 0)
            {
                
                anim.SetBool("Death", true);
                Destroy(gameObject, 1f);
                spawn();
                
            }
            else
                anim.SetBool("Dmg", true);
        }
    }
}
