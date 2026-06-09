using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossOfCrowKnight : MonoBehaviour
{
    public static SixthBossOfCrowKnight instance;
   public static float JumpTimer=10f;

   
    public Rigidbody2D rb;
    public Animator am;
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
  [SerializeField] public float Xinput;
    public float speed;
    public SixthBossStateSwitcher sixthBossStateSwitcher;
    public SixthBossIdle sixthBossIdle;
    public SixthBossMove sixthBossMove;
    public SixthBossAttack sixthBossAttack;
    public SixthBossDefensive sixthBossDefensive;
    public SixthBossDodge sixthBossDodge;
    public SixthBossMagic sixthBossMagic;
 
    

    
    

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
        rb=GetComponent<Rigidbody2D>();
       am =GetComponentInChildren<Animator>();

      
      sixthBossStateSwitcher=new SixthBossStateSwitcher();
      sixthBossIdle=new SixthBossIdle("isIdle" ,sixthBossStateSwitcher);
      sixthBossAttack=new SixthBossAttack("isAttack",sixthBossStateSwitcher);
      sixthBossDefensive=new SixthBossDefensive("isDefensive",sixthBossStateSwitcher);
      sixthBossDodge=new SixthBossDodge("isDodge",sixthBossStateSwitcher);
      sixthBossMagic=new SixthBossMagic("isMagic",sixthBossStateSwitcher);
      sixthBossMove=new SixthBossMove("isMove",sixthBossStateSwitcher);
        
    
    }
    public void Start()
    {
        
        sixthBossStateSwitcher.AtFistState(sixthBossIdle);
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
   
  sixthBossStateSwitcher.currentstate.Update();
       
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
   
}
