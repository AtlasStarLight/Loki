using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsButton : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] GameObject settings;
    
    public void Awake()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UI.instance.OpenSettings(settings);
    }
     public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
              UI.instance.KeyBoardControlSetings(settings);
             
              
        }
    }
}
