using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realBossStatemechine 
{
  public string Amname;
  public realBossSwitcher realBossSwitcher;
  public realBoss realBoss1;
  public Animator am;
  public Rigidbody2D rb;
  public realBossStats realBossStats;
  public realBossStatemechine(string name,realBossSwitcher realBossSwitcher,realBoss realBoss)
    {
        Amname=name;
    this.realBossSwitcher=realBossSwitcher;
    realBoss1=realBoss;
       am=realBoss1.GetComponentInChildren<Animator>();
        rb=realBoss1.GetComponent<Rigidbody2D>();
        realBossStats=realBoss1.GetComponent<realBossStats>();
    }
    public virtual void Enter()
    {
       
        am.SetBool(Amname,true);
    }
    public virtual void Update()
    {
        if(realBossStats.currentHP==0)
        {
            realBossSwitcher.ChangeState(realBoss1.realBossDieState);
            return;
        }
        realBoss1.CharacterFlip();
        realBoss1.FindPlayer();
        realBoss1.InAttackSphere();
        
    }
    public virtual void Exit()
    {
        am.SetBool(Amname,false);
    }
}
