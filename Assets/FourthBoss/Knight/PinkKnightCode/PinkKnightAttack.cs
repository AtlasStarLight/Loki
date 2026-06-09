using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PinkKnightAttack : PinkNightStateMechine
{
    public static bool isInPinkKnightAttack;
    public static bool PinkKnightPrefectDodge;
            public PinkKnightAttack(string name, PinkKnightSwitcher pinkKnightSwitcher) : base(name, pinkKnightSwitcher)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isInPinkKnightAttack=true;
        if(isInPinkKnightAttack)
        {
              int a=Random.Range(0,3);
                  am.SetInteger("Attack",a);

  
        }
      
   
        
    }
    public override void Update()
    {
        base.Update();
        if(DodgeState.isdodge&&PinkKnight.instance.InAttackSphere())
        {
            PinkKnightPrefectDodge=true;
        }
        else
        {
            PinkKnightPrefectDodge=false;
        }
        if(!PinkKnight.instance.InAttackSphere())
        {
            pinkKnightSwitcher1.ChangeState(PinkKnight.instance.pinkKinghtRun);
        }
   
    }
    public override void Exit()
    {
        base.Exit();
        isInPinkKnightAttack=false;
    }
}
