using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FifthBoss : MonoBehaviour,Isave
{
    private float PassTimer = 20f;

    [SerializeField] GameObject targetplace;

    private bool isInTarget = false;
    private bool hasJumap = false;

    private bool lastSwitchActiveState;
    private float debugTimer = 0f;
    private bool ispass=false;

public void Awake()
    {
               Switchscence.instance.gameObject.SetActive(false);
    }
    private void Start()
    {
              Switchscence.instance.gameObject.SetActive(false);
            SaveMager.instance.EveryLevel();
    }

    public void Update()
    {
        DebugCheckSwitchStatueState();

        if (Input.GetKeyDown(KeyCode.B))
        {
            hasJumap = true;

            Debug.Log(
                "【检测到跳跃键B】" +
                " hasJumap=" + hasJumap +
                " Time=" + Time.time
            );
        }

        if (!isInTarget)
        {
            PassTimer -= Time.deltaTime;

            float distance = Player.instance.transform.position.x - targetplace.transform.position.x;
            float absdistance = Mathf.Abs(distance);

            debugTimer -= Time.deltaTime;

            if (debugTimer <= 0)
            {
                debugTimer = 1f;

                Debug.Log(
                    "【FifthBoss 每秒检测】" +
                    " PlayerX=" + Player.instance.transform.position.x +
                    " TargetName=" + targetplace.name +
                    " TargetX=" + targetplace.transform.position.x +
                    " absdistance=" + absdistance +
                    " PassTimer=" + PassTimer +
                    " hasJumap=" + hasJumap +
                    " isInTarget=" + isInTarget +
                    " SwitchActive=" + Switchscence.instance.gameObject.activeSelf +
                    " SwitchPos=" + Switchscence.instance.transform.position
                );
            }

            if (absdistance < 1 && !hasJumap && PassTimer > 0)
            {

               ispass=true;
               if(ispass)
                {
                    Debug.Log(
                    "【FifthBoss 准备打开通关雕塑】" +
                    " 原因=玩家到达终点" +
                    " PlayerX=" + Player.instance.transform.position.x +
                    " TargetName=" + targetplace.name +
                    " TargetX=" + targetplace.transform.position.x +
                    " absdistance=" + absdistance +
                    " PassTimer=" + PassTimer +
                    " hasJumap=" + hasJumap +
                    " 打开前SwitchActive=" + Switchscence.instance.gameObject.activeSelf +
                    " 打开前SwitchPos=" + Switchscence.instance.transform.position
                );

                Switchscence.instance.gameObject.SetActive(true);

                Debug.Log(
                    "【FifthBoss 已执行 SetActive(true)】" +
                    " 打开后SwitchActive=" + Switchscence.instance.gameObject.activeSelf +
                    " 打开后SwitchPos=" + Switchscence.instance.transform.position
                );

                Switchscence.instance.SwitchCurrentSecene();

                Debug.Log(
                    "【FifthBoss 已执行 SwitchCurrentSecene】" +
                    " SwitchActive=" + Switchscence.instance.gameObject.activeSelf +
                    " SwitchPos=" + Switchscence.instance.transform.position
                );

                isInTarget = true;
                return;
                }
                
            }

            if (hasJumap || (PassTimer < 0 && absdistance > 1))
            {
                Debug.Log(
                    "【FifthBoss 死亡触发】" +
                    " hasJumap=" + hasJumap +
                    " JumpState.isJump=" + JumpState.isJump +
                    " PassTimer=" + PassTimer +
                    " absdistance=" + absdistance +
                    " PlayerX=" + Player.instance.transform.position.x +
                    " TargetName=" + targetplace.name +
                    " TargetX=" + targetplace.transform.position.x +
                    " SwitchActive=" + Switchscence.instance.gameObject.activeSelf +
                    " SwitchPos=" + Switchscence.instance.transform.position
                );

                PlayerStats.instance.currentHP = 0;
                Player.instance.playerStateSwitcher.ChangeState(Player.instance.dieState);
                return;
            }
        }

        if (isInTarget)
        {
            PassTimer = 20f;
        }
    }

    private void DebugCheckSwitchStatueState()
    {
        if (Switchscence.instance == null)
        {
            return;
        }

        bool currentActive = Switchscence.instance.gameObject.activeSelf;

        if (currentActive != lastSwitchActiveState)
        {
            Debug.Log(
                "【通关雕塑Active状态变化】" +
                " 从=" + lastSwitchActiveState +
                " 变成=" + currentActive +
                " 当前时间=" + Time.time +
                " 当前场景=" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name +
                " 雕塑位置=" + Switchscence.instance.transform.position +
                " PlayerX=" + Player.instance.transform.position.x +
                " TargetName=" + targetplace.name +
                " TargetX=" + targetplace.transform.position.x
            );

            lastSwitchActiveState = currentActive;
        }
    }

    public void LoadData(GameData gameData)
    {
       ispass=gameData.fifthisover;
       if(ispass)
        {
             Switchscence.instance.gameObject.SetActive(true);
                Switchscence.instance.SwitchCurrentSecene();
        }
    }

    public void SaveData(ref GameData gameData)
    {
     gameData.fifthisover=ispass;
    }
}