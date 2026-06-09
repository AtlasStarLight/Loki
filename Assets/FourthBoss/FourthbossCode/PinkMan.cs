using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PinkMan : MonoBehaviour
{
   public static PinkMan instance;
   public static float JumpTimer=10f;
   
    public Rigidbody2D rb=>GetComponent<Rigidbody2D>();
    public Animator am=>GetComponentInChildren<Animator>();
   [Header("check wall and ground")]
    public  bool isWall;
    public   bool isGround;
    [SerializeField] protected LayerMask WallANDGround;
     
     [Header(" Drawing Wall and ground  and attack sphere")]
     [SerializeField] protected  float wallANDgroundDistance;
     [SerializeField] protected  Transform Wall;
     [SerializeField] protected Transform Ground;
     [SerializeField] protected Transform CheckPlayerCircle;
     [SerializeField]  protected float CircleRadius;
     [SerializeField] LayerMask isplayerinthis;
     [SerializeField] Transform attackwindow;
     [SerializeField] float attackradius;
     [SerializeField] Transform bossJump;
     [SerializeField] float JumpRadius;
    [Header("flip")]
    public bool faceRight=true;
    public int facedir=1;
  [SerializeField] public float Xinput;
    public float speed;
    public PinkManSwitcher pinkManSwitcher;
    public PinkManIdle pinkManIdle;
    public PinkManAttack pinkManAttack;
    public PinkManJump pinkManJump;
    public PinkManMove pinkManMove;
    public PinkManRoar pinkManRoar;
    public PinkManAir pinkManAir;
    

    
    

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

        pinkManSwitcher=new PinkManSwitcher();
        pinkManIdle=new PinkManIdle("isIdle",pinkManSwitcher);
        pinkManAttack=new PinkManAttack("isAttack",pinkManSwitcher);
        pinkManJump =new PinkManJump("isJumpUP",pinkManSwitcher);
        pinkManMove =new PinkManMove("isMove",pinkManSwitcher);
        pinkManRoar=new PinkManRoar("isRoar",pinkManSwitcher);
        pinkManAir=new PinkManAir("isJumpDown",pinkManSwitcher);

      
        
    
    }
    public void Start()
    {
        pinkManSwitcher.AtFirstState(pinkManIdle);
        
    }
            public virtual void CharacterFlip()
    {
        if(Xinput>0&&!faceRight||Xinput<0&&faceRight)
        {
            Flip();
            facedir=facedir*(-1);
        }
    

    }
    public virtual void Update()
    {
         JumpTimer-=Time.deltaTime;
       
        
        isWall=Physics2D.Raycast(Wall.position,Vector2.right*facedir,wallANDgroundDistance,WallANDGround);
        isGround=Physics2D.Raycast(Ground.position,Vector2.down,wallANDgroundDistance,WallANDGround);
        pinkManSwitcher.currentstate.Update();
  
       
    }
    public virtual void Flip()
    {
        this.transform.Rotate(0,180,0);
        faceRight=!faceRight;
    }

  public  virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(Wall.position,new Vector3(Wall.position.x+wallANDgroundDistance*facedir,Wall.position.y));
        Gizmos.DrawLine(Ground.position,new Vector3(Ground.position.x,Ground.position.y+wallANDgroundDistance*-1));
        Gizmos.DrawWireSphere(CheckPlayerCircle.position,CircleRadius);
        Gizmos.DrawWireSphere(attackwindow.position,attackradius);
        Gizmos.DrawWireSphere(bossJump.position,JumpRadius);
    }
   public bool FindPlayer()
    {
    Collider2D player=Physics2D.OverlapCircle(CheckPlayerCircle.position,CircleRadius,isplayerinthis);
    if(player==null)
        {
            return false;
        }
        else
        {
            float distance=Player.instance.transform.position.x-transform.position.x;
            Xinput=distance;
        
            if(distance>0)
            {
                facedir=1;
            }
            else
            {
                facedir=-1;
            }
            return true;
        }
    }
    public bool InAttackSphere()
    {
        Collider2D players=Physics2D.OverlapCircle(attackwindow.position,attackradius,isplayerinthis);
        if(players!=null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool BossShouldJump()
    {
           Collider2D players=Physics2D.OverlapCircle(bossJump.position,JumpRadius,isplayerinthis);
           if(players!=null)
        {
             float distance=Player.instance.transform.position.x-transform.position.x;
             Xinput=distance;
           if(distance>0)
            {
                facedir=1;
            }
            else
            {
                facedir=-1;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
