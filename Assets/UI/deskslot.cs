using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deskslot : Slot
{
    
    public Itemtype itemtype;
    private Itemdata dataOnDesk;
    private float ForceTimer=10f;
    private float defensiveTimer=7f;
    public override void Awake()
    {
    base.Awake();
   
   
    
    }
    public void Start()
    {
        dataOnDesk=null;
    }
    public override void UpdateSlot(ItemsInInvetory itemComeFromInventory)
    {
        if(itemtype!=itemComeFromInventory.item.itemtype)
        {
            return;
        }
        dataOnDesk=itemComeFromInventory.item;
     base.UpdateSlot(itemComeFromInventory);


        

    }
    public override void ClearSlot()
    {
        base.ClearSlot();
        dataOnDesk=null;
    }
  public void Update()
{
    ForceTimer-=Time.deltaTime;
    defensiveTimer-=Time.deltaTime;
    if (dataOnDesk == null)
    {
        return;
    }

    if (itemtype == Itemtype.Hp && Input.GetKeyDown(KeyCode.M))
    {
        InforBorad.instance.currentdata = dataOnDesk;
        InforBorad.instance.UseOne();
    }

    if (itemtype == Itemtype.Force && Input.GetKeyDown(KeyCode.N)&&ForceTimer<0)
    {
        InforBorad.instance.currentdata = dataOnDesk;
        InforBorad.instance.UseOne();
        ForceTimer=10f;
    }

    if (itemtype == Itemtype.Defensive && Input.GetKeyDown(KeyCode.Z)&&defensiveTimer<0)
    {
        InforBorad.instance.currentdata = dataOnDesk;
        InforBorad.instance.UseOne();
        defensiveTimer=7f;
    }
}
   
  
}
