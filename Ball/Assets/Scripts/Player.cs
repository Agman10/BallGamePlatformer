using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool alive = true;
    public Rigidbody rb;
    public SphereCollider sphereCollider;
    public MeshRenderer meshRenderer;
    public GameObject skins;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Knockback(Vector3 direction, float strength)
    {
        rb.AddForce(direction * strength);
    }
}
