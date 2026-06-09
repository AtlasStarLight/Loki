using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossMove : SixthBossStateMechine
{
    public SixthBossMove(string name, SixthBossStateSwitcher sixthBossStateSwitcher) : base(name, sixthBossStateSwitcher)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
           base.Update();
        rb.velocity=new Vector2(SixthBossOfCrowKnight.instance.facedir*1.7f,rb.velocity.y);
        if(SixthBossOfCrowKnight.instance.InAttackSphere())
        {
            sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossAttack);
        }
     
    }
    public override void Exit()
    {
        base.Exit();
    }
}
