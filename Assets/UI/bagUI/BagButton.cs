using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BagButton : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] GameObject bag;
    
    public void Awake()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UI.instance.OpenBag(bag);
    }
     public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
              UI.instance.KeyBoardControl(bag);
             
              
        }
    }
   
}
