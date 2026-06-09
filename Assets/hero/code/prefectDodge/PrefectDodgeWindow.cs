using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefectDodgeWindow : MonoBehaviour
{
  public static bool NiceDodge=false;
  public void InPrefectDoDgeWindow()
    {
        NiceDodge=true;
    }
    public void OutPrefectWindow()
    {
        NiceDodge=false;
    }
}
