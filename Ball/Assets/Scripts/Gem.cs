using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Pickup
{
    public GameObject gemUI;
    public GameManager gameManager;
    public bool secretGem;

    public override void OnPickup()
    {
        base.OnPickup();
        if (gemUI != null)
        {
            gemUI.SetActive(true);
        }
        if (gameManager != null)
        {
            gameManager.GemCollected(secretGem);
        }
    }
}
