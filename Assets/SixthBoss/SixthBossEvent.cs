using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthBossEvent : MonoBehaviour
{
    [SerializeField] GameObject[] skills;

    [Header("爆炸球飞行")]
    [SerializeField] float starFlyTime = 1.2f;
    [SerializeField] float starCurveHeight = 2.5f;
public static bool hasUseSkills=false;
    public void UseSkills()
    {
            hasUseSkills=true;
        if (SixthBossStats.instance.currentHP > 300)
        {
            int c = Random.Range(0,2);

            if (c == 0)
            {
                GameObject neone = Instantiate(
                    skills[0],
                    SixthBossOfCrowKnight.instance.transform.position,
                    Quaternion.identity
                );

                StartCoroutine(FlyToScreenCenter(neone));
               
            }
            else if (c == 1)
            {
                CreateFiveExplosionStars();
            }
        }
    }

    private void CreateFiveExplosionStars()
    {
        Vector3 bossPos = SixthBossOfCrowKnight.instance.transform.position;

        Vector3[] targets = GetFiveScreenTargetPositions();

        for (int i = 0; i < 5; i++)
        {
            GameObject star = Instantiate(
                skills[1],
                bossPos,
                Quaternion.identity
            );

            StartCoroutine(FlyStarToPosition(star, targets[i]));
        }
    }

    private Vector3[] GetFiveScreenTargetPositions()
    {
        Vector3[] targets = new Vector3[5];

        targets[0] = ScreenToWorld(0.2f, 0.45f);
        targets[1] = ScreenToWorld(0.35f, 0.65f);
        targets[2] = ScreenToWorld(0.5f, 0.5f);
        targets[3] = ScreenToWorld(0.65f, 0.65f);
        targets[4] = ScreenToWorld(0.8f, 0.45f);

        return targets;
    }

    private Vector3 ScreenToWorld(float xRate, float yRate)
    {
        Vector3 screenPos = new Vector3(
            Screen.width * xRate,
            Screen.height * yRate,
            10f
        );

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0f;

        return worldPos;
    }

    private IEnumerator FlyStarToPosition(GameObject obj, Vector3 targetPos)
    {
        Vector3 startPos = obj.transform.position;

        float timer = 0f;

        while (timer < starFlyTime)
        {
            timer += Time.deltaTime;

            float t = timer / starFlyTime;

            Vector3 linePos = Vector3.Lerp(startPos, targetPos, t);

            float height = Mathf.Sin(t * Mathf.PI) * starCurveHeight;

            obj.transform.position = linePos + Vector3.up * height;

            yield return null;
        }

        obj.transform.position = targetPos;

        starExprosion star = obj.GetComponent<starExprosion>();

        if (star != null)
        {
            star.UseThis();
        }
    }

    private IEnumerator FlyToScreenCenter(GameObject obj)
    {
        Vector3 startPos = obj.transform.position;

        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 10f);
        Vector3 endPos = Camera.main.ScreenToWorldPoint(screenCenter);
        endPos.z = 0f;

        float flyTime = 3f;
        float curveHeight = 3f;
        float timer = 0f;

        while (timer < flyTime)
        {
            timer += Time.deltaTime;

            float t = timer / flyTime;

            Vector3 linePos = Vector3.Lerp(startPos, endPos, t);

            float height = Mathf.Sin(t * Mathf.PI) * curveHeight;
 
            obj.transform.position = linePos + Vector3.up * height;

            yield return null;
        }

        obj.transform.position = endPos;
         obj.GetComponent<sixthBlackHoleControl>().UseThis();
    }
    public void Update()
    {
        if(SixthBossMagic.isSixthMagic&&!hasUseSkills)
        {
            UseSkills();
        
        }
        if(!SixthBossMagic.isSixthMagic)
        {
             hasUseSkills=false;
            
        }

    }
}