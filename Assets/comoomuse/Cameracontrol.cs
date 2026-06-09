using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;



public class Cameracontrol : MonoBehaviour
{
        [SerializeField] private CinemachineVirtualCamera currentone;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += UsingPlayer;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= UsingPlayer;
    }

    private void UsingPlayer(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(BindPlayer());
    }

    private IEnumerator BindPlayer()
    {
        while (Player.instance == null)
        {
            yield return null;
        }

        currentone.Follow = Player.instance.transform;
    }
}