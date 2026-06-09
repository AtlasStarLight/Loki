using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum CloneShowType
{
    die,
    idel,
    beg
}
//如果单纯克隆就太无聊了，换三个形态出来比较有感觉
public class CloneControl : MonoBehaviour
{
    private bool faceright;
    [SerializeField] float CheckDistance;
    [SerializeField] LayerMask enemy;
    Animator am;
    Rigidbody2D rb;
    private bool enemycomein;
    private bool HasTrgger;
  private  CloneShowType cloneShowType;
  Transform enemyss;
    public void Awake()
    {
       am=GetComponent<Animator>();
       rb=GetComponent<Rigidbody2D>();
        enemycomein=false;
       HasTrgger=false;
       faceright=true;
      
    }
    public void CloseAllAM()
    {
                
        am.SetBool("isBeg", false);
am.SetBool("isIdel", false);
am.SetBool("isMoving", false);
am.SetBool("isDie", false);
am.SetBool("isBoom",false);
    }
    public void SetInSkill()
    {
          
      CloseAllAM();
           enemycomein=false;
        HasTrgger=false;
        if(!Player.instance.faceRight)
        {
            this.transform.Rotate(0,180,0);
            faceright=!faceright;
        }
    
    }
// 这个是skill的调用函数，利用这个可以每次都浸入技能都能update只出发一次形态改变。
public void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere(this.transform.position,CheckDistance);
    }
    //确定克隆的检测范围
    public void Update()
    {
        enemyss = FindEnemy();
       if(enemyss==null)
        {
            //Debug.Log("enemy is null");
             cloneShowType=CloneShowType.idel;
            
             enemycomein=false;
        }
        else
        {
          //  Debug.Log("enemy is not null");
            enemycomein=true;
        }
        if(enemycomein==true&&!HasTrgger)
        {
           HasTrgger=true;
           int r=Random.Range(0,3);
           if(r==0)
            {
                 cloneShowType=CloneShowType.beg;
                
            }
            else if(r==1)
            {
                cloneShowType=CloneShowType.die;
            }
            else
            {
                cloneShowType=CloneShowType.idel;
            }
        }
        CloneFuntion(cloneShowType);


        

    }
    public Transform FindEnemy()
    {
        Transform theClosestOne=null;
        float theClosestEnemy=Mathf.Infinity;
          Collider2D[] enemys=Physics2D.OverlapCircleAll(this.transform.position,CheckDistance,enemy);
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
    //找最近的敌人。
    public void CloneFuntion(CloneShowType cloneShowType)
    {
        if(cloneShowType==CloneShowType.beg)
        {
            CloseAllAM();
            am.SetBool("isBeg",true);
            if(Input.GetKeyDown(KeyCode.H))
            {
                Player.instance.transform.position=this.transform.position;
            }
             Destroy(gameObject,4f);
        }
        else if(cloneShowType==CloneShowType.idel)
        {CloseAllAM();
            am.SetBool("isIdel",true);
            if(enemyss!=null)
            {
               // Debug.Log("find enemy");
               CloseAllAM();
              
               float dir1 = enemyss.position.x - transform.position.x;
               am.SetBool("isMoving", true);

            
               Vector2 dir = (enemyss.position - transform.position).normalized;
rb.velocity = dir * 3f;
if(dir1 < 0 &&faceright)
{
    Flip();

}
else if(dir1 > 0 && !faceright)
{
    Flip();
}
               
            float theexposiondistance=Vector2.Distance(this.transform.position,enemyss.transform.position);
            if(theexposiondistance<1)
                {
                     CloseAllAM();
                     am.SetBool("isBoom",true);
                    Destroy(gameObject,0.5f);
                }
                //这写最主要的伤害，其他的都是娱乐技能，搞怪用的，其他不想太扩展了，这样写以后看都不想看。！！（记住伤害在这加就行了）

            }
            else
            {
                Destroy(gameObject,4f);
            }
        }
        else
        {
            CloseAllAM();
            am.SetBool("isDie",true);
             if(Input.GetKeyDown(KeyCode.H))
            {
                Player.instance.transform.position=this.transform.position;
            }
             Destroy(gameObject,4f);
        }
    }
    //这个函数的主要实现，通过找到最近或者没有找到敌人确定播放动画的种类。然后根据播放动画的种类及加细节。目前加伤害的话可能会变很复杂，目前以乐趣为主
    //所以打算只在有敌人然后靠近爆炸就这个伤害就行了。
    void Flip()
{
    
    transform.Rotate(0,180,0);
    faceright=!faceright;
}
}
