using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossDefensive : SixthBossStateMechine
{
    public SixthBossDefensive(string name, SixthBossStateSwitcher sixthBossStateSwitcher) : base(name, sixthBossStateSwitcher)
    {
    }
     public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
       rb.velocity=new Vector2(SixthBossOfCrowKnight.instance.facedir*1.2f,0);

    }
    public override void Exit()
    {
        base.Exit();
    }
}
