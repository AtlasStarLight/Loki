using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkManAttack : PinkManStateMechine
{
    public static bool PinkManPrefectDodge=false;

    public PinkManAttack(string name, PinkManSwitcher pinkManSwitcher) : base(name, pinkManSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
         if(canrest)
        {
            return;
        }

       if(canJump)
        {
            return;
        }
          
        if(DodgeState.isdodge&&PinkMan.instance.InAttackSphere()&&ABSdistance<0.5)
        {
            PinkManPrefectDodge=true;

        }
        else
        {
            PinkManPrefectDodge=false;
        }

        if(!PinkMan.instance.InAttackSphere())
        {
            pinkManSwitcher.ChangeState(PinkMan.instance.pinkManMove);
        }
    }
    public override void Exit()
    {
        PinkManPrefectDodge=false;
        base.Exit();
    }
}
