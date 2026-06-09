using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ActorStats,Isave
{
    public static PlayerStats instance;
    private bool hasdied=false;
    
    public  void Awake()
    {
        
      
        if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }
        currentHP=HP.GetValue();
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
            if(currentHP==0)
        {
            Player.instance.playerStateSwitcher.ChangeState(Player.instance.dieState);
        }
      
        
    }

    public void LoadData(GameData gameData)
    {
        currentHP=gameData.playerHP;
     

    }

    public override int MagicDamge(ActorStats Targets)
    {
        return base.MagicDamge(Targets);
    }

    public void SaveData(ref GameData gameData)
    {
       gameData.playerHP=currentHP;
    
    }

    public override void Start()
    {
        base.Start();
        SaveMager.instance.EveryLevel();
      
    }
    public  void Update()
    {
        if(currentHP<=0&&!hasdied)
        {
            Player.instance.playerStateSwitcher.ChangeState(Player.instance.dieState);
            currentHP=0;
        
            hasdied=true;
        }
        else if(currentHP>0)
        {
            currentHP=HP.GetValue();
            hasdied=false;
        }

    }
    
}
