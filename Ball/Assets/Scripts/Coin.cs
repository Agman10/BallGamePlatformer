using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickup
{
    public CoinManager coinManager;

    public override void OnPickup()
    {
        base.OnPickup();
        if(coinManager != null)
        {
            coinManager.AddCoins(1);
        }
    }
}
