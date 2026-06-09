using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PassiveSkillSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public int money;
   [SerializeField] Button passiveskillbutton;
   [SerializeField] GameObject passiveboard;
   [SerializeField] Image skillicon;
   public static bool CanUse;
   public void Awake()
    {
        passiveskillbutton.GetComponent<Button>().onClick.AddListener(()=>UsePassiveSkill());
    }
    public void Start()
    {
        skillicon.color=Color.gray;
        CanUse=false;
    }
    public void UsePassiveSkill()
    {
      CanUse=true;
        skillicon.color=Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       passiveboard.GetComponent<Skillboard>().UseThis();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
   passiveboard.GetComponent<Skillboard>().CloseThis();
    }
}
