using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3[] points;
    private Vector3 currentTarget;
    private int point = 0;

    public float speed = 4;

    public float delayTime;
    private float delayStart;
    public float tolerance;
    public bool automatic;
    
    void Start()
    {
        if(points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }


    void Update()
    {
        if(transform.position != currentTarget)
        {
            MovePlatform();
        } else
        {
            UpdateTarget();
        }
    }

    //moves the platform
    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if(heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart= Time.time;
        }
    }

    //changes the position the platform targets
    void UpdateTarget()
    {
        if (automatic)
        {
            if(Time.time - delayStart > delayTime)
            {
                NextPlatform();
            }
        }
    }

    public void NextPlatform()
    {
        point++;
        if(point >= points.Length)
        {
            point = 0;
        }
        currentTarget = points[point];
    }

    //make the platform parent to the player when it stans on it so it will follow it
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }

    //make it so it's no longet the parent
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
