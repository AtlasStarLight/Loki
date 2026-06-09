using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class musicsettings : MonoBehaviour
{
  
    [SerializeField] Slider slider;
    public string parametr;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float multiplier;
    public void Awake()
    {
        slider.value=1;
    }

    public void SliderValue(float _value)
    {
        audioMixer.SetFloat(parametr, Mathf.Log10(_value) * multiplier);
    }

}
