using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKnightSwitcher 
{
    public PinkNightStateMechine currentState;
    public void AtFistState(PinkNightStateMechine pinkNightStateMechine)
    {
        currentState=pinkNightStateMechine;
        currentState.Enter();
    }
    public void ChangeState(PinkNightStateMechine pinkNightStateMechine)
    {
        currentState.Exit();
        currentState=pinkNightStateMechine;
        currentState.Enter();
    }
    
}
