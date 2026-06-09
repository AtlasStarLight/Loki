using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class JumpState : PlayerState
{
    public static bool isJump;
    public JumpState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
        rb.velocity=new Vector2(rb.velocity.x,5);

    }
    public override void Update()
    {
        
        base.Update();
        isJump=true;
       
      if(rb.velocity.y==0)
        {
            playerStateSwitcher1.ChangeState(Player.instance.idelState);
        }
  
      

    }
    public override void Exit()
    {
        isJump=false;
        base.Exit();
    }

   
}
