using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKnightStats : ActorStats
{
   public override void CalculateFinalDamge(ActorStats targets)
    {
        base.CalculateFinalDamge(targets);
    }
    public override int CalculatingCriticalDamage()
    {
        return base.CalculatingCriticalDamage();
    }
    public override void EnjoyDamge(int Damage)
    {
        base.EnjoyDamge(Damage);
        if(currentHP<=0)
        {
            Destroy(gameObject,0.5f);
        }
      
        
    }
    public override int MagicDamge(ActorStats Targets)
    {
        return base.MagicDamge(Targets);
    }
    public override void Start()
    {
        base.Start();
        
    }
}
