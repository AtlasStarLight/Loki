using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class SixthBossStateMechine
{
    [Header("rest time")]
    public static float sixthresttimer=15f;
    public static bool sixhasrest=false;
    [Header("magic time")]
    public static float magicTimer=30f;
    [Header("dodge to player position")]
    public static float dodgeTimer=5f;
    public static bool sixthCandodge=false;
   
    public static bool dodgetrigger=false;
    [Header("Prefect Defensive")]
    public static float defensivetimer=10f;
    public static bool canDefensive=false;
    public static float durationtime=2f;
    public static  bool DefensiveTrigger=false;
    

    public Rigidbody2D rb=SixthBossOfCrowKnight.instance.rb;
    public Animator am=SixthBossOfCrowKnight.instance.am;
    public string name;
    public SixthBossStateSwitcher sixthBossStateSwitcher1;
    public SixthBossStateMechine(string name,SixthBossStateSwitcher sixthBossStateSwitcher)
    {
        this.name=name;
        sixthBossStateSwitcher1=sixthBossStateSwitcher;
        
        
    }
  public virtual void Enter()
    {
        am.SetBool(name,true);
    }
    public virtual void Update()
    {
        defensivetimer-=Time.deltaTime;
        dodgeTimer-=Time.deltaTime;
        magicTimer-=Time.deltaTime;
    sixthresttimer-=Time.deltaTime;
        SixthBossOfCrowKnight.instance.FindPlayer();
        SixthBossOfCrowKnight.instance.InAttackSphere();
        SixthBossOfCrowKnight.instance.CharacterFlip();
        float distance=Player.instance.transform.position.x-SixthBossOfCrowKnight.instance.transform.position.x;
        float absdistance=Mathf.Abs(distance);
        if(sixthresttimer<0&&!sixhasrest)
        {
             sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossIdle);
             sixhasrest=true;
             return;
        }
        if(defensivetimer<0&&absdistance<5f)
        {
            canDefensive=true;

            
        }
        if(canDefensive)
        { 
            if(canDefensive&&!DefensiveTrigger)
            {
                    sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossDefensive);
                    DefensiveTrigger=true;
            }
        
       durationtime-=Time.deltaTime;
       if(durationtime<0)
            {
                canDefensive=false;
                defensivetimer=10f;
                durationtime=2f;
                sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossAttack);
                DefensiveTrigger=false;
                return; 
            }
            return;

        }
        if(dodgeTimer<0&&absdistance>3f)
        {
             sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossDodge);
             dodgeTimer=5f;
             return;
        }
        if(magicTimer<0)
        {
            sixthBossStateSwitcher1.ChageState(SixthBossOfCrowKnight.instance.sixthBossMagic);
            magicTimer=30f;
            return;
        }
     

        
    }
    public virtual void Exit()
    {
        am.SetBool(name,false);
    }
  }
