using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGiveDamgeToAllBoss : MonoBehaviour
{
    private bool isAttackWindow;
    private bool hasAttack=false;
    [SerializeField]LayerMask Allenemies;
    public void OpenAttackWindow()
    {
        isAttackWindow=true;
    }
    public void CloseAttackWindow()
    {
        isAttackWindow=false;
        hasAttack=false;

    }
    public void PlayerGiveDamgeToEnemies()
    {
    Collider2D[] enemies=Physics2D.OverlapCircleAll(Player.instance.attackCircle.position,Player.instance.CircleRadius,Allenemies);
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
    
 public void Update()
    {
        if(isAttackWindow&&!hasAttack)
        {
            PlayerGiveDamgeToEnemies();
           
        }
    }
}
