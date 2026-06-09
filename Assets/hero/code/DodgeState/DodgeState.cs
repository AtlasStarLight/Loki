using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : PlayerState
{
    private float timer;
    public static bool isdodge;

    public DodgeState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
        
    }
    public override void Enter()
    {
        timer=0.5f;
 base.Enter();
        isdodge=true;
    
       
    }
  
    public override void Update()
    {
        base.Update();
       
         rb.velocity=new Vector2(2*Player.instance.facedir,0);
        timer-=Time.deltaTime;
        if(timer<=0)
        {
       
                    playerStateSwitcher1.ChangeState(Player.instance.idelState);
        }
       
    }  public override void Exit()
    {
        DodgeSkill.couldDodge=false;
        base.Exit();
           isdodge=false;
      
    }

}
