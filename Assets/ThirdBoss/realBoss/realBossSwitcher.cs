using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realBossSwitcher
{
   public realBossStatemechine currentState;
   public void AtFirstState(realBossStatemechine  realBossStatemechine)
    {
        currentState=realBossStatemechine;
        currentState.Enter();
    }
    public void ChangeState(realBossStatemechine  realBossStatemechine)
    {
        currentState.Exit();
        currentState=realBossStatemechine;
        currentState.Enter();
    }
}
