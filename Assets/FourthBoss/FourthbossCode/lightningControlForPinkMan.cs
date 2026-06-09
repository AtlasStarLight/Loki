using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class lightningControlForPinkMan : MonoBehaviour
{
public Rigidbody2D rb=>GetComponent<Rigidbody2D>();
public SpriteRenderer sr=>GetComponent<SpriteRenderer>();
private  float SlowMoveTimer=1f;
private float FastMoveTimer=0.8f;
private float disTime=0.8f;
public float dir;
private float DieTimer=2f;
public static bool isPrefectInLightning=false;
private float prefectdistance;
private bool istrigger=false;
private bool hasGiveDamge=false;
public void Start()
    {
        Color c=sr.color;
      
    }
    public void UseThis(int Dir)
    {
        dir=Dir;
    }
public void  Update()
    {
        disTime-=Time.deltaTime;
        SlowMoveTimer-=Time.deltaTime;
        DieTimer-=Time.deltaTime;
    prefectdistance=Mathf.Abs(this.gameObject.transform.position.x-Player.instance.transform.position.x);
    if(prefectdistance<1&&DodgeState.isdodge)
        {
            isPrefectInLightning=true;
        }
        else
        {
            isPrefectInLightning=false;

        }
  if(isPrefectInLightning&&!istrigger)
        {
            PinkManPrefectDodge.instance. DoHitStop(0.05f,0.5f);
            istrigger=true;
        }
        if(!isPrefectInLightning)
        {
            istrigger=false;
        }
        if(SlowMoveTimer>0)
        {
            rb.velocity=new Vector2(1.2f*dir,0);

        }
        if(SlowMoveTimer<0)
        {
            FastMoveTimer-=Time.deltaTime;
            if(FastMoveTimer>0)
            {
                rb.velocity=new Vector2(70f*dir,0);
            }
            
        }
        if(DieTimer<0)
        {
            Destroy(gameObject);
            UseForFourthBoss.skillisdie=true;
          
        }
    }
  
   
void OnTriggerEnter2D(Collider2D other)
{
      if(other.GetComponent<Player>() == null) return;

    if(other.GetComponent<Player>() != null)
    {
        if(!isPrefectInLightning&&!hasGiveDamge)
            {
            PlayerStats.instance.currentHP-=100;
            hasGiveDamge=true;
            }//写的伤害函数，直接给扣500；如果详细用stats太麻烦了。debug这个记得。

        StartCoroutine(FadeOut());
    }
   
}
    IEnumerator FadeOut()
{
    float timer = 0f;
    Color c = sr.color;

    while(timer < disTime)
    {
        timer += Time.deltaTime;

        float t = timer / disTime; // 0~1
        c.a = Mathf.Lerp(1f, 0f, t);

        sr.color = c;

        yield return null; // 每帧执行
    }

    // 最后完全透明
    c.a = 0f;
    sr.color = c;
     UseForFourthBoss.skillisdie=true;

    Destroy(gameObject); // 可选：消失后删除
}
   

}
