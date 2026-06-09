using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXoneControl : MonoBehaviour
{
   Rigidbody2D rb=>GetComponent<Rigidbody2D>();
   private float moveTimer=0.8f;
   private bool hasTrigger=false;
   public void Update()
    {
       if(PinkKnight.instance.facedir<0&&!hasTrigger)
        {
            transform.Rotate(0,180,0);
            hasTrigger=true;
        }
        rb.velocity=new Vector2(PinkKnight.instance.facedir*3f,0);
        
        moveTimer-=Time.deltaTime;
        if(moveTimer<0)
        {
          
            Destroy(gameObject);
        }
    }
}
