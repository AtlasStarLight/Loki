using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueControl : MonoBehaviour
{
   private PlayerStats buffForPlayer=>Player.instance.GetComponent<PlayerStats>();
   private  float durationTimer;
  
   private Animator am=>this.GetComponent<Animator>();
   public void UseThis()
    {
        CloseAllAM();
        am.SetBool("isIdle",true);
        durationTimer=10f;
        buffForPlayer.Defensive.AddValue(500);
        buffForPlayer.Defensive.ShowUpdateValue();
    

    }
    public void CloseAllAM()
    {

        am.SetBool("isIdle",false);
        am.SetBool("isDie",false);
    }


   public void Update()
    {
        durationTimer-=Time.deltaTime;
        if(durationTimer<=0)
        {
           CloseAllAM();
           am.SetBool("isDie",true);
             buffForPlayer.Defensive.DeleteValue(500);
             buffForPlayer.Defensive.ShowUpdateValue();
             
             Destroy(gameObject,0.5f);
            
        }
    }

}
