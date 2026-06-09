using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackOfthird : MonoBehaviour
{
    public static JackOfthird instance;
    public JackStateSwitcher jackStateSwitcher2;
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
     
    [Header("flip")]
    public bool faceRight=true;
    public int facedir=1;
   public float Xinput;
    public float speed;
    public JackIdleState jackIdleState;
    public JackMoveState jackMoveState;
    public JackAttackState jackAttackState;
    public jackDieState jackDieState;

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
        jackStateSwitcher2 =new JackStateSwitcher();
        jackIdleState =new JackIdleState("isIdle",jackStateSwitcher2);
        jackMoveState =new JackMoveState("isMoving",jackStateSwitcher2);
        jackAttackState =new JackAttackState("isAttack",jackStateSwitcher2);
        jackDieState =new jackDieState("isIdle",jackStateSwitcher2);
    }
    public void Start()
    {
        jackStateSwitcher2.AtFirstState(jackIdleState);
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
      jackStateSwitcher2.currentstate.Update();
       
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
}
