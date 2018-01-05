using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatCollider : MonoBehaviour {


    public Collider2D Platform;

    void Start ()
    {
        Platform.enabled = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Platform.enabled = true;
        }
    }
}
