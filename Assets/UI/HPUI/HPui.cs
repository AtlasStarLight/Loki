using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPui : MonoBehaviour
{
  
  [SerializeField] Slider HP;
      public static HPui instance;

  
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
  public void Start()
    {
        ShowHP();
       
    }
  public void ShowHP()
    {
        
float currentHP=Player.instance.GetComponent<PlayerStats>().currentHP;
stats stats=Player.instance.GetComponent<PlayerStats>().HP;
HP.value=(float)currentHP/stats.GetValue();

    }
    public void Update()
    {
        ShowHP();
    }

}
