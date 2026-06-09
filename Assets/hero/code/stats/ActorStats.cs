using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats :MonoBehaviour
{
    [Header("magic damge")]
    public  stats sicenceDamage;
  public stats lightDamage;
   public   stats magicDefensive;
    [Header("basic stats")]
   public  int currentHP;
     public stats HP;
   public stats Damage;
  public stats Defensive;
   
  public stats criticalChance;
  
   
   public virtual void Start()
    {
          currentHP=HP.GetValue();
    }
    public virtual int MagicDamge(ActorStats Targets)
    {
        int finalmagicDamage=sicenceDamage.GetValue()+lightDamage.GetValue()-Targets.magicDefensive.GetValue();
        if(finalmagicDamage!=0)
        {
            return finalmagicDamage;
        }
        else
        {
            return 0;
        }
    }
    public virtual void CalculateFinalDamge(ActorStats targets)

    {
    
    int finalDamge=Damage.GetValue()+CalculatingCriticalDamage()-targets.Defensive.GetValue()+MagicDamge(targets);
    int result=Mathf.Max(0,finalDamge);
    targets.EnjoyDamge(result);
  
    }
    public virtual int  CalculatingCriticalDamage()
    {
    float finalCriticalDamge=0;
        if(Random.Range(0,100)<criticalChance.GetValue())
        {
        finalCriticalDamge=Damage.GetValue()*1.2f;
     
        }
      int  FinalCriticalDamge=Mathf.RoundToInt(finalCriticalDamge);
        return FinalCriticalDamge;
        
    }
    public virtual void EnjoyDamge(int Damage)
    {
        currentHP-=Damage;
        if(currentHP<0)
        {
            currentHP=0;

        }
        
       
    }



}
