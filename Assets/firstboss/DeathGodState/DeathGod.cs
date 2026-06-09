using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGod : CommonUse
{
    public float CircleRadius1;
    public float CircleRadius2;
    public LayerMask isplayers;
    [SerializeField] Transform playerfind;
    public float XInput=3f;
        public Rigidbody2D rb;
    public Animator am;
    public DeathGodStateSwither deathGodStateSwither;
    public  static DeathGod instance;
    public deathIdle deathIdle;
    public DeathAttack deathAttack;
    public Deathjoke deathjoke;
    public Deathmagic deathmagic;
    public DeathMove deathMove;
    public DeathTransformState deathTransformState;
    public DeathTransformState  deathTransformState1;
    public DeathTransformState deathTransformState2;
    public DeathGetHurtState deathGetHurtState;
   

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
        deathGodStateSwither =new DeathGodStateSwither();
        deathIdle =new deathIdle("isIdle",deathGodStateSwither);
        deathAttack= new DeathAttack("isAttack",deathGodStateSwither);
        deathjoke =new Deathjoke("isJoke",deathGodStateSwither);
        deathmagic=new Deathmagic("isMagic",deathGodStateSwither);
        deathMove =new DeathMove("isIdle",deathGodStateSwither);
        deathTransformState =new DeathTransformState("isKid",deathGodStateSwither);
        deathTransformState1=new DeathTransformState("isWomen",deathGodStateSwither);
        deathTransformState2 =new DeathTransformState("isOld",deathGodStateSwither);
        deathGetHurtState=new DeathGetHurtState("isHurt",deathGodStateSwither);
      

        
        

    
    }
    public void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        am=GetComponentInChildren<Animator>();
        deathGodStateSwither.AtFirstState(deathIdle);
           
    }
      public override void CharacterFlip()
    {
        if(XInput>0&&!faceRight||XInput<0&&faceRight)
        {
            Flip();
            facedir=facedir*(-1);
        }
    

    }
    public override void Update()
    {
        
        isWall=Physics2D.Raycast(Wall.position,Vector2.right*facedir,wallANDgroundDistance,WallANDGround);
        isGround=Physics2D.Raycast(Ground.position,Vector2.down,wallANDgroundDistance,WallANDGround);
        deathGodStateSwither.currentState.Update();
    
       
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
        Gizmos.DrawWireSphere(attackCircle.position,CircleRadius1);
           Gizmos.DrawWireSphere(playerfind.position,CircleRadius2);
        
    }
    public override void HavingDamge()
    {
        
    }
}
