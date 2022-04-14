using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampaMover : MonoBehaviour {

    private float speed;
    private Vector3 pointA;
    private Vector3 pointB;
    private float fraction = 0;
    private int nroRandom;
    private bool empezo;


    void Start()
    {
        pointA = new Vector3(-6.0f, transform.position.y, transform.position.z);
        pointB = new Vector3(6.0f, transform.position.y, transform.position.z);
        nroRandom = Random.Range(0, 2);
        print(nroRandom);
        speed = Random.Range(0f, 1f);
    }

    void Update()
    {
        if(nroRandom == 0)
        {
            if(empezo == false)
            {
                if (fraction < 1)
                {
                    fraction += Time.deltaTime*speed;
                    transform.position = Vector3.Lerp(pointA, pointB, fraction);
                }
                if (fraction >= 1)
                {
                    nroRandom = 1;
                    fraction = 0;
                    empezo = true;
                }
            }
            else
            {
                if (fraction < 1)
                {
                    fraction += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(pointA, pointB, fraction);
                }
                if (fraction >= 1)
                {
                    nroRandom = 1;
                    fraction = 0;
                }
            }

        }
        if (nroRandom == 1)
        {
            if (empezo == false)
            {
                if (fraction < 1)
                {
                    fraction += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(pointB, pointA, fraction);
                }
                if (fraction >= 1)
                {
                    nroRandom = 0;
                    fraction = 0;
                    empezo = true;
                }
            }
            else
            {
                if (fraction < 1)
                {
                    fraction += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(pointB, pointA, fraction);
                }
                if (fraction >= 1)
                {
                    nroRandom = 0;
                    fraction = 0;
                }
            }
        }
    }
}
