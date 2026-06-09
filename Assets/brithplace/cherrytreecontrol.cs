using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherrytreecontrol : MonoBehaviour
{
 private float timer=2;
[SerializeField]ParticleSystem flowerFX;
    // Update is called once per frame
 public void Start()
    {
        musicctorl.instance.PlayBGM(0);
    }
    public void Update()
    {
    timer-=Time.deltaTime;
    if(timer<0)
        {
            flowerFX.Stop();
            if(timer<-7)
            {
                timer=2;
                flowerFX.Play();
            }
        }
        
    }


}
