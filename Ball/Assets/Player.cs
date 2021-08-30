using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool alive = true;
    public Rigidbody rb;
    public SphereCollider sphereCollider;
    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Knockback(Vector3 direction, float strength)
    {
        rb.AddForce(direction * strength);
    }
}
