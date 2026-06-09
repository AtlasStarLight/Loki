using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkManJump : PinkManStateMechine
{
   private float holdtimer;
   public static bool isinJump;
    public PinkManJump(string name, PinkManSwitcher pinkManSwitcher) : base(name, pinkManSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
     
         holdtimer=0.3f;
rb.velocity=new Vector2(PinkMan.instance.facedir*1.5f,8f);

     isinJump=true;

      
    }
    public override void Update()
    {
       
        base.Update();
      
         if(!PinkMan.instance.isGround)
        {
            rb.gravityScale+=Time.deltaTime;
             holdtimer-=Time.deltaTime;
       
       if(holdtimer<0)
            {
                   pinkManSwitcher.ChangeState(PinkMan.instance.pinkManAir);
            }
       
            return;
        }
      
        
       
        
        
    }
    public override void Exit()
    {

      base.Exit();
    }
}
