using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenStats :ActorStats
{
   

   

   
   public void Awake()
    {
        currentHP=HP.GetValue();
    }
  
    public override void CalculateFinalDamge(ActorStats targets)

    {
    
   base.CalculateFinalDamge(targets);
  
    }
    public override void EnjoyDamge(int Damage)
    {
        
        base.EnjoyDamge(Damage);
       
    }
}
