using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateCharge : AIBaseState
{
    public override void EnterState(BossEnemyAI ai)
    {
        Debug.Log("charge");
        ai.navigator.speed = 0.1f;
        ai.navigator.acceleration = 100f;
        ai.navigator.angularSpeed = 0;


        /*ai.navigator.speed = 50f;
        ai.navigator.acceleration = 100f;
        ai.navigator.angularSpeed = 0;*/
    }

    public override void Update(BossEnemyAI ai)
    {
        //ai.rb.velocity = ai.transform.forward * ai.speed * Time.deltaTime;
        ai.Move();
        ai.rb.velocity = ai.transform.forward * 1000 * Time.deltaTime;
        Debug.Log(Vector3.Distance(ai.transform.position, ai.target.position));
        
        if (Vector3.Distance(ai.transform.position, ai.target.position) > ai.closeRange)
        {
            Debug.Log("chase end");
            //ai.ChangeState(new BossStateIdle());
            ai.ChangeState(ai.idleState);
            //return idleState;
        }
    }
}
