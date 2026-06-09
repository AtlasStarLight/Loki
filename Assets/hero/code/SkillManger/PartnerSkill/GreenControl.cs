using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GreenControl : MonoBehaviour
{
    private float DurationTime=10;
    Animator am=>GetComponent<Animator>();
  [SerializeField] float radius;
    PlayerStats Playerstats;
    [SerializeField] LayerMask enemy;
    Rigidbody2D rb=>GetComponent<Rigidbody2D>();
   
    private bool canAddBlood;
    private  GreenStats thisstats;

public void Start()
    {
        Playerstats=Player.instance.GetComponent<PlayerStats>();
        canAddBlood=false;
        thisstats=GetComponent<GreenStats>();
    }
    public void CloseAllAM()
    {
        am.SetBool("isIdle",false);
        am.SetBool("isAttack",false);
        am.SetBool("isDie",false);

    }
    public void UseThis()
    {
        CloseAllAM();
         am.SetBool("isIdle",true);
     
    
    }
 
    public Transform FindEnemy()
    {
        Transform theClosestOne=null;
        float theClosestEnemy=Mathf.Infinity;
          Collider2D[] enemys=Physics2D.OverlapCircleAll(this.transform.position,radius,enemy);
          foreach(var hit in enemys)
        {
        float theDistance=Vector2.Distance(hit.transform.position,this.transform.position);
         float thefinaldistance=Mathf.Abs(theDistance);
         if(thefinaldistance<theClosestEnemy)
            {
                theClosestEnemy=thefinaldistance;
                theClosestOne=hit.transform;
            }
        }
        return theClosestOne;
    }
    public void GreenFunction( Transform target)
    {
      
        if(target==null)
        {
            CloseAllAM();
            am.SetBool("isIdle",true);

        }
        else
        {
            this.gameObject.transform.position=target.position;
            CloseAllAM();
            am.SetBool("isAttack",true);//写伤害地方


        }
        if(canAddBlood&&this.GetComponent<GreenStats>().currentHP>0)
        {

            canAddBlood=false;
            this.gameObject.transform.position=Player.instance.transform.position+new Vector3(1,0,0);
            Playerstats.currentHP=Playerstats.currentHP+thisstats.currentHP;
            CloseAllAM();
            this.am.SetBool("isDie",true);
            if(Playerstats.currentHP>Playerstats.HP.GetValue())
            {
                Playerstats.currentHP=Playerstats.HP.GetValue();

            }
            Destroy(gameObject,0.5f);
            
        }
        
    }
      public   void OnDrawGizmos()
    {
    Gizmos.DrawWireSphere(this.transform.position,radius);
    }
    public void Update()
    {
        DurationTime-=Time.deltaTime;
        if(DurationTime<=0)
        {
            CloseAllAM();
            am.SetBool("isDie",true);
            Destroy(gameObject,2f);
        }
        else
        {
            if(thisstats.currentHP==0)
        {
            CloseAllAM();
            am.SetBool("isDie",true);
            Destroy(gameObject,1f);
            return;
        }
         if(Playerstats.currentHP<40)
        {
            canAddBlood=true;
        }
       Transform target= FindEnemy();
        GreenFunction(target);
       
        }
       
    }
}
