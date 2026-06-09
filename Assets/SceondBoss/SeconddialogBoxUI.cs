using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SeconddialogBoxUI : MonoBehaviour
{
    public static SeconddialogBoxUI instance;
    bool isTrigger=false;
    [SerializeField]GameObject dialogbox;

  
  
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
        dialogbox.SetActive(false);
    }
    public void ChooseInronButtonEvent()
    {
         BoxMonster.instance.gameObject.SetActive(true);
         dialogbox.gameObject.SetActive(false);
       
       
      
    }
    public void ChooseGoldOne()
    { 
         beatifulMonster.instance.gameObject.SetActive(true);
         dialogbox.gameObject.SetActive(false);
       
      
    }
    public void CloseMenu()
    {
        dialogbox.gameObject.SetActive(false);
    }
     public void CheckPlayerWithSketelonDistance()
    {
    if(Player.instance!=null)
        {
            float distance=Player.instance.transform.position.x-ScondOfFirstBoss.instance.transform.position.x;
            float AbsDistance=Mathf.Abs(distance);
            if(AbsDistance<1&&!isTrigger)
            {    dialogbox.SetActive(true);
            isTrigger=true;
            }
            if(AbsDistance>2)
            {
                isTrigger=false;
              
            }

        }
    }
    public void CloseDialogBox()
    {
        dialogbox.gameObject.SetActive(false);
    }
    public void Update()
    {
        CheckPlayerWithSketelonDistance();
       
    }

}
