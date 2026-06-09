using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGodStats : ActorStats,Isave
{
   
   public static DeathGodStats instance;
    [SerializeField]  public List<Itemdata> BossDrop;
    [SerializeField] GameObject itemFromBossPrefab;
    private bool hasdead=false;
    private bool isdie=false;
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
            SaveMager.instance.EveryLevel();
          
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
            isdie=true;
            if(isdie)
            {
                SaveMager.instance.SaveGame();
                 Switchscence.instance.gameObject.SetActive(true);
            Switchscence.instance.SwitchCurrentSecene();
         
          
              for(int i=0;i<BossDrop.Count;i++)
            {
             GameObject newone=Instantiate(itemFromBossPrefab,this.transform.position,Quaternion.identity);
             newone.GetComponent<ItemObject>().SetIcon(BossDrop[i]);
            }
          
              Destroy(gameObject,2f);
            }
           

        }
      
        
    }

    public void LoadData(GameData gameData)
    {
        this.currentHP=(int)gameData.fistBosscurrentHP;
        isdie=gameData.fistbossisdie;
        if(isdie)
        {
              Switchscence.instance.gameObject.SetActive(true);
            Switchscence.instance.SwitchCurrentSecene();
         
          
          
          
              Destroy(gameObject,2f);
        }
       
      
    }

    public override int MagicDamge(ActorStats Targets)
    {
        return base.MagicDamge(Targets);
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.fistBosscurrentHP=this.currentHP;
        gameData.fistbossisdie=this.isdie;
    }

    public override void Start()
    {
        base.Start();
        
    }
  
}
