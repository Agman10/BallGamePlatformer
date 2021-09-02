using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : Pickup
{
    public LifeManager lifeManager;
    public override void OnPickup()
    {
        base.OnPickup();
        if (lifeManager != null)
        {
            lifeManager.ChangeLives(1);
        }
    }
}
