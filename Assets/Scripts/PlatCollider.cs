using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatCollider : MonoBehaviour {


    public Collider2D Platform;
    private Collider2D Platformactive;
    public float downtime = 0.5f;

    void Start ()
    {
        Platformactive = GetComponent<Collider2D>();
        Platform.enabled = false;
        Platformactive.enabled = true;
    }

    private void Update()
    {
        downtime -= Time.deltaTime;
        if(downtime <=0)
        {
            Platformactive.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Platform.enabled = true;
            Platformactive.enabled = false;
            
        }
       
    }

    public void Downcol()
    {
        if(Platform.enabled)
        {
            Platform.enabled = false;
            downtime = 0.5f;
            
        }
       
    }

}
