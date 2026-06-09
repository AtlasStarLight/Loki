using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkManIdle : PinkManStateMechine
{
  
    public PinkManIdle(string name, PinkManSwitcher pinkManSwitcher) : base(name, pinkManSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
        rb.gravityScale=1f;
      
    }
    public override void Update()
    {
       

        base.Update();
        if(canJump)
        {
            return;
        }
         if(canrest)
        {
            return;
        }
        
     
        
             if(PinkMan.instance.FindPlayer()&&!PinkMan.instance.InAttackSphere()&&PinkMan.instance.isGround)
            {
                 float distance=Player.instance.transform.position.x-PinkMan.instance.transform.position.x;
        float absdistance=Mathf.Abs(distance);
                pinkManSwitcher.ChangeState(PinkMan.instance.pinkManMove);
                
            }
              else if (PinkMan.instance.InAttackSphere()&&PinkMan.instance.isGround)
        {
            pinkManSwitcher.ChangeState(PinkMan.instance.pinkManAttack);

        }
       
      
        
        
    }
    public override void Exit()
    {
        base.Exit();
    }
}
