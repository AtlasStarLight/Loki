using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Slot : MonoBehaviour,IPointerClickHandler
{
[SerializeField]Image icon;

   [SerializeField]TextMeshProUGUI text;
   public Itemdata thisdata;

public virtual void Awake()
    {
    thisdata=null;
   
   
    
    }
    public virtual  void UpdateSlot(ItemsInInvetory itemComeFromInventory)
    {
     icon.color=Color.white;
        thisdata=itemComeFromInventory.item;
        if(thisdata==null)

        {
        // Debug.LogError("thisdata is "+thisdata);   
        }
        icon.sprite=thisdata.Icon;
        icon.preserveAspect=true;
if(itemComeFromInventory.itemsize==1)
        {
            text.text="";
        }
        else
        {
            text.text=itemComeFromInventory.itemsize.ToString();
        }


        

    }
    public virtual  void ClearSlot()
    {
        icon.sprite=null;
        text.text="";
        icon.color=Color.clear;
        thisdata=null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      InforBorad.instance.CloseThis();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
         if(thisdata==null)
        {InforBorad.instance.CloseThis();
   
           // Debug.LogError(thisdata+"is null");
            return;
        }
        else
        {
              
           // Debug.LogError(thisdata+"is successful");
            InforBorad.instance.ShowInfor(thisdata,this);
        }
    }
    public void OnDisable()
    {
        if (InforBorad.instance == null) return;
        if(InforBorad.instance.currentSlot!=null&&InforBorad.instance.currentSlot==this)
        {
            InforBorad.instance.CloseThis();
        }
    }
}
