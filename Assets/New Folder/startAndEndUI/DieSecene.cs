using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class DieSecene : MonoBehaviour
{
    public static DieSecene instance;
    [SerializeField]CanvasGroup canvasGroup;
    private float disappertime=0.5f;
    private bool istart=false;

public void Awake()
    {
        if(instance!=null&&instance!=this)
        {
            Debug.LogError("发现重复 DieSecene，销毁这个：" + gameObject.name);
            Destroy(gameObject);

        }
        else
        {
            instance=this;
                DontDestroyOnLoad(gameObject);
        }

    
      
    }
    public void Start()
    {
       gameObject.SetActive(false);
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

            SaveMager.instance.ResetGame();
       
       
    }
    public void StartGoOngame()
    {
         Debug.Log("点击了 startGame");
         if(istart)
        {
            return;
        }
      
       PlayerStats.instance.currentHP=PlayerStats.instance.HP.GetValue();

        istart=true;
        if(istart)
        {
              StartCoroutine(FadeOutAndStartReLife());
              
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
      Player.instance.transform.position=new Vector3(0,0,0);
          Debug.Log("qiehuan");
        gameObject.SetActive(false);
        
    }
       private IEnumerator FadeOutAndStartReLife()
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

      
      Player.instance.transform.position=new Vector3(0,0,0);
          Debug.Log("qiehuan");
        gameObject.SetActive(false);
        
    }
      public IEnumerator FadeInAndStart()
    {
       
        float time=0f;
        while(time<disappertime)
        {
            time+=Time.deltaTime;
            canvasGroup.alpha=Mathf.Lerp(0f,1f,time/disappertime);
            yield return null;
        }
        canvasGroup.alpha=1;
    
         gameObject.SetActive(true);

     
        
    }
    public void StartIn()
    {
        StartCoroutine(FadeInAndStart());
    }

}
