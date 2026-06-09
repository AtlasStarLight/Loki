using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagicSkill : Skills
{
    [Header("magic skill Control")]
   
    public static float MagicTimer=0;
    public static float Durationtime=15f;
    public static float MagicColdDownTimer=0f;
    public static float magiccoldown=15f;
    public static bool InColdDown;
    [SerializeField] SkillSlot magicslot;

    public static bool couldMagicAttack;
 [SerializeField]   List<MagicControl> magicControls;
 private List<MagicControl> useone=new List<MagicControl>();
 GameObject thisone;
 public void Awake()
    {
        thisone=null;
       
    }
 public void StartSkill()
    {
      /// Debug.Log("magic skill come in");
        useone.Clear();
      
        foreach(var prefab in magicControls)
        {
             int c=Random.Range(0,100);
            if(c<prefab.usechance)
            {
                useone.Add(prefab);
            }
        }

            if(useone.Count==1)
            {
                thisone=Instantiate(useone[0].gameObject,Player.instance.transform.position+new Vector3(0.7f,-0.3f,0),Quaternion.identity);
             //   Debug.Log("start successful ");
              if(thisone.GetComponent<BallControl>() != null)
{
    thisone.GetComponent<BallControl>().UseThis();

}
else if(thisone.GetComponent<FireControl>() != null)
{
    thisone.GetComponent<FireControl>().UseThis();
}
else if(thisone.GetComponent<greenFireControl>() != null)
{
    thisone.GetComponent<greenFireControl>().UseThis();
}
            }
            else
        {
            // Debug.Log("start successful 1");
            if(useone.Count == 0)
    return;
           GameObject maxone=useone.OrderByDescending(x=>x.usechance).First().gameObject;
           thisone=Instantiate(maxone,Player.instance.transform.position+new Vector3(0.7f,-0.3f,0),Quaternion.identity);
            if(thisone.GetComponent<BallControl>() != null)
{
    thisone.GetComponent<BallControl>().UseThis();
}
else if(thisone.GetComponent<FireControl>() != null)
{
    thisone.GetComponent<FireControl>().UseThis();
}
else if(thisone.GetComponent<greenFireControl>() != null)
{
    thisone.GetComponent<greenFireControl>().UseThis();
}
        }
       
    }
    public void Update()
    {
  OpenMagic();
     if(couldMagicAttack)
        {
         InColdDown=true;
         MagicTimer-=Time.deltaTime;
         if(MagicTimer<0)
            {
               
                InColdDown=false;
                couldMagicAttack=false;
                MagicColdDownTimer=magiccoldown;
            }
         
        }
        if(MagicColdDownTimer>0)
        {
            MagicColdDownTimer-=Time.deltaTime;
        }

    }
    public void OpenMagic()
    {
        if(couldMagicAttack)return;
        if(MagicColdDownTimer>0)
        {
             couldMagicAttack=false;
        return;
        }
      
        if(MagicColdDownTimer<=0&&magicslot.canUse)
        {
               couldMagicAttack=true;
        MagicTimer=Durationtime;
        
        }
      
    }
  
 


  
}
