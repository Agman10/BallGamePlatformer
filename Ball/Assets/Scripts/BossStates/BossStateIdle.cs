using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateIdle : AIBaseState
{
    //public BossStateChase chaseState;
    public override void EnterState(BossEnemyAI ai)
    {
        ai.navigator.speed = 3F;
        ai.navigator.acceleration = 100;
        ai.navigator.angularSpeed = 520;

        /*ai.navigator.speed = 1;
        ai.navigator.acceleration = 8;
        ai.navigator.angularSpeed = 120;*/

    }

    public override /*AIBaseState*/ void Update(BossEnemyAI ai)
    {
        ai.RoamAround();
        //Debug.Log("idle");
        if (Vector3.Distance(ai.transform.position, ai.target.position) < ai.sightRange)
        {
            ai.ChangeState(ai.chaseState);
            //return chaseState;
            
        }
        //return this;
    }
}
