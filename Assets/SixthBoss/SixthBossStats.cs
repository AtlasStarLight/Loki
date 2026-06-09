using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossStats :ActorStats,Isave
{
    public static SixthBossStats instance;
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
        if(currentHP<=0)
        {
            Destroy(gameObject);
        }
      
        
    }

    public void LoadData(GameData gameData)
    {
      currentHP=gameData.sixth;
      if(currentHP<=0)
        {
            Destroy(gameObject);
        }
    }

    public override int MagicDamge(ActorStats Targets)
    {
        return base.MagicDamge(Targets);
    }

    public void SaveData(ref GameData gameData)
    {
     gameData.sixth=currentHP;
    }

    public override void Start()
    {
        base.Start();
        SaveMager.instance.EveryLevel();
        
    }
   
}
