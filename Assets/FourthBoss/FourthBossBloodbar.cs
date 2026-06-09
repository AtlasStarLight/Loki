using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FourthBossBloodbar : MonoBehaviour
{
      public static FourthBossBloodbar instance;
   [SerializeField] Slider FourthbossBlood;

  

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
        FourthbossBlood.value=(float)PInkManStats.instance.currentHP/PInkManStats.instance.HP.GetValue();
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
