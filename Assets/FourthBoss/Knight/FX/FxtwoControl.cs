using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxtwoControl : MonoBehaviour
{
  
  private float dieTimer=0.2f;
  public void Update()
    {
        
        dieTimer-=Time.deltaTime;
        if(dieTimer<0)
        {
            Destroy(gameObject);
        }
    }
}
