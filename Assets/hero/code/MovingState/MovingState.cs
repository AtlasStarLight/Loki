using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlayerState
{
    
     public MovingState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
        musicctorl.instance.PlayerSFX(0);
        
    }
    public override void Update()
    {
       
       
        base.Update();
        rb.velocity=new Vector2(Xinput*Player.instance.speed,rb.velocity.y);
        if(Xinput==0)
        {
            playerStateSwitcher1.ChangeState(Player.instance.idelState);
        }

    }
    public override void Exit()
    {
        musicctorl.instance.CloseSFX();
        base.Exit();
    }
    
}
