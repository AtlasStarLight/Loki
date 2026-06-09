using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MagicControl
{
    private float timer;
 Rigidbody2D rb=>GetComponent<Rigidbody2D>();
    Animator am=>GetComponent<Animator>();
    [SerializeField] float blustRadius;
    [SerializeField] LayerMask enemy;
    private bool hasGiveDamge=false;
    private float blustTimer=1f;

public void UseThis()
    {
        timer=5f;
        rb.velocity=new Vector2(2f*Player.instance.facedir,1);

    }
           public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.gameObject.transform.position,blustRadius);
    }
    public void Update()
    {
        timer-=Time.deltaTime;
        if(FindEnemy())
        {
            blustTimer-=Time.deltaTime;
            if(blustTimer<0)
            {
                am.SetBool("isBlust",true);
            Collider2D[] all=Physics2D.OverlapCircleAll(gameObject.transform.position,blustRadius,enemy);
            foreach(var hit in all)
            {
                if(hit==null)
                {
                    return;
                }
                else
                {
                    if(!hasGiveDamge)
                    {
                       hit.GetComponent<ActorStats>().currentHP-=500;
                       hasGiveDamge=true; 
                    }
                       
                }
            }

              
             
            }
          

             
            //不能在写伤害函数还是去那段动画里写稳当一点。
            Destroy(gameObject,2.3f);
        }
        if(!FindEnemy())
        {
            if(timer<0)
            {
                am.SetBool("isBlust",true);
            
            Destroy(gameObject,1f);
            }
           
        }

        
    }
    public bool FindEnemy()
    {
        Collider2D[] all=Physics2D.OverlapCircleAll(this.transform.position,blustRadius);
        if(all.Length>0)
        {
            
         return true;

        }
        else
        {
            return false;
        }
    }
}
