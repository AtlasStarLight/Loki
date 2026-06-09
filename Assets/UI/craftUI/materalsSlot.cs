using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class materalsSlot : MonoBehaviour
{
   [SerializeField] Image materalIcon;
   [SerializeField] TextMeshProUGUI materalsamount;
  
   public void ShowMaterals(CraftThisMaterals materals)

    {
        

             materalIcon.sprite=materals.materals.Icon;
             materalsamount.text=materals.materalsamout.ToString();
    }

}
