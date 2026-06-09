using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGetHurtState : DeathGodStateMechine
{
    public DeathGetHurtState(string name, DeathGodStateSwither deathGodStateSwither) : base(name, deathGodStateSwither)
    {
    }
    public override void Enter()
    {
        base.Enter();
        DeathAttack.canhurt=true;
    
   DeathAttack.hurttimer=5f;
    }
    public override void Update()
    {
        base.Update();
            am.speed=1;
      
               
                DeathAttack.hurttimer-=Time.deltaTime;
               
                if(DeathAttack.hurttimer<0)
                {
                    DeathAttack.prefectdodgeSignal=false;
                  DeathAttack.  canhurt=false;

                }
        
        
        if(DeathAttack.canhurt==false)
        {
            
           
             if(Event.currentStage==2)
            {
                  Event.isSecondAttacking=false;
             Event.ThisIsSceondStage=false;
                 Event.  currentStage = 1;
               Event.   attackrate = 10f;
            }
            else if(Event.currentStage==3)
            {
                 Event.isThirdAttack=false;
             Event.ThisIsThirdStage=false;
             Event.currentStage=1;
             Event.shouldCheck=false;
             Event.disgusieDurationTimer=30f;
             Event.isSecondAttacking = false;
Event.ThisIsSceondStage = false;
Event.attackrate=10f;
            }
             DeathGod.instance.transform.position =new Vector3(-1.77f,8.8f,0);

            
                        DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathIdle);
        }

    }
    public override void Exit()
    {
         base.Exit();
        
       
    
    }
}
