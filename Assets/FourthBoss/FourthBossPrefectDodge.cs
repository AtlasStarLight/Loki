using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthBossPrefectDodge : MonoBehaviour
{
    
    public static bool ThisIsPrefectDodge;
    private bool hasTrigger=false;
    public void PrefecttRigger()
    {
        ThisIsPrefectDodge=true;
    }
    
   
    public void ClosePrefectDodge()
    {
        ThisIsPrefectDodge=false;
        if(hasTrigger)
        {
            hasTrigger=false;
        }
    }
    public void Update()
    {
        if(ThisIsPrefectDodge&&DodgeState.isdodge&&!hasTrigger)
        {
            PinkManPrefectDodge.instance. DoHitStop(0.05f,0.5f);
            hasTrigger=true;
        }
    }
}
