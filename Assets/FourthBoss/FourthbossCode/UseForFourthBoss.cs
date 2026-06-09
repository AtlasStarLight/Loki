using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseForFourthBoss : MonoBehaviour
{
    public static UseForFourthBoss instance;
  [SerializeField] GameObject LightningPrefab;

  
  public static bool skillisdie=false;
  public static float UsethisTimer=20f;
  public void Awake()
    {
        if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }
    }
   
  public void Update()
    {
        UsethisTimer-=Time.deltaTime;
        if(UsethisTimer<0)
        {
            if(PinkMan.instance==null)
            {
                return;
            }
           GameObject newone=Instantiate(LightningPrefab,PinkMan.instance.transform.position+new Vector3(1,0,0),Quaternion.identity);
           newone.GetComponent<lightningControlForPinkMan>().UseThis(1);
           GameObject newtwo=Instantiate(LightningPrefab,PinkMan.instance.transform.position+new Vector3(-1,0,0),Quaternion.identity);
            newone.GetComponent<lightningControlForPinkMan>().UseThis(-1);
            UsethisTimer=20f;
           
        }
        if(UsethisTimer>0)
        {
            skillisdie=false;
        }
       
       
    }
    

}
