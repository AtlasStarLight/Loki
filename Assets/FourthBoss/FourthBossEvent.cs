using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthBossEvent : MonoBehaviour,Isave
{
    private bool hasover=false;
    private bool istrgeer=false;
    private bool isSSgger=false;
    public void Awake()
    {
          Switchscence.instance.gameObject.SetActive(false);
    }

    public void LoadData(GameData gameData)
    {
       PInkManStats.instance.currentHP=gameData.fourtBossHP;
       hasover=gameData.forthHasover;

    }

    public void SaveData(ref GameData gameData)
    {
       gameData.fourtBossHP=PInkManStats.instance.currentHP;
       gameData.forthHasover=this.hasover;
        
       

    }

    public void Start()
    {
        Switchscence.instance.gameObject.SetActive(false);
           SaveMager.instance.EveryLevel();
    }
    public void Update()
    {
        if(PInkManStats.instance.currentHP<=0&&PinkKnight.instance==null&&!isSSgger)
        {
            hasover=true;
                SaveMager.instance.SaveGame();
                isSSgger=true;
          
            
        }
          if(hasover&&!istrgeer)
            {

                 Switchscence.instance.gameObject.SetActive(true);
            Switchscence.instance.SwitchCurrentSecene();
            istrgeer=true;
             
             Destroy(gameObject);

             
               
           
            }
      
    }
}
