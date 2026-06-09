using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggerSkill : Skills
{
    [SerializeField] SkillSlot bagger;
    public static bool couldbagger;
    public static bool InColdDown;
public void Awake()
    {
        couldbagger=false;
    }
    void Update()
    {
        
        if(bagger.canUse)
        {
            couldbagger=true;
        }
    }
}
