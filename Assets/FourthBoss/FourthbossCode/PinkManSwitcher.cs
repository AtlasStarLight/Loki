using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkManSwitcher 
{
    public PinkManStateMechine currentstate;
    public void AtFirstState(PinkManStateMechine pinkManStateMechine)
    {
        currentstate=pinkManStateMechine;
        currentstate.Enter();
    }
    public void ChangeState(PinkManStateMechine pinkManStateMechine)
    {
        currentstate.Exit();
        currentstate=pinkManStateMechine;
        currentstate.Enter();
    }
    
}
