using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossMagic : SixthBossStateMechine
{
    public static bool isSixthMagic;
    private float lastTime;
    public SixthBossMagic(string name, SixthBossStateSwitcher sixthBossStateSwitcher) : base(name, sixthBossStateSwitcher)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isSixthMagic=true;
        lastTime=5f;
    }
    public override void Update()
    {
        base.Update();
        lastTime-=Time.deltaTime;
        if(lastTime<0)
        {
            if(SixthBossOfCrowKnight.instance.FindPlayer()&&!SixthBossOfCrowKnight.instance.InAttackSphere())

            {
                sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossMove);
            }
            else if(SixthBossOfCrowKnight.instance.InAttackSphere())
            {
                sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossAttack);
            }
        }
    }
    public override void Exit()
    {
        isSixthMagic=false;
        base.Exit();
    }
}
