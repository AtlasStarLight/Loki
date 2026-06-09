using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelState :PlayerState
{
    public IdelState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if(Xinput!=0&&!isGiant)
        {
             if(JumpState.isJump||AttackState.isAttack)
        {
            return;
        }
            playerStateSwitcher1.ChangeState(Player.instance.movingState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
    
}
