using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Vector3 CenterOfMass3;
    public bool Awake;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.centerOfMass = CenterOfMass3;
        //rb.WakeUp();
        Awake = !rb.IsSleeping();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * CenterOfMass3, 1f);
    }
}
