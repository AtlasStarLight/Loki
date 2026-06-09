using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKnightDash : PinkNightStateMechine
{
    public PinkKnightDash(string name, PinkKnightSwitcher pinkKnightSwitcher) : base(name, pinkKnightSwitcher)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity=new Vector2(5f*PinkKnight.instance.facedir*1,0);
      
    }
    public override void Update()
    {
        base.Update();
        if(rb.velocity.x<=3)
        {
            pinkKnightSwitcher1.ChangeState(PinkKnight.instance.pinkKinghtRun);
        }
          
          
    
    }
    public override void Exit()
    {
        base.Exit();
        isDash=false;
    }
}
