using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class deskSkillSlot : MonoBehaviour
{
  
   [SerializeField] Image icon;
   [SerializeField] Image colddown;

 [SerializeField]  SkillType thistype;
 [SerializeField] Image frame;

public void Start()
   {
      CloseThis();
   }
   public void CloseThis()
   {
      icon.enabled=false;
      colddown.enabled=false;
      frame.enabled=false;
   }
   public  void Usethis( )
   {
      
    icon.enabled=true;
    frame.enabled=true;
    
    }
      public void Refresh()
      {

      if(thistype==SkillType.Bagger)
      {
         if(BaggerSkill.InColdDown)
         { 
           
               colddown.enabled=true;
            colddown.color=Color.gray;
            colddown.type=Image.Type.Filled;
            colddown.fillAmount-=1f/2*Time.deltaTime;
            
         }
         else
         {
            colddown.enabled=false;
            colddown.fillAmount=1;
           
         }
      }
      else if(thistype==SkillType.Clone)
      {
         if(CloneSkill.InColdDown)
         {
          colddown.enabled=true;
            colddown.color=Color.gray;
            colddown.type=Image.Type.Filled;
            colddown.fillAmount-=1f/8f*Time.deltaTime;
         }
         else
         {
             colddown.enabled=false;
            colddown.fillAmount=1;
         }
      }
      else if(thistype==SkillType.Dodge)
      {
         if(DodgeSkill.InColdDown)
         {
              colddown.enabled=true;
            colddown.color=Color.gray;
            colddown.type=Image.Type.Filled;
            colddown.fillAmount-=1f/1.5f*Time.deltaTime;
         }
         else
         {
               colddown.enabled=false;
            colddown.fillAmount=1;
         }
      }
      else if(thistype==SkillType.Giant)
      {
         if(GiantSkill.InColdDown)
         {
         colddown.enabled=true;
            colddown.color=Color.gray;
            colddown.type=Image.Type.Filled;
            colddown.fillAmount-=1f/45f*Time.deltaTime;
         }
         else

         {
            
               colddown.enabled=false;
            colddown.fillAmount=1;
         }
      }
      else if(thistype==SkillType.Magic)
      {
         if(MagicSkill.InColdDown)
         {
                      colddown.enabled=true;
            colddown.color=Color.gray;
            colddown.type=Image.Type.Filled;
            colddown.fillAmount-=1f/15f*Time.deltaTime;
         }
         else
         {
                 colddown.enabled=false;
            colddown.fillAmount=1;
         }

      }
      else if(thistype==SkillType.Partner)
      {
         if(PartnerSkill.InColdDwon)
         {
                 colddown.enabled=true;
            colddown.color=Color.gray;
            colddown.type=Image.Type.Filled;
            colddown.fillAmount-=1f/10f*Time.deltaTime;
         }
         else
         {
            colddown.enabled=false;
            colddown.fillAmount=1;
         }
      }

      
   
   

   }
   public void Update()
   {
      Refresh();
   }
   
}
