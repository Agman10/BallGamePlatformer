using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public GameObject target;
    public float xOffset, yOffset, zOffset;
    public bool notSun;

    void Update()
    {
        if (target != null)
        {
            if (notSun)
            {
                transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) + new Vector3(xOffset, yOffset, zOffset);
            }
            else
            {
                transform.position = new Vector3(target.transform.position.x, yOffset, target.transform.position.z) + new Vector3(xOffset, 0, zOffset);
            }
            
        }
    }
}
