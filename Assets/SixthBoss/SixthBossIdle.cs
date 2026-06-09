using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SixthBossIdle : SixthBossStateMechine
{
    private float restime;
        public SixthBossIdle(string name, SixthBossStateSwitcher sixthBossStateSwitcher) : base(name, sixthBossStateSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
        restime=2f;
    }
    public override void Update()
    {
     
        if(sixhasrest)
        {
            restime-=Time.deltaTime;
           if(restime>0)
            {
                return;
            }

          
        }
           base.Update();
        if(SixthBossOfCrowKnight.instance.FindPlayer())
        {
            sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossMove);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
