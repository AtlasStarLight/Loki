using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathIdle : DeathGodStateMechine
{
    public deathIdle(string name, DeathGodStateSwither deathGodStateSwither) : base(name, deathGodStateSwither)
    {
    }
    public override void Enter()
    {
        base.Enter();

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
