using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGodStateMechine 
{
   protected Rigidbody2D rb=>DeathGod.instance.rb;
   protected Animator am=>DeathGod.instance.am;
   public string AnimationName;
   public DeathGodStateSwither deathGodStateSwither1;
   public DeathGodStateMechine(string name, DeathGodStateSwither deathGodStateSwither)
    {
        AnimationName=name;
        deathGodStateSwither1=deathGodStateSwither;

        
    }
   public  virtual void Enter()
    {
        am.SetBool(AnimationName,true);
        
    }
    public virtual void Update()
    {

        
        
    }
    public virtual void Exit()
    {
        am.SetBool(AnimationName,false);
    }

}
