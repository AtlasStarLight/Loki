using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSummonSkill : MonoBehaviour
{
   [SerializeField] GameObject holeprefab;

   public void UseSummon()
    {
        GameObject newone=Instantiate(holeprefab,DeathGod.instance.transform.position+new Vector3(5*DeathGod.instance.facedir,0,0),Quaternion.identity);
        
        
    }
}
