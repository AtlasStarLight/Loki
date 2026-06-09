using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : CommonUse
{
    
       public PlayerStateSwitcher playerStateSwitcher;
  
    public Rigidbody2D rb;
    public Animator am;
    public IdelState idelState;
    public MovingState movingState;
    public BegState begState;
    public JumpState jumpState;
    public DodgeState dodgeState;
    public TransformState transformState;
   public AttackState attackState;
 public static Player instance;
 public GiantMoveState giantMoveState;
 public GiantAttackState giantAttackState;
 public DieState dieState;
 public GiantIdelState giantIdelState;
 [SerializeField]   public LayerMask allenemis;

 public void Awake()
    {
        
        faceRight=true;
        playerStateSwitcher=new PlayerStateSwitcher();
        if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
           
        }
        else
        {
            instance=this;
             DontDestroyOnLoad(gameObject);
        }
        rb=GetComponent<Rigidbody2D>();
        am=GetComponentInChildren<Animator>();
        idelState=new IdelState("isIdel",playerStateSwitcher);
        movingState =new MovingState("isMoving",playerStateSwitcher);
        begState=new BegState("isBeg",playerStateSwitcher);
        jumpState=new JumpState("isJump",playerStateSwitcher);
        dodgeState=new DodgeState("isDodge",playerStateSwitcher);
        transformState=new TransformState("isTransform",playerStateSwitcher);
        attackState=new AttackState("sAttack",playerStateSwitcher);
        giantMoveState=new GiantMoveState("GiantMove",playerStateSwitcher);
        giantAttackState=new GiantAttackState("Giantattack",playerStateSwitcher);
        dieState=new DieState("isDie",playerStateSwitcher);
        giantIdelState=new GiantIdelState("isGiantIdel",playerStateSwitcher);

        
    }
    public void Start()
    {
        Application.targetFrameRate = 60;
        
   playerStateSwitcher.AtFirstState(idelState);
    }
    public override void Update()
    {
      if(UI.instance.timecolddown)
        {
          rb.velocity=Vector2.zero;
          am.speed=0;
    

            return;
            
            
        }
        else
    {
       rb.velocity=Player.instance.movingState.rb.velocity;
          am.speed=1;
         
    }
        base.Update();
     playerStateSwitcher.currentstate.Update();
      Xinput=Input.GetAxisRaw("Horizontal");
    }
    public override void CharacterFlip()
    {
      base.CharacterFlip();
    
    }
    public override void Flip()
    {
  base.Flip();
    }

  public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
    public override void HavingDamge()
    {
        
    }
}
