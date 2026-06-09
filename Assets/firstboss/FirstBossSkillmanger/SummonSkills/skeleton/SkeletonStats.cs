using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStats : ActorStats
{
   public SkeletonCobtrol skeletonCobtrol=>GetComponent<SkeletonCobtrol>();
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
        skeletonCobtrol.CloseAllAM();
       
       
       if(currentHP<=0)
        {
            skeletonCobtrol.CloseAllAM();
            skeletonCobtrol.am.SetBool("isDie",true);
            Destroy(gameObject);
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
