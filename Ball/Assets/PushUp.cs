using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushUp : MonoBehaviour
{
    private Rigidbody rb;
    public bool push;
    public float force = 50000;
    public float num;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //StartCoroutine("Push");
        InvokeRepeating("UpShoot", 5, 5);
    }

    void UpShoot()
    {
        rb.AddForce(0, force, 0);
    }
    private IEnumerator Push()
    {
        yield return StartCoroutine(One());
        yield return StartCoroutine(Two());
        //yield return StartCoroutine(Three());
    }

    IEnumerator One()
    {
        Debug.Log("1");
        
        yield return new WaitForSeconds(3f);
    }
    IEnumerator Two()
    {
        Debug.Log("2");
        rb.AddForce(0, 50000, 0);
        yield return null;
    }
    /*IEnumerator Three()
    {
        
        yield return null;
    }*/



    // Update is called once per frame
    void Update()
    {
        if (push)
        {
            num = 5;
        } else
        {
            num = 0;
        }
        //rb.AddForce(0, 10000 * num, 0);
    }
}
