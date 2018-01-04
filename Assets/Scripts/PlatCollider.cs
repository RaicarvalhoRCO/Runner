using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatCollider : MonoBehaviour {


    public GameObject Platform;

    void Start ()
    {
        Platform.GetComponent<Collider2D>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Platform.GetComponent<Collider2D>().enabled = true;
        }
    }
}
