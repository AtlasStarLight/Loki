using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSwitcher 
{
  public PlayerState currentstate;
   public void AtFirstState(PlayerState playerState)
    {
        currentstate=playerState;
        currentstate.Enter();
    }
    public void ChangeState(PlayerState newstate)
    {
        currentstate.Exit();
        currentstate=newstate;
        currentstate.Enter();


    }
}
