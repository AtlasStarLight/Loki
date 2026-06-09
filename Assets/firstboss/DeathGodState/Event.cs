using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net.NetworkInformation;
using UnityEngine;

public class Event : MonoBehaviour
{
 
    [Header("prefect dodge")]
    private bool isprefect=false;
    public static int currentStage = 0;
    [SerializeField] LayerMask isplayers;
    [SerializeField] LayerMask enemyofskeleton;
    [Header("when player come in")]
    public static float totaljoketimer = 60f;
    public static float joketimer = 10f;
    private bool shoulduseskill = false;
    [Header("deathgod in fight")]
    public static float attackDurationtimer = 1f;
    public static float attackrate = 15f;
    Vector3 curentpostion;
    public static bool isSecondAttacking = false;
    public static bool ThisIsSceondStage = false;



    [Header("disgusie normal men")]
    private bool shoulddisguise = false;
    public static float disgusieDurationTimer = 30f;
   public  Vector3 thecurrentpostion;
    public static bool isThirdAttack = false;
    public static bool ThisIsThirdStage = false;
    public static bool shouldCheck = false;
   
       Vector3 womenpostition;



    [SerializeField] DeathGodStats deathgodBloodControl;

    //一开始玩家进场血量在95%以上，触发第一阶段进入戏弄玩家阶段。
   
    public void Start()
    {
        thecurrentpostion=DeathGod.instance.transform.position;
     womenpostition=new Vector3(-9.4f,-2.45f,0);
    }
    public void FirstStatge()
    {
        currentStage = 1;
        if (Player.instance != null)
        {
            DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathjoke);
        }

        if (totaljoketimer < 10f && !shoulduseskill)
        {
            FirstBossSkillmanger.instance.deathSummonSkill.UseSummon();
            shoulduseskill = true;
        }



    }
    public void SceondStage()
    {
        currentStage = 2;
        ThisIsSceondStage = true;
          curentpostion = DeathGod.instance.transform.position;


        Collider2D skeletons = Physics2D.OverlapCircle(DeathGod.instance.transform.position, DeathGod.instance.CircleRadius1, enemyofskeleton);
        if (skeletons)
        {
          
            DeathGod.instance.transform.position = Player.instance.transform.position + new Vector3(-1, 0, 0);

            DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathAttack);
            isSecondAttacking = true;
            attackDurationtimer = 2f;




        }
        else
        {
            FirstBossSkillmanger.instance.deathSummonSkill.UseSummon();
        }



    }
    public void ThirdStage()
    {
        currentStage = 3;
        ThisIsThirdStage = true;
        disgusieDurationTimer = 30f;
          attackDurationtimer = 2f;


        if (deathgodBloodControl.currentHP < 50)
        {
            shoulddisguise = true;

        }
        else
        {
            shoulddisguise = false;
        }
        if (shoulddisguise)
        {
            int choseToDisguise = Random.Range(1, 4);
            
            if (choseToDisguise == 1)
            {
                DeathGod.instance.transform.position = womenpostition;
                DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathTransformState);



            }
            else if (choseToDisguise == 2)
            {
                DeathGod.instance.transform.position = womenpostition;
                DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathTransformState1);

            }
            else
            {
                DeathGod.instance.transform.position = womenpostition;
                DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathTransformState2);

            }
            shouldCheck = true;



        }
    }


    public void Update()
    {
        if(DeathGodStats.instance.currentHP<=0||DeathGod.instance==null)
        {
            Destroy(gameObject);
            return;
        }
 attackrate -= Time.deltaTime;

        totaljoketimer -= Time.deltaTime;
        joketimer -= Time.deltaTime;
              disgusieDurationTimer-=Time.deltaTime;

        if (joketimer < 0 && totaljoketimer > 0)
        {
            FirstStatge();
            joketimer = 10f;
        }
if (PreFectDodge.isInHitStop || DeathAttack.canhurt) return;
       

        //////////////////////////////////////////////////////////////////////////////////////////第一阶段结束。
        if (totaljoketimer < 0 && currentStage == 1 && !ThisIsSceondStage && attackrate < 0)
        {

            SceondStage();
            attackrate = 10f;


        }
        if (ThisIsSceondStage)
        {

            if (isSecondAttacking)
            {
                attackDurationtimer -= Time.deltaTime;
             
                
                if (attackDurationtimer < 0)
                {
                     
                      

                    if (DeathAttack.prefectdodgeSignal == false)
                    {
                        
                        DeathGod.instance.transform.position = curentpostion;
                        DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathIdle);

                        isSecondAttacking = false;
                           ThisIsSceondStage = false;



                    }
                   
                  
                    
                    if (deathgodBloodControl.currentHP > 50)
                    {
                        currentStage = 1;
                    }
                 
                }
            
             else
                    {
                         if (DeathAttack.prefectdodgeSignal == true&&!PreFectDodge.isInHitStop)
                   
                        DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathGetHurtState);
                    }

            }

        }


        //////////////////////////////////////////////////////////////////////////////////////第二阶段结束.
        if (deathgodBloodControl.currentHP < 50 )
        {
            if (currentStage == 2 && !ThisIsThirdStage && !ThisIsSceondStage&&disgusieDurationTimer<0)
            {

                ThirdStage();

            }
            if (ThisIsThirdStage)
            {
                
                if (shouldCheck)
                {

                    Collider2D isplayer = Physics2D.OverlapCircle(DeathGod.instance.transform.position, DeathGod.instance.CircleRadius2, isplayers);

                    if (isplayer != null&&!isThirdAttack)
                    {
                        DeathGod.instance.transform.position=Player.instance.transform.position+new Vector3(-1,0,0);
                        DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathAttack);
                        isThirdAttack = true;
                      


                     

                    }
                       if (isThirdAttack)
                        {

                            attackDurationtimer -= Time.deltaTime;
                            if (attackDurationtimer < 0)
                            {
                                if(DeathAttack.prefectdodgeSignal==false)
                                {
                                 
                                     DeathGod.instance.transform.position = thecurrentpostion;
                                DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathIdle);
                                isThirdAttack = false;
                               
                                    currentStage = 1;
                                }

                               
                                  
                                  


                            }
                            else
                    {
                         if (DeathAttack.prefectdodgeSignal == true&&!PreFectDodge.isInHitStop)
                        DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathGetHurtState);
                    }
                             

                        }
                        if (disgusieDurationTimer < 0)
                {
                    disgusieDurationTimer-=Time.deltaTime;
                    ThisIsThirdStage = false;
                    currentStage = 1;
                }

                }

            if(disgusieDurationTimer<-10f)
                {
                    disgusieDurationTimer=30f;
                }


            }

        }
    }





}
