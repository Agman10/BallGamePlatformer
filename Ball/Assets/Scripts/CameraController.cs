using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Player player;
    public float xOffset, yOffset, zOffset;

    void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
            transform.LookAt(target.transform.position);
        }
        
        if(player != null && !player.alive)
        {
            target = null;
        }
    }
}
