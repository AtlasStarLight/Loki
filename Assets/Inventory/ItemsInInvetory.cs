using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class ItemsInInvetory 
{
  public Itemdata item;
  public int itemsize;
  public ItemsInInvetory(Itemdata togetinItem)
    {
        item=togetinItem;
         PlusItem();
    }
    public void PlusItem()=>itemsize++;
    public void DisItem()=>itemsize--;
}
