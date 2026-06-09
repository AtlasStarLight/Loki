using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdBossBloodBar : MonoBehaviour
{
      public static ThirdBossBloodBar instance;
   [SerializeField] Slider ThirdbossBlood;

  

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
        ThirdbossBlood.value=(float)JackStats.instance.currentHP/JackStats.instance.HP.GetValue();
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
