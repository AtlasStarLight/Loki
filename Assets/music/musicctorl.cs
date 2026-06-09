using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using UnityEngine.Audio;

public class musicctorl : MonoBehaviour
{
    [SerializeField] AudioSource[] bgm;
    [SerializeField] AudioSource[] sfx;
    public static  musicctorl instance;
   public void Awake()
   {
  if(instance!=null&&instance!=this)
  {
  Destroy(gameObject);

  }
  else
        {
            instance=this;
             DontDestroyOnLoad(gameObject);
        }
   }

   public void CloseSFX()
    {
        
         for(int i=0;i<sfx.Length;i++)
        {
            sfx[i].Stop();
        }
    }
    public void CloseBGM()
    {
        
        for(int i=0;i<bgm.Length;i++)
        {
            bgm[i].Stop();
        }
    }
    public void PlayBGM(int index)
    {
        
       CloseBGM();
       bgm[index].Play();

     

    }
    public void PlayerSFX(int index)
    {
      CloseSFX();
      sfx[index].Play();

    }
}
