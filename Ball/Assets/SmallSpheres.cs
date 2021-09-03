using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpheres : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        float randomXForce = Random.Range(-600f, 600f);
        float randomYForce = Random.Range(-600f, 1000f);
        float randomZForce = Random.Range(-600f, 600f);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(randomXForce, randomYForce, randomZForce);
        //Debug.Log("X: " + randomXForce + " Y: " + randomYForce + " Z: " + randomZForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
