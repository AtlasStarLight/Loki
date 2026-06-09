using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossStateSwitcher 
{
    public SixthBossStateMechine currentstate;
    public void AtFistState(SixthBossStateMechine sixthBossStateMechine)
    {
        currentstate=sixthBossStateMechine;
        currentstate.Enter();
    }
    public void ChageState(SixthBossStateMechine sixthBossStateMechine)
    {
        currentstate.Exit();
        currentstate=sixthBossStateMechine;
        currentstate.Enter();
    }

}
