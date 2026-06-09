using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

public class BoxMonster :MonoBehaviour
{
   public static BoxMonster instance;
   [SerializeField] Transform thisboxmonster;
   [SerializeField] float BoxMonsterFindplayerRadius;
   [SerializeField] LayerMask isplayer;
   private bool faceright=true;
Animator am=>GetComponentInChildren<Animator>();
   public void Awake()
    {
        if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }
    }
    public void Start()
    {
       gameObject.SetActive(false);

    }
    public void  OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(thisboxmonster.position,BoxMonsterFindplayerRadius);
    }
    public void CloseAllAM()
    {
        am.SetBool("isBox",false);
        am.SetBool("isTrans",false);
    }
    public void ExecutionPlayer()
    {
        Collider2D player=Physics2D.OverlapCircle(this.transform.position,BoxMonsterFindplayerRadius,isplayer);
        if(player!=null)
        {
            this.transform.position=Player.instance.transform.position;
            am.enabled=true;
            ConfirmPosition();
            Player.instance.rb.constraints=RigidbodyConstraints2D.FreezeAll;
              CloseAllAM();
        am.SetBool("isTrans",true);
       
      
    
        }
        else
        {
            am.enabled=false;
            CloseAllAM();
        }
       
        
    }
    public void Die()
    {
         Player.instance.rb.constraints=RigidbodyConstraints2D.None;
        this.gameObject.SetActive(false);
    }
    public void Update()
    {
        ExecutionPlayer();
    }
    public void ConfirmPosition()
    {
    float postion=Player.instance.transform.position.x-this.transform.position.x;
    if(postion<0&&faceright||!faceright&&postion>0)
        {
            Flip();
        }
   
    }
    public void Flip()
    {
        transform.Rotate(0,180,0);
        faceright=!faceright;
    }
}
