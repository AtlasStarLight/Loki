using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realBoss : MonoBehaviour
{

       
    public Rigidbody2D rb=>GetComponent<Rigidbody2D>();
    public Animator am=>GetComponentInChildren<Animator>();

 
     
     [Header(" Drawing Wall and ground  and attack sphere")]

  
     [SerializeField] protected Transform CheckPlayerCircle;
     [SerializeField]  protected float CircleRadius;
     [SerializeField] LayerMask isplayerinthis;
     [SerializeField] Transform attackwindow;
     [SerializeField] float attackradius;
     
    [Header("flip")]
    public bool faceRight=true;
    public int facedir=1;
   public float Xinput;
   public realBossMoveState realBossMoveState;
   public RealBossAttackState  realBossAttackState;
   public realBossSwitcher realBossSwitcher;
   public realBossDieState realBossDieState;


    


public void Awake()
    {
        realBossSwitcher =new realBossSwitcher();
       realBossAttackState =new RealBossAttackState("isAttack",realBossSwitcher,this);
       realBossMoveState =new realBossMoveState("isMoving",realBossSwitcher,this);
       realBossDieState=new realBossDieState("isAttack",realBossSwitcher,this);
    }
    public void Start()
    {
      realBossSwitcher.AtFirstState(realBossMoveState);
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
        
       realBossSwitcher.currentState.Update();
       
    }
    public virtual void Flip()
    {
        this.transform.Rotate(0,180,0);
        faceRight=!faceRight;
    }

  public  virtual void OnDrawGizmos()
    {
       
        Gizmos.DrawWireSphere(CheckPlayerCircle.position,CircleRadius);
        Gizmos.DrawWireSphere(attackwindow.position,attackradius);
    }
   public bool FindPlayer()
    {
  Collider2D players=Physics2D.OverlapCircle(CheckPlayerCircle.position,CircleRadius,isplayerinthis);
  if(players==null)
        {
            return false;
        }
        else
        {
            float distance=Player.instance.transform.position.x-this.transform.position.x;
            Xinput=distance;
           
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
        {return true;}
      
    }
}
