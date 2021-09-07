using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpin : MonoBehaviour
{
    //private Rigidbody rb;
    public float spinSpeed, zSpeed, xSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Rotate(new Vector3(xSpeed, spinSpeed, xSpeed));
        transform.Rotate(new Vector3(xSpeed * Time.deltaTime, spinSpeed * Time.deltaTime, xSpeed * Time.deltaTime));
    }
}
