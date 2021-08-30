using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Pickup
{
    public GameObject starUI;
    public GameManager gameManager;

    public override void OnPickup()
    {
        base.OnPickup();
        if (starUI != null)
        {
            starUI.SetActive(true);
        }
        if (gameManager != null)
        {
            gameManager.collectedStar = true;
        }
    }
}
