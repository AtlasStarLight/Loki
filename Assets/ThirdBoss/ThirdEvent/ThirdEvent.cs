using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ThirdEvent : MonoBehaviour,Isave
{
    
    [Header("first stage record")]
    private bool isinFirstStage=true;
    [Header("Third stage record")]
    private bool isinThirdStage=false;
    private float ThirdstageTimer=90f;
    private bool isrecordThirdStage=false;
    private bool ThirdstageBuff=false;
    [Header("second stage record")]
    private float secondStageTimer=70f;
    private bool isinSecondStage=false;
    private bool secondstagebuff=false;
    private bool isrecordSecondstage=false;
    private int currentStage=0;
 
    [SerializeField] GameObject realBossPrefab;
    private bool isComeOut=false;
    private float firsttimer=10f;
    private bool hasrealBoss=false;
    [SerializeField] Transform findEnemy;
    [SerializeField] float radius;
    [SerializeField] LayerMask enemy;
    [Header("first stage record")]
    private bool isRecord=false;
    private bool firstPlusBuff=false;
    [SerializeField] List<Itemdata> BossDrop;
    [SerializeField] GameObject prefab;
    private bool hasOver=false;
    private bool isfinish=false;
    private bool isxxx=false;
   


    public void Start()
    {
        SaveMager.instance.EveryLevel();
    }
    public void FirstStage()
    {
        
        currentStage=1;

        if(AttackState.isAttack&&JackOfthird.instance.InAttackSphere())
        {
                     firstPlusBuff=true;
          

        }
      
        

    }
    public void SecondStage()
    {
        currentStage=2;

        if(AttackState.isAttack&&JackOfthird.instance.InAttackSphere())
        {
            secondstagebuff=true;
           
           

        }
    }
    public void ThirdStage()
    {
        

         currentStage=3;

        if(AttackState.isAttack&&JackOfthird.instance.InAttackSphere())
        {
            ThirdstageBuff=true;
            
          

        }
    }
    public IEnumerator AskRealBoss()
    {

        for(int i=0;i<5;i++)
        {
            GameObject realBoss=Instantiate(realBossPrefab,new Vector3(-6,-2,0),Quaternion.identity);
         if(isRecord&&currentStage==1)
            {
            realBossStats thisone=realBoss.GetComponent<realBossStats>();
               thisone.Damage.AddValue(100);
            thisone.HP.AddValue(300);
            thisone.currentHP=thisone.HP.GetValue();
        
            
            }
            else if(isrecordSecondstage&&currentStage==2)
            { realBossStats thisone=realBoss.GetComponent<realBossStats>();
               thisone.Damage.AddValue(500);
            thisone.HP.AddValue(1000);
            thisone.currentHP=thisone.HP.GetValue();
            
                
            }
            else if(isrecordThirdStage||currentStage==3)
            {
                realBossStats thisone=realBoss.GetComponent<realBossStats>();
               thisone.Damage.AddValue(10000);
            thisone.HP.AddValue(10000);
            thisone.currentHP=thisone.HP.GetValue();
            }

             yield return new WaitForSeconds(2f);
        }
    }
    public bool FindEnemy()
    {
    Collider2D enemies=Physics2D.OverlapCircle(findEnemy.position,radius,enemy);
    
    if(enemies==null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(findEnemy.position,radius);
    }
    public void Update()
    {
        if(isinFirstStage)
        {
            
             firsttimer-=Time.deltaTime;
        if(firsttimer>0&&!isRecord)
        {
            FirstStage();
            if(firstPlusBuff==true)
            {
                isRecord=true;
            }
        }
   
        if(firsttimer<0&&!hasrealBoss)
        {
          
            StartCoroutine(AskRealBoss());
            JackOfthird.instance.gameObject.SetActive(false);
            
            hasrealBoss=true;
        }
        }
      FindEnemy();
      if(FindEnemy()&&currentStage==1&&firsttimer<0)
        {
        isinSecondStage=true;
        isinFirstStage=false;
        hasrealBoss=false;
        JackOfthird.instance.gameObject.SetActive(true);
        JackOfthird.instance.jackStateSwitcher2.ChangeState(JackOfthird.instance.jackIdleState);
        }
        if(isinSecondStage)
        {
            secondStageTimer-=Time.deltaTime;
            if(secondStageTimer>0&&!isrecordSecondstage)
            {
                SecondStage();
                if(secondstagebuff)
                {
                    isrecordSecondstage=true;
                }
            }
            if(secondStageTimer<0&&!hasrealBoss)
            {
                StartCoroutine(AskRealBoss());
                JackOfthird.instance.gameObject.SetActive(false);
                hasrealBoss=true;
            }

        }
        if(FindEnemy()&&currentStage==2&&secondStageTimer<0)
        {
            isinSecondStage=false;
            isinThirdStage=true;
            isinFirstStage=false;
            hasrealBoss=false;
            JackOfthird.instance.gameObject.SetActive(true);
             JackOfthird.instance.jackStateSwitcher2.ChangeState(JackOfthird.instance.jackIdleState);
        }
        if(isinThirdStage)
        {
            ThirdstageTimer-=Time.deltaTime;
            if(ThirdstageTimer>0&&!isrecordThirdStage)
            {
                ThirdStage();
                if(ThirdstageBuff)
                {
                    isrecordThirdStage=true;
                }
            }
            if(ThirdstageTimer<0&&!hasrealBoss)
            {
                StartCoroutine(AskRealBoss());
                JackOfthird.instance.gameObject.SetActive(false);
                hasrealBoss=true;
                
            }
        }
        if(FindEnemy()&&currentStage==3&&ThirdstageTimer<0&&!isxxx)
        {
            //小兵死完了。
         
            JackOfthird.instance.jackStateSwitcher2.ChangeState(JackOfthird.instance.jackDieState);
               isfinish=true;
            SaveMager.instance.SaveGame();
            Switchscence.instance.gameObject.SetActive(true);
            Switchscence.instance.SwitchCurrentSecene();
            if(!hasOver)
            {
                 for(int i=0;i<BossDrop.Count;i++)
            {
             GameObject newone=Instantiate(prefab,this.transform.position,Quaternion.identity);
             newone.GetComponent<ItemObject>().SetIcon(BossDrop[i]);
           
            }
              hasOver=true;
                
            }
            isxxx=true;
            Destroy(JackOfthird.instance.gameObject);
            Destroy(gameObject);
              //下次记得写注释。劳资真的自己都看不懂了我操你妈逼的。
        }

      
        
    }

    public void LoadData(GameData gameData)
    {
        isfinish=gameData.thirdBosshasover;
        if(isfinish)
        {
                Switchscence.instance.gameObject.SetActive(true);
            Switchscence.instance.SwitchCurrentSecene();
            Destroy(JackOfthird.instance.gameObject);
            Destroy(gameObject);
            
        }

    }

    public void SaveData(ref GameData gameData)
    {
        gameData.thirdBosshasover=isfinish;
    }
}
