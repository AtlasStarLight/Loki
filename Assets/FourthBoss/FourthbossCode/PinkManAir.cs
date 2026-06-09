using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkManAir : PinkManStateMechine
{
    private float suspendtimer;
    private Vector2  targetPos;
    public PinkManAir(string name, PinkManSwitcher pinkManSwitcher) : base(name, pinkManSwitcher)
    {
    }
    public override void Enter()
    {
       

            am.SetBool("isJumpDown",true);

        suspendtimer=0.1f;
       am.speed=0;
       rb.velocity=Vector2.zero;
       rb.gravityScale=0;
          targetPos = Player.instance.transform.position;



    }
    public override void Update()
    {
      
        suspendtimer-=Time.deltaTime;
        if(suspendtimer<0)
        {
            am.speed=1;
            rb.gravityScale=10f;
            

            
           
            Vector2 dir = (targetPos - (Vector2)PinkMan.instance.transform.position).normalized;
rb.velocity = dir * 15f;
 if(PinkMan.instance.isGround)
            {
                  pinkManSwitcher.ChangeState(PinkMan.instance.pinkManIdle);
            }
   
        }
        
        base.Update();
    }
    public override void Exit()
    {
       
        base.Exit();
        PinkManJump.isinJump=false;
    }
}
