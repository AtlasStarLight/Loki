using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNotFromEnemy : MonoBehaviour,Isave
{
 
    SpriteRenderer sr=>GetComponent<SpriteRenderer>();
[SerializeField] private Itemdata itemdata;
private bool hasPicked=false;
public void Awake()
    {
       
    
          sr.sprite=itemdata.Icon;
    }

  

 
    public void OnTriggerEnter2D(Collider2D target)
    {
         sr.sprite=itemdata.Icon;
        if(target.GetComponent<Player>()!=null)
        {
            Inventory.instance.AddItem(this.itemdata);
            hasPicked=true;
            SaveMager.instance.SaveGame();
            Destroy(gameObject);
     
        }
    }

    public void LoadData(GameData gameData)
    {
       hasPicked=gameData.potionpick;
       if(hasPicked)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(ref GameData gameData)
    {
       gameData.potionpick=hasPicked;
    }

}
