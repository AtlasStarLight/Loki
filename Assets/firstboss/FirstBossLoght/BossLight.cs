using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossLight : MonoBehaviour
{
    [SerializeField]GameObject RecordLighter;
   public void OnEnable()
    {
        SceneManager.sceneLoaded+=UsingPlayer;
    }
    public void UsingPlayer(Scene  scene, LoadSceneMode loadSceneMode)
    {
        if(Player.instance!=null)
        {
            Player.instance.transform.position=RecordLighter.transform.position;
        }
    }
    public void OnDisable()
    {
        SceneManager.sceneLoaded-=UsingPlayer;
        
    }
}
