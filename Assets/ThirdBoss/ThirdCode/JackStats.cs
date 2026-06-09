using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackStats : ActorStats
{
    
    public static JackStats instance;
    public void Awake()
    {
        if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }
    }
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
