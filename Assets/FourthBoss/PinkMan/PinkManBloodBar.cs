using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinkManBloodBar : MonoBehaviour
{
     public static PinkManBloodBar instance;
   [SerializeField] Slider fourthbossBlood;
    [SerializeField] PInkManStats toShowblood;
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
   public void ShowFirstBossBlood()
    {
        fourthbossBlood.value=(float)toShowblood.currentHP/toShowblood.HP.GetValue();
    }
    public void Start()
    {
        ShowFirstBossBlood();
    }
    public void Update()
    {
        ShowFirstBossBlood();
    }
  
}
