using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTransformState : DeathGodStateMechine
{
    private float timer;
    public DeathTransformState(string name, DeathGodStateSwither deathGodStateSwither) : base(name, deathGodStateSwither)
    {
    }
    public override void Enter()
    {
        base.Enter();
        timer=40f;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
timer-=Time.deltaTime;
        {
            if(timer<0)
            {
                DeathGod.instance.deathGodStateSwither.ChangeState(DeathGod.instance.deathIdle);
            }
        }
    }
}
