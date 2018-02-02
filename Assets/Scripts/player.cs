using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float forcapulo = 200;
    public float velocidade = 1;
    public float distchao = 0.11f;
    public float maxspeed = 5;
    public float Jumptime = 1f;
    public float Bufftime = 1f;
    public float dashforce;

    public LayerMask layermask;
    public statbar HP;
    public statbar energy;

    private float shootingrate = 0.1f;
    private float shootcd = 0f;
    public Transform spawntiro;
    public GameObject Shot;
    public GameObject WaterShot;
    public GameObject FireShot;
    public GameObject EarthShot;
    public GameObject AirShot;



    public AudioClip startsom;
    public AudioClip slidesom;
    private AudioSource source;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private bool Run;
    private float AnimAtkTime;
    private float AnimBuff = 0.1f;
    private float slidetime = 0f;
    private bool Jump = false;
    private bool Grounded = false;
    private bool Atk = false;
    private bool Dmg = false;
    private bool WBuff = false;
    private bool Armor = false;
    private bool ImolationAnim = false;
    private bool Imolation = false;
    public bool Dead = false;

    public AnimatorOverrideController aoc;
    public RuntimeAnimatorController DefaultCountroller;
    public AnimationClip[] waterClips;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent <AudioSource>();

        HP.Init();
        energy.Init();
    }

	void Update ()
    {       
        if (shootcd > 0f)
            shootcd -= Time.deltaTime;

        if (Bufftime > -1f)
        {
            Bufftime -= Time.deltaTime;
        }

        if (slidetime > 0f)
        {
            slidetime -= Time.deltaTime;
        }
        if (AnimAtkTime > 0f)
        {
            AnimAtkTime -= Time.deltaTime;
        }
        if (AnimBuff > 0f)
        {
            AnimBuff -= Time.deltaTime;
        }
        if (Jumptime > 0f)
        {
            Jumptime -= Time.deltaTime;
        }

        if (Bufftime < 0f)
        {
            anim.SetBool("Debuff", true);
            anim.runtimeAnimatorController = DefaultCountroller;
        }

        AplicaFisica();
        Aplicaanmiacao();
        ResetAnim();


    }

    void AplicaFisica()
    {
        Debug.DrawLine(transform.position, transform.position + -transform.up * distchao);
        Grounded = Physics2D.Linecast(transform.position, transform.position + -transform.up * distchao, layermask);

        if (Grounded)
        {
            anim.SetBool("Run", true);
        }

    }

    public void jump()
    {
        Jump = true;
        if (Jump && Grounded)
        { 
            
            rb.AddForce(new Vector2(0, forcapulo));
            Jumptime = 0.5f;
        }
    }

    public void Fire()
    {
        if (shootcd <= 0f)
        {            
                Atk = true;                
                var Shots = Instantiate(Shot, spawntiro.position, Quaternion.identity) as GameObject;
                Shots.transform.localScale = this.transform.localScale;
                shootcd = shootingrate;
                AnimAtkTime = 0.7f;
        }
    }

    public void Dash()
    {
        if(Grounded)
        {
            slidetime = 0.4f;
            anim.SetBool("Dash", true);
            rb.AddForce(new Vector2(0f, dashforce));
        }
        
    }

    void Aplicaanmiacao()
    {
        
        anim.SetBool("Grounded", Grounded);
        anim.SetBool("Atk", Atk);
        anim.SetBool("Dmg", Dmg);
        anim.SetBool("Jump", Jump);

        if (slidetime <= 0f)
        {
            anim.SetBool("Dash", false);
        }


    }
    
    void ResetAnim()
    {


        Dmg = false;
        if (AnimAtkTime <= 0)
        {
            Atk = false;
        }
        if(Jumptime <= 0f)
        {
            Jump = false;
        }
        if(AnimBuff <=0)
        {
            anim.SetBool("W-Buff", false);
        }
        if (Bufftime <= -1f)
        {
            anim.SetBool("Debuff", false);
        }

    }



    public void WaterBuff()
    {       
        Bufftime = 5f;
        AnimBuff = 0.5f;
        anim.SetBool("W-Buff", true);
        anim.runtimeAnimatorController = aoc;
        aoc["Andando"] = waterClips[0];
        aoc["Jump"] = waterClips[1];
        aoc["Atk"] = waterClips[2];
        aoc["Dash"] = waterClips[3];
        aoc["Dmg"] = waterClips[4];
        Shot = WaterShot;
    }

    public void Cure()
    {
        energy.CurrentVal -= 50;
        HP.CurrentVal += 25;
    }

    public void FireBuff()
    {
        Shot = FireShot;        
    }

    public void ImolationBuff()
    {
        energy.CurrentVal -= 50;
        Imolation = true;
        anim.SetBool("ImolationAnim", Imolation);
    }

    public void EarthBuff()
    {
        Shot = EarthShot;     
    }

    public void ArmorBuff()
    {
        Armor = true;
    }

    public void AirBuff()
    {
        Shot = AirShot;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tiromob")
        {
            if(Armor)
            {
                Armor = false;
                HP.CurrentVal -= 7;
                Dmg = true;
            }
            else
            {
                HP.CurrentVal -= 10;
                if(HP.CurrentVal == 0)
                {
                    Dead = true;
                    anim.SetBool("Death", true);
                }
                else Dmg = true;

            }
            
        }

        if (collision.tag == "enemy")
        {
            if (Imolation)
            {
                energy.CurrentVal -= 10;
            }
            else
            {
                HP.CurrentVal -= 10;
                rb.AddForce(new Vector2(-forcapulo, 0));
                Dmg = true;
            }
           
        }

        if (collision.tag == "HPdrop")

        {            
            HP.CurrentVal += 10;           
        }

        if (collision.tag == "ENdrop")

        {            
            energy.CurrentVal += 10;
        }

    }
}