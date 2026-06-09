using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloneSkill : Skills
{
  [Header(" skill control with skill slot")]
  [SerializeField] SkillSlot cloneslot;
 
    public static  float CloneSkillTimer=0;
  public static float timercolddown=8f;
  public static bool CanUseCloneSkill;
  public static bool InColdDown;
    GameObject itiClone;
  public void Awake()
  {

    CanUseCloneSkill=false;
    itiClone=null;
  }

  [SerializeField] GameObject ClonePrafab;
  public void StartCloneSkill()
    {

         itiClone=Instantiate(ClonePrafab,Player.instance.transform.position+new Vector3(0,-0.4f,0),Quaternion.identity);
        
        
        Player.instance.rb.velocity=new Vector2(5*Player.instance.facedir*-1,0);//后退特效；
        itiClone.GetComponent<CloneControl>().SetInSkill();

CloneSkillTimer=timercolddown;
    }
    public void Update()
  {
   
    if(itiClone!=null)
    {
     if( Input.GetKeyDown(KeyCode.V))
      {
        Player.instance.transform.position=itiClone.transform.position;
        Destroy(itiClone);
      }

    }
   
    if(cloneslot.canUse)
    {
  
     
      CanUseCloneSkill=true;
   
     
    }
    else
    {
      CanUseCloneSkill=false;
     
    }
  }


}
