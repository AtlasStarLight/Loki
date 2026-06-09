using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAllBossToplayer : MonoBehaviour
{
 private bool isAttackWindow;
 [SerializeField] Transform attackcircle;
 [SerializeField] LayerMask isplayer;
 [SerializeField] float attackRadius;
 [SerializeField] ActorStats Enemies;
 private bool hasAttacked=false;

public void Awake()
    {
        Enemies=GetComponentInParent<ActorStats>();
    }
 public void OpenAttackWindow()
    {
        isAttackWindow=true;
    }
    public void CloseAttackWindow()
    {
        isAttackWindow=false;
        hasAttacked=false;
    }
    public void GiveDamgeToPlayer()
    {
        // if(BegState.isbeg||FourthBossPrefectDodge.ThisIsPrefectDodge)
        // {return;
        // }
        Collider2D player=Physics2D.OverlapCircle(attackcircle.position,attackRadius,isplayer);
        if(player==null)
        {
            return;
        }
        if(player!=null)
        {
            Enemies.CalculateFinalDamge(PlayerStats.instance);
        }
    }
 
 private void OnDrawGizmos()
{

    Gizmos.DrawWireSphere(attackcircle.position, attackRadius);
}
 public void Update()
    {
        if(isAttackWindow&&!hasAttacked)
        {
            GiveDamgeToPlayer();
            hasAttacked=true;
        }
        
    }

}
