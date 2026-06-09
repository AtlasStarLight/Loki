using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class craftslot : MonoBehaviour,IPointerClickHandler
{
  [SerializeField] Image craftIcon;
 
  public Itemdata wantstoCraft;
  public void Start()
    {
        if(wantstoCraft!=null)
        {
               UpdateIcon(wantstoCraft);
        }

        
    }
    public void UpdateIcon(Itemdata forcraft)
    {
        wantstoCraft=forcraft;
        craftIcon.color=Color.white;
        wantstoCraft=forcraft;
        craftIcon.sprite=wantstoCraft.Icon;
        craftIcon.preserveAspect=true;
       
    }

 

 

    public void OnPointerClick(PointerEventData eventData)
    {
         if(wantstoCraft==null)
        {
          CrafInforUI.instance.gameObject.SetActive(false);
            return;
        }
         CrafInforUI.instance.gameObject.SetActive(true);
     CraftInforBoard.instance.ShowIconAndName(wantstoCraft);
    }
}
