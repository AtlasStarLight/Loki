using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PinkManPrefectDodge : MonoBehaviour
{
      public static PinkManPrefectDodge instance;

    private Coroutine currentCoroutine;
    public static bool isTrigger=false;
    [SerializeField] float normalsize=5f;
    [SerializeField] float fucoussize=0.8f;
     [SerializeField] float zoomInTime = 0.3f;
    [SerializeField] float zoomOutTime = 0.3f;
    public static bool isInHitStop=false;



[SerializeField] CinemachineVirtualCamera cvm;

    private void Awake()
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

    public void DoHitStop(float timeScale, float duration)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        currentCoroutine = StartCoroutine(HitStopCoroutine(timeScale, duration));
    }

    private IEnumerator HitStopCoroutine(float timeScale, float duration)
    {
        isInHitStop=true;
 
    // ---------- 1. 时间平滑减速 ----------
    float slowInTime = 0.1f;
    float t0 = 0f;

    while (t0 < slowInTime)
    {
        t0 += Time.unscaledDeltaTime;
        float t = t0 / slowInTime;
        Time.timeScale = Mathf.Lerp(1f, timeScale, t);
        yield return null;
    }
  
    float startSize = cvm.m_Lens.OrthographicSize;
     float timer = 0f;
    while (timer < zoomInTime)
    {
        timer += Time.unscaledDeltaTime;
        float t = timer / zoomInTime;
        cvm.m_Lens.OrthographicSize = Mathf.Lerp(startSize, fucoussize, t);
        yield return null;
    }


   

    // ---------- 3. 保持慢动作 ----------
    Time.timeScale = timeScale;
    yield return new WaitForSecondsRealtime(duration);
    
    cvm.m_Lens.OrthographicSize = normalsize;

    // ---------- 4. 时间平滑恢复 ----------
    float restoreTime = 0.5f;
    float t2 = 0f;

    while (t2 < restoreTime)
    {
        t2 += Time.unscaledDeltaTime;
        float t = t2 / restoreTime;
        Time.timeScale = Mathf.Lerp(timeScale, 1f, t);
        yield return null;
    }

    Time.timeScale = 1f;

    // ---------- 5. 相机缩回 ----------
     timer = 0f;
    float currentSize = cvm.m_Lens.OrthographicSize;

    while (timer < zoomOutTime)
    {
        timer += Time.unscaledDeltaTime;
        float t = timer / zoomOutTime;
        cvm.m_Lens.OrthographicSize = Mathf.Lerp(currentSize, normalsize, t);
        yield return null;
    }

   

    currentCoroutine = null;
           isInHitStop=false;
    }
    public void StartPrefectDodge()
    {
         if(PinkManAttack.PinkManPrefectDodge&&!isTrigger)
        {
           
            DoHitStop(0.05f,0.5f);
     
           
           

            isTrigger=true;
        }
        else if(PinkKnightAttack.PinkKnightPrefectDodge&&!isTrigger)
        {
                
            DoHitStop(0.05f,0.5f);
     
           
           

            isTrigger=true;
        }
        

    }
    public void EndTheDoge()
    {
        if(PinkManAttack.PinkManPrefectDodge==false||PinkKnightAttack.PinkKnightPrefectDodge==false)
        {
            isTrigger=false;
        }
    }
    public void Update()
    {
       

        
         
    }
}
