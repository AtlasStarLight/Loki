using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScondOfFirstBoss : MonoBehaviour
{
   public static ScondOfFirstBoss instance;
   [SerializeField] float attackradius;
   [SerializeField] Transform thisSkeleton;
   public SecondBossStats secondBossStats=>GetComponent<SecondBossStats>();
   public void Awake()
    {
        if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }
    } 

    public void OnDrawGizmos()
    {
Gizmos.DrawWireSphere(thisSkeleton.position,attackradius);
        
    }
    public void Die()
    {
        if(secondBossStats.currentHP==0)
        {
            Destroy(gameObject,0.5f);
        }
        
    }
}
