using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realBossDieState : realBossStatemechine
{
    public static bool IsThirdRealBossisDie;
    public realBossDieState(string name, realBossSwitcher realBossSwitcher, realBoss realBoss) : base(name, realBossSwitcher, realBoss)
    {
    }

    public override void Enter()
    {
        base.Enter();
        IsThirdRealBossisDie=true;
    }
    public override void Update()
    {
        base.Update();
        Object.Destroy(realBoss1.gameObject);
    }
    public override void Exit()
    {
        base.Exit();
        IsThirdRealBossisDie=false;
    }
}
