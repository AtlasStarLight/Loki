using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackStateSwitcher 
{
   public JackStateMechine currentstate;
   public void AtFirstState(JackStateMechine  jackStateMechine)
    {
        currentstate=jackStateMechine;
        currentstate.Enter();
    }
    public void ChangeState(JackStateMechine jackStateMechine)
    {
        currentstate.Exit();
        currentstate=jackStateMechine;
        currentstate.Enter();
    }
    
}
