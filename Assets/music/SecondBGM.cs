using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        musicctorl.instance.PlayBGM(2);
    }

}
