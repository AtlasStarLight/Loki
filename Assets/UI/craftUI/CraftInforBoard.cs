using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftInforBoard : MonoBehaviour
{
    public static CraftInforBoard instance;
   [SerializeField] Image targeticon;
   [SerializeField] TextMeshProUGUI itemName;
   [SerializeField] Transform ThatneedsParent;
   [SerializeField] GameObject materalsPrtefab;
   [SerializeField] TextMeshProUGUI descreblethis;
   private  Itemdata currentData;
  


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
        currentData=null;
        
    }
   public void ShowIconAndName(Itemdata ComeFromCraftSlot)
    {
        if(ComeFromCraftSlot==null)
        {
       //     Debug.Log("ComeFromCraftSlot is null");
            return;
        }
       //  Debug.Log("ComeFromCraftSlot is  not null");
    currentData=ComeFromCraftSlot;
        targeticon.sprite=ComeFromCraftSlot.Icon;
        itemName.text=ComeFromCraftSlot.ItemName;
        descreblethis.text=ComeFromCraftSlot.Descreble;
          foreach(Transform children in ThatneedsParent)
        {
            if(children!=null)
            {
                Destroy(children.gameObject);
               
            }
         

        }

                 foreach(var needs in ComeFromCraftSlot.ForCraftThis)
                {
                    GameObject target=Instantiate(materalsPrtefab,ThatneedsParent);
                   materalsSlot fuckyou= target.GetComponent<materalsSlot>();
                   fuckyou.ShowMaterals(needs);

                    
                }
            
    }
      public void Craft()
    {
        if(currentData!=null)
        {
          Debug.Log("currentData is not null");
               if(Inventory.instance.CanCraft(currentData))
        {
         Debug.Log("this is can craft");
            foreach(var needstomove in currentData.ForCraftThis)
            {
                if(Inventory.instance.ItemsForStack.TryGetValue(needstomove.materals,out ItemsInInvetory have))
                {
                    for(int i=0;i<needstomove.materalsamout;i++)
                    {
                        Inventory.instance.DisItem(have.item);
                    }
                   
                }
            }
             Inventory.instance.AddItem(currentData);
             Debug.Log("craft successful");
        }
    }
    else
        {
         //   Debug.Log("go fuck Yourself");
            return;
        }

        
       
    }

   
}
