using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;



public class SkillManger : MonoBehaviour,Isave
{
    public int moneyyouHave;
    private int moneylimeted=10000;
    public static SkillManger instance;
    public GiantSkill giantSkill;
    public CloneSkill cloneSkill;
    public DodgeSkill dodgeSkill;
    public MagicSkill magicSkill;
    public PartnerSkill partnerSkill;
    public BaggerSkill baggerSkill;

public bool Usemoney(int money)
    {
        if(moneyyouHave<money)
        {
            return false;
        }
        else
        {
            moneyyouHave-=money;
            return true;
        }
    }


   public void Awake()
    {
        if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
             DontDestroyOnLoad(gameObject);
        }
    

    }
    public void Start()
    {
        giantSkill=GetComponent<GiantSkill>();
        cloneSkill=GetComponent<CloneSkill>();
        dodgeSkill=GetComponent<DodgeSkill>();
        magicSkill=GetComponent<MagicSkill>();
        partnerSkill=GetComponent<PartnerSkill>();
        baggerSkill=GetComponent<BaggerSkill>();
    }

    public void LoadData(GameData gameData)
    {
      moneyyouHave=gameData.money;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.money=moneyyouHave;
    }
}
