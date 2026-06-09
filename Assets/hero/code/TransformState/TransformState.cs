using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformState : PlayerState
{
    
   
private float timer=1.2f;


   
    public TransformState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        
        
         
    }
    public override void Update()
    {

      timer-=Time.deltaTime;
            
        if(timer<0)
        {
            playerStateSwitcher1.ChangeState(Player.instance.giantIdelState);
        }
       
       

       
        
        base.Update();
    }
    public override void Exit()
    {
      
        base.Exit();
    }
}
