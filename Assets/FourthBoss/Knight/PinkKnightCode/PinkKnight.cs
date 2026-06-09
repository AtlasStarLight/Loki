using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKnight : MonoBehaviour
{
public static PinkKnight instance;

   
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

     [SerializeField] Transform Runsphere;
     [SerializeField] float RunRadius;

    [Header("flip")]
    public bool faceRight=true;
    public int facedir=1;
  [SerializeField] public float Xinput;
  public PinkKinghtRun pinkKinghtRun;
  public PinkKnightAttack pinkKnightAttack;
  public PinkKnightDash pinkKnightDash;
  public PinkKnightIdle pinkKnightIdle;
  public PinkKnightMove pinkKnightMove;
  public PinkKnightSwitcher pinkKnightSwitcher;

  
    

    
    

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
        pinkKnightSwitcher=new PinkKnightSwitcher();
pinkKinghtRun=new PinkKinghtRun("isRun",pinkKnightSwitcher);
pinkKnightAttack =new PinkKnightAttack("isAttack",pinkKnightSwitcher);
pinkKnightDash=new PinkKnightDash("isDash",pinkKnightSwitcher);
pinkKnightIdle=new PinkKnightIdle("isIdle",pinkKnightSwitcher);
pinkKnightMove =new PinkKnightMove("isMove",pinkKnightSwitcher);
    
      
        
    
    }
    public void Start()
    {
     
        pinkKnightSwitcher.AtFistState(pinkKnightIdle);
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
     
       
        
        isWall=Physics2D.Raycast(Wall.position,Vector2.right*facedir,wallANDgroundDistance,WallANDGround);
        isGround=Physics2D.Raycast(Ground.position,Vector2.down,wallANDgroundDistance,WallANDGround);
        pinkKnightSwitcher.currentState.Update();
     
  
       
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
        Gizmos.DrawWireSphere(Runsphere.position,RunRadius);
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
        if(players==null)
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
    public bool RunSphere()
    {
        Collider2D players=Physics2D.OverlapCircle(Runsphere.position,RunRadius,isplayerinthis);
        if(players==null)
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
 
}
