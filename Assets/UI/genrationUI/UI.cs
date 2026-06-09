using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{
    public bool timecolddown;
  [SerializeField] GameObject[] AllUI;
  [SerializeField] GameObject[] contrastUI; 
  public static UI instance;
  public void Awake()
    {
        timecolddown=false;
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
  public void Start()
    {
        OpenAllContrastUI();
     CloseUI();
    }
    public void CloseUI()
    {
        for(int i=0;i<AllUI.Length;i++)
        {
            AllUI[i].gameObject.SetActive(false);
        } 
        OpenAllContrastUI();
     timecolddown=false;
    }//前面都是关的；
    public void OpenBag(GameObject bag)
    {
     
        CloseUI();
      CloseContrastUI();
         timecolddown=true;
        bag.gameObject.SetActive(true);
    }
    public void KeyBoardControl(GameObject bag)

    {
        if(bag.gameObject.activeSelf)
        {
            CloseUI();
          
        }
        else
        {
            OpenBag(bag);
          
        }
    }//一套俩按键控制这个ui的开关，另外一个键盘控制打开和关闭
    
      public void OpenCraft(GameObject Craft)
    {
     
        CloseUI();
         CloseContrastUI();
         timecolddown=true;
        Craft.gameObject.SetActive(true);
    }
    public void KeyBoardControlCraft(GameObject Craft)

    {
        if(Craft.gameObject.activeSelf)
        {
            CloseUI();
           
             
        }
        else
        {
             CloseContrastUI();
         
        }
    }
        public void OpenSettings(GameObject Settings)
    {
     
        CloseUI();
        CloseContrastUI();
         timecolddown=true;
        Settings.gameObject.SetActive(true);
    }
    public void KeyBoardControlSetings(GameObject Settings)

    {
        if(Settings.gameObject.activeSelf)
        {
            CloseUI();
            
        }
        else
        {
            OpenSettings(Settings);
         
        }
    }//
            public void OpenSkills(GameObject skills)
    {
     
        CloseUI();
         CloseContrastUI();
         timecolddown=true;
        skills.gameObject.SetActive(true);
    }
    public void KeyBoardControlSkills(GameObject skills)

    {
        if(skills.gameObject.activeSelf)
        {
            CloseUI();
        
        }
        else
        {
            OpenSkills(skills);
           
        }
    }//
    public void CloseContrastUI()
    {
        for(int i=0;i<contrastUI.Length;i++)
        {
            contrastUI[i].SetActive(false);
        }
    }
    public void OpenAllContrastUI()
    {
       for(int i=0;i<contrastUI.Length;i++)
        {
            contrastUI[i].SetActive(true);
        } 
    }

}
