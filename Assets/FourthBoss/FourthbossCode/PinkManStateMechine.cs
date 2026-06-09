using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkManStateMechine 
{

    public string AmName;
    public static bool canJump=false;
    public  static bool isGround;
    public static bool canrest=false;
    public static float resttimer=10f;
    public static float restDurationtime=0.1f;
    public static bool hastrigger=false;
    public static bool Idletrigger=false;
  
    public Rigidbody2D rb=PinkMan.instance.rb;
    public Animator am=PinkMan.instance.am;
   public PinkManSwitcher pinkManSwitcher;
   public static float ABSdistance;
   public PinkManStateMechine(string name ,PinkManSwitcher pinkManSwitcher)
    {
        AmName=name;
        this.pinkManSwitcher=pinkManSwitcher;
    }
    public virtual void Enter()
    {
        am.SetBool(AmName,true);
    }
    public virtual void Update()
    {

        
          isGround=PinkMan.instance.isGround;
        PinkMan.instance.CharacterFlip();
        PinkMan.instance.FindPlayer();
        PinkMan.instance.InAttackSphere();
        PinkMan.instance.BossShouldJump();
       
        float DDDdistance=Player.instance.transform.position.x-PinkMan.instance.transform.position.x;
        ABSdistance=Mathf.Abs(DDDdistance);
        resttimer-=Time.deltaTime;
        if(resttimer<0&&ABSdistance>3&&isGround&&!canJump&&!hastrigger)
        {
            canrest=true;
            restDurationtime=3f;
            hastrigger=true;
           
        }
         
    if (canrest)
    {
        restDurationtime -= Time.deltaTime;

        if (!Idletrigger)
        {
            pinkManSwitcher.ChangeState(PinkMan.instance.pinkManIdle);
            Idletrigger = true;
            return;
        }

        if (restDurationtime < 0)
        {
            resttimer = 10f;
            canrest = false;
            hastrigger = false;
            Idletrigger = false;
            return; // 关键：休息结束这一帧直接停，不准同帧再跳
        }

        return; // 关键：休息期间别往下走
    }
           
      if(PinkMan.JumpTimer<0&&isGround&&ABSdistance>3&&!canrest)
        {
            canJump=true;
            if(canJump)
            {
                 pinkManSwitcher.ChangeState(PinkMan.instance.pinkManJump);
            PinkMan.JumpTimer=10f;

            canJump=false;
            }
            return;
        
        }
      
      
    }
    public virtual void Exit()
    {
        am.SetBool(AmName,false);
    }
    
}
