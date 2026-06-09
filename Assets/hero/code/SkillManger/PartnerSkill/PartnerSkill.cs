using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PartnerSkill : Skills
{
    [Header("parter skill control")]
    public static bool InColdDwon;
    public static float parterTimer=0;
    public static float partenercolddown=10f;
    public static bool canuse;
    [SerializeField] SkillSlot summon;
   [SerializeField] List<GameObject> partener=new List<GameObject>();
   public void SetUpThisSkill()
    {
        if(partener==null)
        {
            return;
        }
        int chance=Random.Range(0,partener.Count);
        GameObject useone=null;
      foreach(var chooseone in partener)
        {
            useone=partener[chance];
        }
        if(useone.GetComponent<GreenControl>()!=null)
        {
           
            for(int i=0;i<5;i++)
            {
                 float position=Random.Range(0,2);
                GameObject findGreenOne=Instantiate(useone,Player.instance.transform.position+new Vector3(i*position,position,0),Quaternion.identity);
                  findGreenOne.GetComponent<GreenControl>().UseThis();

            }
        }
        else
        {
             GameObject findSlime=Instantiate(useone,Player.instance.transform.position,Quaternion.identity,Player.instance.transform);
       
            findSlime.GetComponent<BlueControl>().UseThis();
        
        
        }
        parterTimer=partenercolddown;
      
     
    }
    public void Update()
    {
      
        if(summon.canUse)
        {
          
            canuse=true;

        }
        else
        {
            
            canuse=false;
        
        }
         
        
        
    }
}
