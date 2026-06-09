using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PinkManMove :PinkManStateMechine
{
    public PinkManMove(string name, PinkManSwitcher pinkManSwitcher) : base(name, pinkManSwitcher)
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
          
        rb.velocity=new Vector2(PinkMan.instance.facedir*1.2f,rb.velocity.y);
        if(!PinkMan.instance.FindPlayer())
        {
            pinkManSwitcher.ChangeState(PinkMan.instance.pinkManIdle);
        }
        if(PinkMan.instance.InAttackSphere())
        {
            pinkManSwitcher.ChangeState(PinkMan.instance.pinkManAttack);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
