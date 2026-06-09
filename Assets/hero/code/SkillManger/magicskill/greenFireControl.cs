using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenFireControl : MagicControl
{
 
   [Header("flip")]
  public bool faceright;
    private float timer=3f;
    private bool isstart;
    Rigidbody2D rb=>GetComponent<Rigidbody2D>();
    Animator am=>GetComponent<Animator>();
    SpriteRenderer sr=>GetComponent<SpriteRenderer>();
        [SerializeField] float fireRaduis;
    [SerializeField] LayerMask enemy;
    private bool hasGiveDamge=false;
   public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position,fireRaduis);
    }
    public void Awake()
    {
    isstart=false;
    faceright=true;
    }
   public void UseThis()
    {
           rb.velocity=new Vector2(3.5f*Player.instance.facedir,0);
           GameObjectFlip();
    }
    public void FindEnemy()
    {
        Collider2D[] enemys=Physics2D.OverlapCircleAll(this.transform.position,fireRaduis,enemy);
        foreach(var hit in enemys)
        {

                  if(hit==null)
            {
                return;
            }
            else
            {
                if(!hasGiveDamge)
                {
                    hit.GetComponent<ActorStats>().currentHP-=10;
                    hasGiveDamge=true;
                }
                
            }
            Debug.Log("Give damage");
            //这个给伤害。
           ColorDis();
        }
    }
   
    public void Update()
    {
          timer-=Time.deltaTime;
        
   

        FindEnemy();
        if(timer<0)
        {
            ColorDis();
        }
        

    }
    public void ColorDis()
    {
         float t=0;
        t+=Time.deltaTime;
        if(t<1)
            {
                isstart=true;
            }
            else
            {
                isstart=false;
            }
       if(isstart)
        {
            Color c=sr.color;
            c.a-=t;
            sr.color=c;
            

        }
        if(sr.color.a<=0)
          
            Destroy(gameObject);
    }
  
  
  public void GameObjectFlip()
    {
        if(Player.instance.faceRight&&!faceright)
        {
            FXFlip();
        }
        else if(!Player.instance.faceRight&&faceright)
        {
            FXFlip();
        }
    }
    public void FXFlip()
    {
        this.gameObject.transform.Rotate(0,180,0);
        faceright=!faceright;
    }
  

}
