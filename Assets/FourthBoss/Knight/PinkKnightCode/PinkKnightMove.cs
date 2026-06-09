using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKnightMove : PinkNightStateMechine
{
   public PinkKnightMove(string name, PinkKnightSwitcher pinkKnightSwitcher) : base(name, pinkKnightSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        rb.velocity=new Vector2(1.2f*PinkKnight.instance.facedir,rb.velocity.y);
        if(PinkKnight.instance.RunSphere())
        {
              pinkKnightSwitcher1.ChangeState(PinkKnight.instance.pinkKinghtRun);
        }
    
    }
    public override void Exit()
    {
        base.Exit();
    }
}
