using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossStats : ActorStats,Isave
{
   private bool isalive=true;
   [SerializeField] GameObject canvas;
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
        {isalive=false;
        if(!isalive)
            {
                  SaveMager.instance.SaveGame();
                   Switchscence.instance.gameObject.SetActive(true);
            Switchscence.instance.SwitchCurrentSecene();
            Destroy(gameObject,0.5f);
            Destroy(canvas);
            }
         
        }
      
        
    }

  

    public override int MagicDamge(ActorStats Targets)
    {
        return base.MagicDamge(Targets);
    }


    public override void Start()
    {
        base.Start();
         SaveMager.instance.EveryLevel();
        
    }
    public void Awake()
    {
       
        currentHP=HP.GetValue();
    }

    public void LoadData(GameData gameData)
    {
      isalive=gameData.secondBossHP;
         if(!isalive)
        {
            Switchscence.instance.gameObject.SetActive(true);
            Switchscence.instance.SwitchCurrentSecene();
            Destroy(gameObject,0.5f);
            Destroy(canvas);
        }
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.secondBossHP=isalive;
    }
 
}
