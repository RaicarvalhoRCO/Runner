using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


    public GameObject mob1;
    public GameObject mob2;
    public GameObject mob3;
    public GameObject mob4;
    private GameObject clone;
    public Transform spawnPos;
    public Transform spawnPos2;

    private float spawncd = 5f;
    private float qual;

	void Start ()
    {
        
    }
	
	
	void Update ()
    {
        spawncd -= Time.deltaTime;
        qual = Random.Range(0.0f, 4.0f);
        if (spawncd <= 0)
        {            
            spawn();
            spawncd = 5f;
        }
    }

    void spawn()
    {
        if(qual <= 1)
        {
            clone = Instantiate(mob1, spawnPos.transform.position, Quaternion.identity) as GameObject;
        }

        else if (qual <= 2 && qual > 1)
        {
            clone = Instantiate(mob2, spawnPos.transform.position, Quaternion.identity) as GameObject;
        }

        else if(qual <= 3 && qual > 2)
        {
            clone = Instantiate(mob3, spawnPos.transform.position, Quaternion.identity) as GameObject;
        }

        else if (qual <= 4 && qual > 3)
        {            
            clone = Instantiate(mob4, spawnPos2.transform.position, Quaternion.identity) as GameObject;
        }

    }
}
