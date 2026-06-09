using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInkManStats : ActorStats
{
    public static PInkManStats instance;
    [SerializeField] List<Itemdata> BossDrop;
    [SerializeField] GameObject ItemFromBossprefab;
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
                 for(int i=0;i<BossDrop.Count;i++)
            {
             GameObject newone=Instantiate(ItemFromBossprefab,this.transform.position,Quaternion.identity);
             newone.GetComponent<ItemObject>().SetIcon(BossDrop[i]);
            }
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
