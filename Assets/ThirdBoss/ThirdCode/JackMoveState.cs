using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackMoveState : JackStateMechine
{
    public JackMoveState(string name, JackStateSwitcher jackStateSwitcher) : base(name, jackStateSwitcher)
    {
    }

    public override void Enter()
    {
        base.Enter();
       
    }
    public override void Update()
    {
        base.Update();
    rb.velocity=new Vector2(JackOfthird.instance.Xinput*1f,rb.velocity.y);
        if(!JackOfthird.instance.FindPlayer())
        {
            jackStateSwitcher1.ChangeState(JackOfthird.instance.jackIdleState);
        }
        if(JackOfthird.instance.InAttackSphere())
        {
            jackStateSwitcher1.ChangeState(JackOfthird.instance.jackAttackState);
        }
        
    }
    public override void Exit()
    {
        base.Exit();
    }
}
