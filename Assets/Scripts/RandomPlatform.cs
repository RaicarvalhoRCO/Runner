using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatform : MonoBehaviour
{


    public GameObject Platform;

    private GameObject clone;
    public Transform spawnPos;
    public Transform spawnPos2;
    public Transform spawnPos3;
    public Transform spawnPos4;

    private float spawncd = 10f;
    private float Pos;

    void Start()
    {

    }


    void Update()
    {
        spawncd -= Time.deltaTime;
        Pos = Random.Range(0.0f, 4.0f);
        if (spawncd <= 0)
        {
            spawn();
            spawncd = 5f;
        }
        DestroyObject(clone, 2f);
    }

    void spawn()
    {
        if (Pos <= 1)
        {
            clone = Instantiate(Platform, spawnPos.transform.position, Quaternion.identity) as GameObject;
        }

        else if (Pos <= 2 && Pos > 1)
        {
            clone = Instantiate(Platform, spawnPos2.transform.position, Quaternion.identity) as GameObject;
        }

        else if (Pos <= 3 && Pos > 2)
        {
            clone = Instantiate(Platform, spawnPos3.transform.position, Quaternion.identity) as GameObject;
        }

        else if (Pos <= 4 && Pos > 3)
        {
            clone = Instantiate(Platform, spawnPos4.transform.position, Quaternion.identity) as GameObject;
        }

    }
}