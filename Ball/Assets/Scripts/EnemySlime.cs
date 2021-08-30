using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 40f * Time.deltaTime);
    }
}
