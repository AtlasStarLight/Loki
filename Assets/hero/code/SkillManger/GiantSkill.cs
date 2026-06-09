using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantSkill : Skills
{
    [Header("giant skill control")]
    [SerializeField] SkillSlot giant;

    public static bool shouldTransform;
    public static bool InColdDown;
    public void Start()
    {
        shouldTransform=false;
    }
   public void Update()
    {
       if(giant.canUse)
        {
            shouldTransform=true;

        }
        else
        {
            shouldTransform=false;
        }
    }
}
