using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Light : MonoBehaviour
{
    string sceneName;
public void Start()
    {
        sceneName=SceneManager.GetActiveScene().name;
        if(sceneName=="first")
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
