using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class skillbutton : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] GameObject skills;
    
    public void Awake()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UI.instance.OpenSettings(skills);
    }
     public void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
              UI.instance.KeyBoardControlSkills(skills);
             
              
        }
    }
}
