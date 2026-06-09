using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillboard : MonoBehaviour
{
  

       public void Start()
    {
        this.gameObject.SetActive(false);
         ChildrenControl();

    }
    public void UseThis()
    {
        this.gameObject.SetActive(true);
         ChildrenControl();

    }
    public void CloseThis()
    {
        this.gameObject.SetActive(false);
        ChildrenControl();
    }
    public void ChildrenControl()
    {
       if(this.gameObject.activeSelf)
        {for(int i=0;i<transform.childCount;i++)
            {
                 gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
          for(int i=0;i<transform.childCount;i++)
            {
                 gameObject.transform.GetChild(i).gameObject.SetActive(false);
            } 
        }
    }
}
