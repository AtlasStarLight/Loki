 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour,Isave
{
    [Header("itemdata database")]
   [SerializeField] List<Itemdata> database;
    [Header("Input one")]
    public Dictionary<Itemtype,ItemsInInvetory>euqimentForUI;
  
    public Transform equimentparent;
    public deskslot[] deskslots;
   [Header("item's UI")]
   [SerializeField] Transform slotsParent;
   private Slot[] slots;
   public static Inventory instance;
public List<ItemsInInvetory>ItemsForUI;
 public Dictionary<Itemdata, ItemsInInvetory>ItemsForStack;
   public void Awake()
    {
        ItemsForUI=new List<ItemsInInvetory>();
        ItemsForStack=new Dictionary<Itemdata, ItemsInInvetory>();
       slots=slotsParent.GetComponentsInChildren<Slot>();
      euqimentForUI=new Dictionary<Itemtype, ItemsInInvetory>();
    
    deskslots=equimentparent.GetComponentsInChildren<deskslot>();

        if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void UPdateAllSlotUI()
    {
        for(int i=0;i<slots.Length;i++)
        {
            slots[i].ClearSlot();
        }
        for(int i=0;i<deskslots.Length;i++)
        {
            deskslots[i].ClearSlot();
        }
        for(int i=0;i<ItemsForUI.Count;i++)
        {
            slots[i].UpdateSlot(ItemsForUI[i]);
        }
        
     foreach(var slot in deskslots)
        {
            foreach(var pair in euqimentForUI)
            {
                if(slot.itemtype==pair.Key)
                {
                    slot.UpdateSlot(pair.Value);
                }
            }
        }

      
    
    }
    public void AddItem(Itemdata GetItem)
    {
        if(ItemsForStack.TryGetValue(GetItem,out ItemsInInvetory result))
        {
            result.PlusItem();
                UPdateAllSlotUI();
        }
        else
        {
            ItemsInInvetory NewOne=new ItemsInInvetory(GetItem);
            ItemsForUI.Add(NewOne);
            ItemsForStack.Add(GetItem,NewOne);
                UPdateAllSlotUI();
        }
    
    }
    public void DisItem( Itemdata WantsDeleteone)
    {
       

        if(ItemsForStack.TryGetValue(WantsDeleteone,out ItemsInInvetory result))
        {

            if(result.itemsize>1)
            {
                result.DisItem();
                    UPdateAllSlotUI();

            }
            else
            {
                ItemsForStack.Remove(result.item);
                  ItemsForUI.Remove(result);
                   if (euqimentForUI.TryGetValue(result.item.itemtype, out ItemsInInvetory equipItem))
    {
        if (equipItem == result)
        {
            euqimentForUI.Remove(result.item.itemtype);
        }
    }
                      UPdateAllSlotUI();
            }
        }
      
       
    }
    public bool CanCraft(Itemdata wantstoCraft)
    {

      foreach(var wantto in wantstoCraft.ForCraftThis)
        {
        if(!ItemsForStack.TryGetValue(wantto.materals,out ItemsInInvetory have))
            {
                return false;
            }
      if(have.itemsize<wantto.materalsamout)
            {
                return false;
            }
       
        }
  
       
       
    
        
        return true;
    }
public void WantToEquimentOne(Itemdata wantstoDESKone)
    {
       if(ItemsForStack.TryGetValue(wantstoDESKone,out ItemsInInvetory needsone))
        {
       
              euqimentForUI[wantstoDESKone.itemtype]=needsone;
         
        }
      
    
    }

    public void LoadData(GameData gameData)
    {
        ItemsForUI.Clear();
ItemsForStack.Clear();
        foreach(var pair in gameData.inventory)
        {
           foreach(var needsone in database)
            {
                if(needsone.ItemID==pair.Key)
                {
                   ItemsInInvetory thisone=new ItemsInInvetory(needsone);
                   ItemsForUI.Add(thisone);
                   ItemsForStack.Add(needsone,thisone);
                   thisone.itemsize=pair.Value;
                }
            }
        }
        foreach(var need in gameData.equitment)
        {
            foreach(var item in database)
            {
                if(item.itemtype==need)
                {
                    WantToEquimentOne(item);
                }
            }

        }
      UPdateAllSlotUI();
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.inventory.Clear();
         UPdateAllSlotUI();

      foreach(var pair in ItemsForStack)
        {
        gameData.inventory.Add(pair.Key.ItemID,pair.Value.itemsize);
        }
        foreach(var needs in euqimentForUI)
        {
            gameData.equitment.Add(needs.Key);
        }
        
    }
}
