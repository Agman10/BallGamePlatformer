using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateChase : AIBaseState
{
    //public BossStateIdle idleState;
    public override void EnterState(BossEnemyAI ai)
    {
        /*ai.navigator.speed = 3.5f;
        ai.navigator.acceleration = 8;
        ai.navigator.angularSpeed = 120;*/

        ai.navigator.speed = 5f;
        ai.navigator.acceleration = 100;
        ai.navigator.angularSpeed = 520;
    }

    public override /*AIBaseState*/ void Update(BossEnemyAI ai)
    {
        ai.Move();
        //ai.navigator.speed = 100;
        //Debug.Log("chase");
        if (Vector3.Distance(ai.transform.position, ai.target.position) > ai.sightRange)
        {
            ai.ChangeState(ai.idleState);
            //return idleState;
        }
        if (Vector3.Distance(ai.transform.position, ai.target.position) < ai.closeRange)
        {
            ai.ChangeState(ai.chargeState);
            //return idleState;
        }
        //return this;
    }
}
