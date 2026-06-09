using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BegState : PlayerState
{
    private  float Timer;
 public static bool isbeg;

    public BegState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Timer=2;
        isbeg=true;
    }
    public override void Update()
    {
        
    Timer-=Time.deltaTime;
    if(Timer<0)
        {
            playerStateSwitcher1.ChangeState(Player.instance.idelState);

        }
    }
    public override void Exit()
    {
        isbeg=false;
        base.Exit();
    }

}
