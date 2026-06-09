using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShaderFallow : MonoBehaviour
{
[SerializeField] SpriteMask players;


public void OnEnable()
    {
        SceneManager.sceneLoaded+=UsingPlayer;
    }
    public void UsingPlayer(Scene  scene, LoadSceneMode loadSceneMode)
    {
        if(Player.instance!=null)
        {
            players.transform.position=Player.instance.transform.position;
        }
      
    }
    public void OnDisable()
    {
        SceneManager.sceneLoaded-=UsingPlayer;
        
    }
    public void Update()
    {
           if(Player.instance!=null)
        {
            players.transform.position=Player.instance.transform.position;
        }
       
    }
}
