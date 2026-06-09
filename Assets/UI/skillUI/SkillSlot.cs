using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public bool canUse;
    public int money;
    [SerializeField] deskSkillSlot desk;
    [SerializeField] GameObject thisskillone;
    [SerializeField] Image skillIcon;
        [SerializeField] SkillSlot[] shouldbeunclocked;
    [SerializeField] SkillSlot[] shouldbeclocked;
    private Button skillbutton;
    public void Awake()
    {
    skillbutton=GetComponent<Button>();
    skillbutton.onClick.AddListener(()=>SkillSlotTips());
skillIcon.color=Color.gray;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       thisskillone.GetComponent<Skillboard>().UseThis();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        thisskillone.GetComponent<Skillboard>().CloseThis();
    }

    public void SkillSlotTips()
    {
        if( SkillManger.instance.Usemoney(money)==false)
        {
            return;
        }
        for(int i=0;i<shouldbeunclocked.Length;i++)
        {
            if(shouldbeunclocked[i].canUse==false)
            {
                return;
            }
        }
        for(int i=0;i<shouldbeclocked.Length;i++)
        {
            if(shouldbeclocked[i].canUse==true)
            {
                return;
            }
        }
        canUse=true;
        desk.Usethis();
        skillIcon.color=Color.white;

    }

    
}
