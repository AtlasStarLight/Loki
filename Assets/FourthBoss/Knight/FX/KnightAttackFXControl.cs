using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackFXControl : MonoBehaviour
{
  [SerializeField] GameObject[] pinkknightAttackFX;
  Animator am;
  public void Awake()
    {
        am=PinkKnight.instance.am;
    }

    public void UseAttack2Fx()
    {
        GameObject newone=Instantiate(pinkknightAttackFX[0],PinkKnight.instance.transform.position+new Vector3(0.8f*PinkKnight.instance.facedir,-0.58f,0),Quaternion.identity);
    }
}
