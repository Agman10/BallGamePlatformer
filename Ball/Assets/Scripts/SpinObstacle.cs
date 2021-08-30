using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObstacle : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;
    public float AngularSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Rotates the obstacle
    void FixedUpdate()
    {
        //Speed = rb.velocity.magnitude;
        AngularSpeed = rb.angularVelocity.magnitude * Mathf.Rad2Deg;
        rb.angularVelocity = new Vector3(0, Mathf.PI * Speed, 0);
    }
}
