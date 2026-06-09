using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackAttackState : JackStateMechine
{
    public JackAttackState(string name, JackStateSwitcher jackStateSwitcher) : base(name, jackStateSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if(!JackOfthird.instance.InAttackSphere())
        {
            jackStateSwitcher1.ChangeState(JackOfthird.instance.jackMoveState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
