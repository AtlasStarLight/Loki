using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossSkillmanger : MonoBehaviour
{
  public static FirstBossSkillmanger instance;
  public DeathSummonSkill deathSummonSkill;

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
        deathSummonSkill =GetComponent<DeathSummonSkill>();
    }
    public void Start()
    {
        musicctorl.instance.PlayBGM(1);
    }

}
