using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpin : MonoBehaviour
{
    //private Rigidbody rb;
    public float spinSpeed, zSpeed, xSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xSpeed, spinSpeed, xSpeed));
    }
}
