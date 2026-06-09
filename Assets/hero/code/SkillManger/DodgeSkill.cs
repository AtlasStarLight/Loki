using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeSkill : Skills
{
    public static bool couldDodge;
    public static float dodgeTimer=0;
    public static float dodgeClodDown=1f;
    public static bool InColdDown;

    [SerializeField] SkillSlot DodgeSlot;
    public void Start()
    {
        couldDodge=false;
        
    }
   public void Update()
    {
       
      
        if(DodgeSlot.canUse==true)
        {
         
         
            couldDodge=true;
            
        }
        else
        {
           couldDodge=false;
           
        }
        
    }
}
