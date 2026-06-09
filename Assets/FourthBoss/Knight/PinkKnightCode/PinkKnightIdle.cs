using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKnightIdle : PinkNightStateMechine
{
    public PinkKnightIdle(string name, PinkKnightSwitcher pinkKnightSwitcher) : base(name, pinkKnightSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if(PinkKnight.instance.FindPlayer())
        {
            pinkKnightSwitcher1.ChangeState(PinkKnight.instance.pinkKnightMove);
        }
        else if(PinkKnight.instance.RunSphere())
        {
              pinkKnightSwitcher1.ChangeState(PinkKnight.instance.pinkKinghtRun);
        }
        else if(PinkKnight.instance.InAttackSphere())
        {
              pinkKnightSwitcher1.ChangeState(PinkKnight.instance.pinkKnightAttack);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
