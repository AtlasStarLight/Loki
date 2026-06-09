using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkNightStateMechine 
{
    [Header("dash")]
    public static float DashTimer=20f;
    public static bool isDash;
   public string AmName;
   public Animator am=PinkKnight.instance.am;
   public Rigidbody2D rb=PinkKnight.instance.rb;
   public PinkKnightSwitcher pinkKnightSwitcher1;
   public PinkNightStateMechine(string name,PinkKnightSwitcher pinkKnightSwitcher)
    {
        AmName=name;
     pinkKnightSwitcher1=pinkKnightSwitcher;
    }
   public virtual void Enter()
    {
        am.SetBool(AmName,true);
        
    }
    public virtual void Update()
    {
        DashTimer-=Time.deltaTime;
        PinkKnight.instance.FindPlayer();
        PinkKnight.instance.InAttackSphere();
        PinkKnight.instance.RunSphere();
        PinkKnight.instance.CharacterFlip();
        if(DashTimer<0&&!isDash)
        {
            pinkKnightSwitcher1.ChangeState(PinkKnight.instance.pinkKnightDash);
            isDash=true;
            DashTimer=20f;
            return;
        }

    }
    public virtual void Exit()
    {
        am.SetBool(AmName,false);
    }
}
