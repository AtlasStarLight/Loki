using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class GeneralStart : MonoBehaviour
{
    [SerializeField]CanvasGroup canvasGroup;
    private float disappertime=0.5f;
    private bool istart=false;

public void Start()
    {
        musicctorl.instance.PlayBGM(0);
    }
  public void RestartGame()
    {
         Debug.Log("点击了 RestartGame");
        if(istart)
        {
            return;
        }
      
      SaveMager.instance.ResetGame();
     
     
        istart=true;
        if(istart)
        {
              StartCoroutine(FadeOutAndStart());
              
        }
       
       
    }
    public void StartGoOngame()
    {
         Debug.Log("点击了 startGame");
         if(istart)
        {
            return;
        }
      
        SaveMager.instance.EveryLevel();

        istart=true;
        if(istart)
        {
              StartCoroutine(FadeOutAndStart());
              
        }
    }
     private IEnumerator FadeOutAndStart()
    {
       
        float time=0f;
        while(time<disappertime)
        {
            time+=Time.deltaTime;
            canvasGroup.alpha=Mathf.Lerp(1f,0f,time/disappertime);
            yield return null;
        }
        canvasGroup.alpha=0;
        istart=false;

         SceneManager.LoadScene("SampleScene");
          Debug.Log("qiehuan");
        gameObject.SetActive(false);
    }
}
