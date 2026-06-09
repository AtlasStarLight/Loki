using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deathjoke : DeathGodStateMechine
{
    private float timer;
    Vector3 currentpostion;
    public Deathjoke(string name, DeathGodStateSwither deathGodStateSwither) : base(name, deathGodStateSwither)
    {
    }
      public override void Enter()
    {
        base.Enter();
    timer=0.5f;
   currentpostion=DeathGod.instance.transform.position;
    }
    public override void Exit()
    {
        base.Exit();
  

    }
    public override void Update()
    {
        base.Update();
              
    DeathGod.instance.transform.position=Player.instance.transform.position+new Vector3(-1,0,0);
    timer-=Time.deltaTime;
    if(timer<0)
        {
           DeathGod.instance.transform.position=currentpostion;
           deathGodStateSwither1.ChangeState(DeathGod.instance.deathIdle);
        }
    }
}
