using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossDodge :SixthBossStateMechine
{
    public static bool isExchange=false;
    private float dodgedurationtime;
        public SixthBossDodge(string name, SixthBossStateSwitcher sixthBossStateSwitcher) : base(name, sixthBossStateSwitcher)
    {
    }

 public override void Enter()
    {
        base.Enter();
        dodgedurationtime=0.5f;
    }
    public override void Update()
    {
      dodgedurationtime-=Time.deltaTime;
      if(dodgedurationtime<0)
        {
              SixthBossOfCrowKnight.instance.transform.position=Player.instance.transform.position+new Vector3(-0.5f,0,0);
        isExchange=true;
        sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossAttack);
        }
      
        

    }
    public override void Exit()
    {
        isExchange=false;
        base.Exit();
    }
}
