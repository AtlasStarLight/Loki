using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossAttack : SixthBossStateMechine
{
    public SixthBossAttack(string name, SixthBossStateSwitcher sixthBossStateSwitcher) : base(name, sixthBossStateSwitcher)
    {
    }

     public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        
        base.Update();
      
        rb.velocity=new Vector2(-SixthBossOfCrowKnight.instance.facedir*0.2f,0);
        if(!SixthBossOfCrowKnight.instance.InAttackSphere()&&SixthBossOfCrowKnight.instance.FindPlayer())
        {
            sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossMove);
        }
        else if(!SixthBossOfCrowKnight.instance.InAttackSphere()&&!SixthBossOfCrowKnight.instance.FindPlayer())
        {
            sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossIdle);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
