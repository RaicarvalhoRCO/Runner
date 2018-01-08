using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Transform spawntiro;
    public GameObject bubbles;
    public GameObject target;
    public float moveSpeed;
    public float rotationSpeed;
    public float shootcd = 2f;
    private int cd = 0;
    public float shootingrate;
    private float x = 0;
    private float y = 1;

    void Start()
    {
        spawntiro = GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);
        shootcd -= Time.deltaTime;

        if (shootcd == 0f)
        {
            while(cd<9)
            {
                x += 0.2f;
                y -= 0.2f;
                var Direction = Vector3(x, y, 0f);
                var clone = Instantiate(bubbles, Direction, Quaternion.identity) as GameObject;

                cd++;
            }
            
            shootcd = shootingrate;
        }
    }
}
