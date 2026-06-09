using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SxithBossBloddBar : MonoBehaviour
{
      public static SxithBossBloddBar instance;
   [SerializeField] Slider sixthbossBlood;

  

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
        sixthbossBlood.value=(float)SixthBossStats.instance.currentHP/SixthBossStats.instance.HP.GetValue();
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
