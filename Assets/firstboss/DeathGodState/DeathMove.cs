using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMove : DeathGodStateMechine
{
    public DeathMove(string name, DeathGodStateSwither deathGodStateSwither) : base(name, deathGodStateSwither)
    {
    }
      public override void Enter()
    {
        base.Enter();
        rb.velocity=new Vector2(3f,0);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
