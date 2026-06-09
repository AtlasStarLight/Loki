using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState
{
    [Header ("goblin attack timer")]
    public static float attacktimer=0;
    private  float attackcolddown=0.5f;
  

    [Header("giant skill cold down")]
    public static  float giantskillcolddowntime=45;
    public static float giantskilltimer=0;
     public  static float GiantDurationTimer=20;
  
     public static bool isGiant;

    [Header("Beg colder")]
    public static float begtimer=0;
    public  static  float begcolddown=1f;

    [Header("idelANDMoving'svLogic")]
    public float Xinput;
    

    public Animator am=>Player.instance.am;
    public Rigidbody2D rb=Player.instance.rb;
    public string Amname;

    
    public PlayerStateSwitcher playerStateSwitcher1;
    public PlayerState(string name,PlayerStateSwitcher playerStateSwitcher)
    {
        Amname=name;
        playerStateSwitcher1=playerStateSwitcher;
    }
    public virtual void Enter()
    {
        am.SetBool(Amname,true);

        
    
    }
    public virtual  void Update()
    {
        CloneSkill.CloneSkillTimer-=Time.deltaTime;
        if(CloneSkill.CloneSkillTimer<0)
        {
            CloneSkill.InColdDown=false;
        }
        PartnerSkill.parterTimer-=Time.deltaTime;
        if(PartnerSkill.parterTimer<0)
        {
            PartnerSkill.InColdDwon=false;
        }
         DodgeSkill.dodgeTimer-=Time.deltaTime;
        if(DodgeSkill.dodgeTimer<0)
        {
            DodgeSkill.InColdDown=false;
        }
       
    attacktimer-=Time.deltaTime;

        giantskilltimer-=Time.deltaTime;
        if(giantskilltimer>0)
        {
             GiantSkill.InColdDown=true;
        }
        else
        {
             GiantSkill.InColdDown=false;
        }
 am.SetFloat("yDir",rb.velocity.y);
        begtimer-=Time.deltaTime;
        if(begtimer<0)
        {
            BaggerSkill.InColdDown=false;
        }
       
        Xinput=Player.instance.Xinput;
        Player.instance.CharacterFlip();
        if(Input.GetKeyDown(KeyCode.F)&&!Player.instance.dieState.isDie&&begtimer<0&&BaggerSkill.couldbagger)
        {
             if(isGiant||JumpState.isJump)
        {
            return;
        }
  BaggerSkill.InColdDown=true;
      
            begtimer=begcolddown;
            playerStateSwitcher1.ChangeState(Player.instance.begState);
        }
        if(Input.GetKeyDown(KeyCode.B)&&!Player.instance.dieState.isDie&&Player.instance.isGround)
        {
             if(isGiant)
        {
            return;
        }

            playerStateSwitcher1.ChangeState(Player.instance.jumpState);
         
        }
        if(Input.GetKeyDown(KeyCode.G)&&!Player.instance.dieState.isDie&&DodgeSkill.couldDodge)
        {
             if(isGiant||JumpState.isJump)
        {
            return;
        }
       
        DodgeSkill. dodgeTimer=DodgeSkill.dodgeClodDown;
         DodgeSkill.InColdDown=true;
            playerStateSwitcher1.ChangeState(Player.instance.dodgeState);
            return;
        }
        if(Input.GetKeyDown(KeyCode.Y)&&!Player.instance.dieState.isDie&&!isGiant&&giantskilltimer<0&&GiantSkill.shouldTransform)
        {
            giantskilltimer=giantskillcolddowntime;
            isGiant=true;
             GiantDurationTimer=20;
            playerStateSwitcher1.ChangeState(Player.instance.transformState);

        }
        if(Input.GetKeyUp(KeyCode.J)&&!isGiant&&!Player.instance.dieState.isDie&&attacktimer<=0)
        {
            attacktimer=attackcolddown;
            playerStateSwitcher1.ChangeState(Player.instance.attackState);
           
        }
         
        if(Input.GetKeyDown(KeyCode.V)&&!isGiant&&!Player.instance.dieState.isDie&&CloneSkill.CanUseCloneSkill&&CloneSkill.CloneSkillTimer<0)
        {
            CloneSkill.CloneSkillTimer=CloneSkill.timercolddown;
            CloneSkill.InColdDown=true;
           
            SkillManger.instance.cloneSkill.StartCloneSkill();
        }
         
            if(Input.GetKeyDown(KeyCode.R)&&PartnerSkill.canuse&&!isGiant&&!Player.instance.dieState.isDie&&PartnerSkill.parterTimer<0)
        {
            PartnerSkill.parterTimer=PartnerSkill.partenercolddown;
            PartnerSkill.InColdDwon=true;
        SkillManger.instance.partnerSkill. SetUpThisSkill();//测试，记得改，放到statemechine里面去。

        }
        if(isGiant==true)
        {
            
            GiantDurationTimer-=Time.deltaTime;
           
           
        }
         if(GiantDurationTimer<=0)
            {
                playerStateSwitcher1.ChangeState(Player.instance.idelState);
                isGiant=false;
                GiantDurationTimer=20f;
               
            }
    }
    public virtual void Exit()
    {
        am.SetBool(Amname,false);
    }
}

