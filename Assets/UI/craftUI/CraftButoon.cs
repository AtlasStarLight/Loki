using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftButoon : MonoBehaviour,IPointerClickHandler
{

  public void Craft(Itemdata cancraftOne)
    {
        if(Inventory.instance.CanCraft(cancraftOne))
        {
            foreach(var needstomove in cancraftOne.ForCraftThis)
            {
                if(Inventory.instance.ItemsForStack.TryGetValue(needstomove.materals,out ItemsInInvetory have))
                {
                    for(int i=0;i<needstomove.materalsamout;i++)
                    {
                        Inventory.instance.DisItem(have.item);
                    }
                   
                }
            }
             Inventory.instance.AddItem(cancraftOne);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
    
    }
}
