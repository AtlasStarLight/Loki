using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBossAttackState : realBossStatemechine
{
    // Start is called before the first frame update
    public RealBossAttackState(string name, realBossSwitcher realBossSwitcher, realBoss realBoss) : base(name, realBossSwitcher, realBoss)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if(!realBoss1.InAttackSphere())
        {
            realBoss1.realBossSwitcher.ChangeState(realBoss1.realBossMoveState);
        }
     
    }
    public override void Exit()
    {
        base.Exit();
    }
}
