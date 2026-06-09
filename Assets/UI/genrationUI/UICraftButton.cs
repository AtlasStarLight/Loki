using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICraftButton : MonoBehaviour,IPointerClickHandler
{
      [SerializeField] GameObject craft;
    
    public void Awake()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UI.instance.OpenCraft(craft);
    }
     public void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
              UI.instance.KeyBoardControl(craft);
             
              
        }
    }
}
