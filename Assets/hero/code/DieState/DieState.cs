using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : PlayerState
{
    public bool isDie;
    private bool hastrrger;
    public DieState(string name, PlayerStateSwitcher playerStateSwitcher) : base(name, playerStateSwitcher)
    {
    }

    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        isDie=true;
        hastrrger=false;
    }
    public override void Update()
    {
        base.Update();
      if(!hastrrger)
        {
            DieSecene.instance.gameObject.SetActive(true);
            DieSecene.instance.StartIn();
        }
        if(PlayerStats.instance.currentHP>0)
        {
            playerStateSwitcher1.ChangeState(Player.instance.idelState);
        }
    }
    public override void Exit()
    {
        base.Exit();
        isDie=false;
    }
   
}
