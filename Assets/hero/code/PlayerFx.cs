using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFx : MonoBehaviour
{
    public static PlayerFx instance;
    public void Awake()
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
    public void ForceBuff(int Fvalue,float Fduarationtime)
    {
        StartCoroutine( UseForcePotion(Fvalue,Fduarationtime));
    }
    public void DefensiveBuff(int Dvalue,float DDt)
    {
        StartCoroutine(UseDefensivePotion(Dvalue,DDt));
    }
        
    
    public IEnumerator UseForcePotion(int value , float duarationtimer)
    {
        PlayerStats.instance.Damage.AddValue(value);
        yield return new WaitForSeconds(duarationtimer);
        PlayerStats.instance.Damage.DeleteValue(value);
    }
    public IEnumerator UseDefensivePotion(int value ,float duarationtimer)
    {
         PlayerStats.instance.Defensive.AddValue(value);
        yield return new WaitForSeconds(duarationtimer);
        PlayerStats.instance.Defensive.DeleteValue(value);
    }
}
