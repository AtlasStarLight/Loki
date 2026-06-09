using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAttack : DeathGodStateMechine
{
    public static float hurttimer;
    public static bool  canhurt=false;
    public static bool prefectdodgeSignal=false;
    public static bool firstTrigger=false;
     Collider2D players;

    public DeathAttack(string name, DeathGodStateSwither deathGodStateSwither) : base(name, deathGodStateSwither)
    {
    }

    public override void Enter()
    {
        base.Enter();
        hurttimer=5f;
         players=Physics2D.OverlapCircle(DeathGod.instance.transform.position,DeathGod.instance.CircleRadius2,DeathGod.instance.isplayers);
        
    }
    public override void Exit()
    {
        base.Exit();
        firstTrigger=false;
        
    }
    public override void Update()
    {
        base.Update();
          
            if(!firstTrigger&&DodgeState.isdodge&&players!=null)
            {
                am.speed=0;
                  prefectdodgeSignal=true;
        
 
               

            }
           
    }

}
