using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCobtrol : CommonUse
{
    public  float XInput;
        public Rigidbody2D rb;
    public Animator am;
    [SerializeField] LayerMask players;
   
   

    public void Awake()
    {
        
      
        rb=GetComponent<Rigidbody2D>();
        am=GetComponentInChildren<Animator>();
    
    }
    public void Start()
    {
       
    }
      public override void CharacterFlip()
    {
        if(XInput>0&&!faceRight||XInput<0&&faceRight)
        {
            Flip();
            facedir=facedir*(-1);
        }
    

    }
    public void UseThis()
    {
        CloseAllAM();
        am.SetBool("isIdle",true);
    }
    public override void Update()
    {
        
        isWall=Physics2D.Raycast(Wall.position,Vector2.right*facedir,wallANDgroundDistance,WallANDGround);
        isGround=Physics2D.Raycast(Ground.position,Vector2.down,wallANDgroundDistance,WallANDGround);
      FindPlayer();
     
       
    }
    public override void Flip()
    {
        this.transform.Rotate(0,180,0);
        faceRight=!faceRight;
    }

  public  override void OnDrawGizmos()
    {
        Gizmos.DrawLine(Wall.position,new Vector3(Wall.position.x+wallANDgroundDistance*facedir,Wall.position.y));
        Gizmos.DrawLine(Ground.position,new Vector3(Ground.position.x,Ground.position.y+wallANDgroundDistance*-1));
        Gizmos.DrawWireSphere(attackCircle.position,CircleRadius);
        
    }
    public override void HavingDamge()
    {
        
    }
public void CloseAllAM()
    {
        am.SetBool("isIdle",false);
        am.SetBool("isRun",false);
        am.SetBool("isAttack",false);
        am.SetBool("isDie",false);
        am.SetBool("isHit",false);
        am.SetBool("isDensive",false);
    }
  public void FindPlayer()
    {
        Collider2D player =Physics2D.OverlapCircle(this.transform.position,CircleRadius,players);
        if(player!=null)
        {
            float distance=player.transform.position.x-this.transform.position.x;
            XInput=-distance;
            if(Mathf.Abs(distance)>1)
            {
                float c=Random.Range(0,2);
                CloseAllAM();
                am.SetBool("isRun",true);
                rb.velocity=new Vector2(1.2f*distance*c,rb.velocity.y);
                 CharacterFlip();
            }
            else
            {
                rb.velocity=new Vector2(0,0);
                CloseAllAM();
                am.SetBool("isAttack",true);

            }
    
        }
        else
        {
            CloseAllAM();
            am.SetBool("isIdle",true);
        }
    }
    
}
