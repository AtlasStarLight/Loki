using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sixthBlackHoleControl : MonoBehaviour
{
    public Animator am;
    [SerializeField] Transform thisone;
    [SerializeField] float holeradius;
    [SerializeField] LayerMask isplayer;
    private float holetime=5f;
    private bool canusethis=false;
    private bool canstart=false;
    private bool hasGicedamge=false;
   
    public void Awake()
    {
        am=GetComponent<Animator>();
    }
    public void CloseAllAM()
    {
        am.SetBool("isIdle",false);
        am.SetBool("isBackHole",false);
    }
    public void UseThis()
    {
        canusethis=true;
    }
public  void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(thisone.position,holeradius);
    }
    public void FindPlayerInHole()
    {
        Collider2D players=Physics2D.OverlapCircle(thisone.position,holeradius,isplayer);
        if(players!=null)
        {
            CloseAllAM();
              am.SetBool("isBackHole",true);
              canstart=true;

            Vector2 Dir=(Vector2)(this.transform.position-Player.instance.transform.position).normalized;
           
            Player.instance.rb.velocity+=20f*Dir*Time.deltaTime;
            //give damge
            Debug.Log("this for giving damge");
            if(!hasGicedamge)
            {
                PlayerStats.instance.currentHP-=350;
                hasGicedamge=true;
            }

        }
        
    }
    public void Update()
    {
        if(canusethis)
        {
              FindPlayerInHole();
      if(canstart)
        {
            holetime-=Time.deltaTime;
            if(holetime<0)
            {
               
                Destroy(gameObject);
            }
        }
        }
      
    }
}
