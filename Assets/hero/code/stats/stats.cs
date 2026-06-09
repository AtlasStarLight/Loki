using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class stats 
{
 [SerializeField] private  int baseValue;
 [SerializeField] private float UpdateValue;
 private List<int> modifier=new List<int>();
 public int  GetValue()
    {
        int finalvalue=baseValue;
        foreach(var value in modifier)
        {
            if(value!=0)
            {
                finalvalue+=value;
            }
        }  
   
return finalvalue;
    }
    public void AddValue(int value)
    {
       
        modifier.Add(value);
        ShowUpdateValue();


    }
    public void DeleteValue(int value)
    {
        modifier.Remove(value);
        ShowUpdateValue();
    }
  
public void ShowUpdateValue()
    {
        UpdateValue=GetValue();
    }

}
