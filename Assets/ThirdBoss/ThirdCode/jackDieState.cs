using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jackDieState :JackStateMechine
{
    public jackDieState(string name, JackStateSwitcher jackStateSwitcher) : base(name, jackStateSwitcher)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
    Object.Destroy(JackOfthird.instance.gameObject);
    
    }
    public override void Exit()
    {
        base.Exit();
    }
}
