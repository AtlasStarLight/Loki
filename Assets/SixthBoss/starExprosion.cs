using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starExprosion : MonoBehaviour
{
    private Animator am;
    [SerializeField] Transform damagewindow;
    [SerializeField] float damageRadius;
    [SerializeField] LayerMask isplayers;
    [SerializeField] float deadTime=3f;
    private bool hastrigger=false;
    private bool canstart=false;
    private bool hasGiveDamge=false;
    public void Awake()
    {
        am=GetComponent<Animator>();
    }
    private void OnDrawGizmos()
{
    Gizmos.DrawWireSphere(this.transform.position,damageRadius);
}
   
   private void CloseAllAM()
    {
        am.SetBool("isStar",false);
        am.SetBool("isBlust",false);
    }
    public void UseThis()
    {
        canstart=true;
        hastrigger=false;
    }
    public void GiveDamgeTOPlayer()
    {
        Collider2D players=Physics2D.OverlapCircle(this.transform.position,damageRadius,isplayers);
        if(players!=null)
        {
            // give damge function;
            Debug.Log("I am handsome");
            if(!hasGiveDamge&&!FourthBossPrefectDodge.ThisIsPrefectDodge)
            {
                 PlayerStats.instance.currentHP-=300;
                 hasGiveDamge=true;
            }
           
           
        }

      
    }
    public void Update()
    {
        if(canstart)
        {
             deadTime-=Time.deltaTime;
        if(deadTime<0)
        {
            CloseAllAM();
              am.SetBool("isBlust",true);
              
              GiveDamgeTOPlayer();
     
              Destroy(gameObject,0.5f);

        }
        }
       
    }
 
}
