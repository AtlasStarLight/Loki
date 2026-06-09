using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkManRoar :PinkManStateMechine
{
    public PinkManRoar(string name, PinkManSwitcher pinkManSwitcher) : base(name, pinkManSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if(UseForFourthBoss.skillisdie)
        {
            pinkManSwitcher.ChangeState(PinkMan.instance.pinkManIdle);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
