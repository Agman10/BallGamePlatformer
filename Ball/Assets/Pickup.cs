using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPickup();
        }
    }

    public virtual void OnPickup()
    {
        Destroy(gameObject, 0);
    }
}
