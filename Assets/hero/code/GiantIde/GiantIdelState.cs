using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantIdelState : PlayerState
{
    public GiantIdelState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void Update()
    {
        base.Update();
        if(Xinput!=0&&isGiant)
        {
            playerStateSwitcher1.ChangeState(Player.instance.giantMoveState);
            
        }
        if(Input.GetKeyDown(KeyCode.J)&&isGiant)
        {
            playerStateSwitcher1.ChangeState(Player.instance.giantAttackState);
        }
        
    }
    public override void Exit()
    {
        base.Exit();
    }

    
}
