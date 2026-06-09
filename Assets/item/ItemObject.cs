using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    SpriteRenderer sr=>GetComponent<SpriteRenderer>();
public Itemdata itemdata;

public void Awake()
    {
       
        itemdata=null;
    }
public void SetIcon(Itemdata comeFromOthers)
    {
        itemdata=comeFromOthers;
        if(itemdata==null)
        {
            Debug.LogError("GameObject Item is " +itemdata);
            return;
        }
        sr.sprite=itemdata.Icon;
    }
  
  

 
    public void OnTriggerEnter2D(Collider2D target)
    {
         sr.sprite=itemdata.Icon;
        if(target.GetComponent<Player>()!=null)
        {
            Inventory.instance.AddItem(this.itemdata);
            Destroy(gameObject);
     
        }
    }

}
