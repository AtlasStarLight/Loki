using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossBloodBar : MonoBehaviour
{
    public static BossBloodBar instance;
   [SerializeField] Slider fistbossBlood;

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
        fistbossBlood.value=(float)DeathGodStats.instance.currentHP/DeathGodStats.instance.HP.GetValue();
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
