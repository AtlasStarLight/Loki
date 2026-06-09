using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Holecontrol : MonoBehaviour

   {
    [SerializeField] GameObject enemyPrefab;
   
   
public void SetHoleAM()
    {
        
    }
    public void CloseAM()
    {
        
    }
   public void OnEnable()
    {
        SummonEnemies();
    }
    public void SummonEnemies()
    {
        for(int i=0;i<5;i++)
        {
            float postion=Random.Range(0,3);
             GameObject newone=Instantiate(enemyPrefab,this.gameObject.transform.position+new Vector3(postion,postion,0),Quaternion.identity);
             newone.GetComponent<SkeletonCobtrol>().UseThis();
            
        }

    
       Destroy(gameObject,2f);
    }
}
