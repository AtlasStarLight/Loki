using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGodStateSwither
{
   public DeathGodStateMechine currentState;
 public void AtFirstState(DeathGodStateMechine deathGodStateMechine)
    {
       currentState=deathGodStateMechine;
       currentState.Enter();
    }
    public void ChangeState(DeathGodStateMechine deathGodStateMechine)
    {
        currentState.Exit();
        currentState=deathGodStateMechine;
        currentState.Enter();
    }
}
