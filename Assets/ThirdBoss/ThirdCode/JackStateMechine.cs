using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackStateMechine 
{
    public string AMname;
    public Rigidbody2D rb=JackOfthird.instance.rb;
    public Animator am=JackOfthird.instance.am;
    public JackStateSwitcher jackStateSwitcher1;
    public JackStateMechine(string name, JackStateSwitcher jackStateSwitcher)
    {
        AMname=name;
        jackStateSwitcher1=jackStateSwitcher;

    }

  public virtual void Enter()
    {
      
        am.SetBool(AMname,true);

    }
    public virtual  void Update()
    {
        JackOfthird.instance.CharacterFlip();
        JackOfthird.instance.InAttackSphere();
        JackOfthird.instance.FindPlayer();
    }
    public virtual void Exit()
    {am.SetBool(AMname,false);
        
    }
}
