using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PinkNightComeOut : MonoBehaviour
{
    [SerializeField] GameObject KnightComeOutTip;

    [SerializeField] PInkManStats pInkManStats;
 
    public void Start()
    {
        KnightComeOutTip.gameObject.SetActive(false);
         PinkKnight.instance.gameObject.SetActive(false);


    }
    
    public void Update()
    {
        if(pInkManStats.currentHP<500)
        {
            KnightComeOutTip.gameObject.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Q)&&KnightComeOutTip.activeSelf)
        {
            PinkKnight.instance.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
     
}
