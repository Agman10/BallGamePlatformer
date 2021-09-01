using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpin : MonoBehaviour
{
    //private Rigidbody rb;
    public float spinSpeed, zSpeed, xSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xSpeed, spinSpeed, xSpeed));
    }
}
