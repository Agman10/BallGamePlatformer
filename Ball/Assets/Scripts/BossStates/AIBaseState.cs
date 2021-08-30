using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBaseState
{

    public abstract void Update(BossEnemyAI ai);
    //public abstract AIBaseState Update(BossEnemyAI ai);
    public abstract void EnterState(BossEnemyAI ai);
}
