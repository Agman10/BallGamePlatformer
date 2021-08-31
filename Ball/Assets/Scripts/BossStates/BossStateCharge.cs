using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateCharge : AIBaseState
{
    public override void EnterState(BossEnemyAI ai)
    {
        //Debug.Log("charge");
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


        //rhis away commentadet code is to make it  so the boss will charge at player when player is in front

        /*//float angel = Vector3.Angle(ai.target.forward, ai.transform.position - ai.target.position);
        float angel = Vector3.Angle(ai.transform.forward, ai.transform.position - ai.target.position);
        if (Mathf.Abs(angel) > 135)
        {
            ai.navigator.angularSpeed = 0;
            ai.navigator.speed = 0.1f;
            Debug.Log("yes");
            ai.rb.velocity = ai.transform.forward * 1000 * Time.deltaTime;
        }
        else
        {
            ai.navigator.speed = 5f;
            ai.navigator.angularSpeed = 500;
        }*/
        ai.rb.velocity = ai.transform.forward * 1000 * Time.deltaTime;

        //Debug.Log(Vector3.Distance(ai.transform.position, ai.target.position));

        if (Vector3.Distance(ai.transform.position, ai.target.position) > ai.closeRange)
        {
            //Debug.Log("chase end");
            //ai.ChangeState(new BossStateIdle());
            ai.ChangeState(ai.idleState);
            //return idleState;
        }
    }
}
