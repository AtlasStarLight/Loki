using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realBossMoveState : realBossStatemechine
{
    public realBossMoveState(string name, realBossSwitcher realBossSwitcher, realBoss realBoss) : base(name, realBossSwitcher, realBoss)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if(realBoss1.FindPlayer())
        {
            rb.velocity=new Vector2(realBoss1.Xinput*2f,rb.velocity.y);
        }
        if(realBoss1.InAttackSphere())
        {
            realBossSwitcher.ChangeState(realBoss1.realBossAttackState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
