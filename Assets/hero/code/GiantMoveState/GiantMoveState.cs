using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantMoveState : PlayerState
{
    public GiantMoveState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }
    public override void Enter()
    {
         base.Enter();
        
    }
    public override void Update()
    {
        base.Update();
        rb.velocity=new Vector2(Xinput,rb.velocity.y);
        if(Xinput==0&&isGiant)
        {
            playerStateSwitcher1.ChangeState(Player.instance.giantIdelState);
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
