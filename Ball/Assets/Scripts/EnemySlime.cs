using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject model;
    public float speed;

    public int directionID;
    public Vector3 direction;
    public float range;
    public float friction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 xzVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        //rb.velocity = direction * speed * Time.deltaTime;
        rb.AddForce(direction * speed * Time.deltaTime - (xzVelocity * friction * Time.deltaTime));
        //rb.AddForce(-(xzVelocity * friction * Time.deltaTime));
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 0)
        {
            direction.x = -direction.x;
            direction.z = -direction.z;
            //Debug.Log("Collision");
            /*if(direction.x == 1)
            {
                direction.x = -1;
            }
            else if(direction.x == -1)
            {
                direction.x = 1;
            }
            
            if(direction.z == 1)
            {
                direction.z = -1;
            }
            else if (direction.z == -1)
            {
                direction.z = 1;
            }*/


        }
    }
}
