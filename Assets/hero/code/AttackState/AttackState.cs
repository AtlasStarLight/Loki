using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    private float timer;
    public static bool isAttack;
    private bool hasAttack;
    private bool usemagic;
    private float cuttime;
    
    
    public AttackState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
        timer=0.6f;
 isAttack=true;
 hasAttack=false;
 musicctorl.instance.PlayerSFX(2);
 usemagic=false;
 cuttime=0.3f;

    }
    public override void Update()
    {
     

        rb.velocity = new Vector2(Player.instance.facedir*1.2f, rb.velocity.y);
       
         if(MagicSkill.couldMagicAttack&&!usemagic)
        {
        
            SkillManger.instance.magicSkill.StartSkill();
            usemagic=true;
            if(usemagic)
            {
                cuttime-=Time.deltaTime;
                if(cuttime<=0)
                {
                      playerStateSwitcher1.ChangeState(Player.instance.idelState);
                }
            }

            
            
        
            return;

        }
        if(!hasAttack)
        {
                  PlayerGiveDamgeToEnemies();
                  hasAttack=true;
        }
        timer-=Time.deltaTime;
       
        if(timer<0)
        {
            playerStateSwitcher1.ChangeState(Player.instance.idelState);
        }


        base.Update();
    }
    public override void Exit()
    {
        musicctorl.instance.CloseSFX();
        isAttack=false;
        base.Exit();
    }
 public void PlayerGiveDamgeToEnemies()
    {
    Collider2D[] enemies=Physics2D.OverlapCircleAll(Player.instance.attackCircle.position,Player.instance.CircleRadius,Player.instance.allenemis);
       foreach(var hit in enemies)
        {
            ActorStats thisstats=hit.GetComponent<ActorStats>();
            if(thisstats==null)
            {
                Debug.Log("is null");
                return;
            }
            if(thisstats!=null)
            {
                 PlayerStats.instance.CalculateFinalDamge(thisstats);
                  hasAttack=true;
            }
           
        }

    }
}
