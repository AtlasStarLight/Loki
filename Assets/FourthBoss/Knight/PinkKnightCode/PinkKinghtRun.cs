using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKinghtRun : PinkNightStateMechine
{
    public PinkKinghtRun(string name, PinkKnightSwitcher pinkKnightSwitcher) : base(name, pinkKnightSwitcher)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        rb.velocity=new Vector2(2.5f*PinkKnight.instance.facedir,rb.velocity.y);
        if(PinkKnight.instance.InAttackSphere())
        {
            pinkKnightSwitcher1.ChangeState(PinkKnight.instance.pinkKnightAttack);
        }
       
    }
    public override void Exit()
    {
        base.Exit();
    }
}
