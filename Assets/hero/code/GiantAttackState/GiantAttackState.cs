using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantAttackState : PlayerState
{
    public GiantAttackState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }

    public override void Enter()
    {
          base.Enter();
        
    }
   public override void Update()
    {
        base.Update();
        if(Input.GetKeyUp(KeyCode.J)&&isGiant)
        {
            playerStateSwitcher1.ChangeState(Player.instance.giantIdelState);
        }
         
    }
    public override void Exit()
    {
        base.Exit();
    }
}
