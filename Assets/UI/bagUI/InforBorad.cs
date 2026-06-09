using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InforBorad : MonoBehaviour
{
    public static InforBorad instance;
[SerializeField] Image image;
[SerializeField] Image itemIcon;
[SerializeField] TextMeshProUGUI context;
[SerializeField] TextMeshProUGUI Name;
[SerializeField] TextMeshProUGUI Function;
[SerializeField] GameObject useonebutton;
[SerializeField] GameObject inputonebutton;
[SerializeField] GameObject discardonebutton;

 public  Slot  currentSlot;
 public Itemdata currentdata;

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
        currentSlot=null;
        
      
    }
public void Start()
    {
       this.gameObject.SetActive(false);
       
    }
    public void ShowInfor(Itemdata itemWantsToShow,Slot thisslot)
    
    {
        currentdata=itemWantsToShow;
         currentSlot=thisslot;
     
       gameObject.SetActive(true);
       if(itemWantsToShow.itemtype==Itemtype.materal)
        {
            useonebutton.SetActive(false);
            inputonebutton.SetActive(false);

            
        }
        else
        {
            useonebutton.SetActive(true);
            inputonebutton.SetActive(true); 
        }
       
     this.gameObject.transform.position=Input.mousePosition+new Vector3(-210,-80,0);
        context.text=itemWantsToShow.Descreble;
        Name.text=itemWantsToShow.ItemName;
        itemIcon.sprite=itemWantsToShow.Icon;

        
              

        
    }
    public void CloseThis()
    {
        gameObject.SetActive(false);
    }
    public void EquitmentOne()

    
    {if (currentdata == null) return;
        Inventory.instance.WantToEquimentOne(currentdata);
        Inventory.instance.UPdateAllSlotUI();
    }
    public void DiscardOne()
    {if (currentdata == null) return;
         if(Inventory.instance.ItemsForStack.TryGetValue(currentdata,out ItemsInInvetory needs))
        {
            for(int i=0;i<needs.itemsize;i++)
            {
                Inventory.instance.DisItem(needs.item);
            }
        }
    }
 
       public void UseOne()
    {
        if (currentdata == null) return;
       
        if(currentdata.itemtype==Itemtype.Hp)
        {
              PlayerStats.instance.currentHP+=100;
        }
        else if(currentdata.itemtype==Itemtype.Force)
        {
         PlayerFx.instance.ForceBuff(100,5f);

        }
        else if(currentdata.itemtype==Itemtype.Defensive)
        {
           PlayerFx.instance.DefensiveBuff(100,5f);
        }

 Inventory.instance.DisItem(currentdata);
      //前面写加效果的，然后下一步就是这个。
    }

}
