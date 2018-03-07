using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Btn_Option : MonoBehaviour
{

    private GameObject Start_option;
    private GameObject SelectGuan;
    public GameObject Start_UI;//三个面板
    public GameObject Root;//根节点

    //开始界面UI信息
    private Button btnStartUIOption;
    private Button btnStart;
    private Button btnAbout;

    //Option界面的UI信息
    private Button btnStartOptionReturn;

    //选关界面的UI信息
    private Button btnSelectGuanReturn;
    private Button btnLeft;
    private Button btnRight;
    private RectTransform selectGuanStage;
    private RectTransform Mask;
    //Stage界面的按钮
    private Button StageOneBtnOne;
    private Button StageOneBtnTwo;
    private Button StageOneBtnThree;

    private Button StageTwoBtnOne;
    private Button StageTwoBtnTwo;
    private Button StageTwoBtnThree;

    private Button StageThreeBtnOne;
    private Button StageThreeBtnTwo;
    private Button StageThreeBtnThree;


    //判断Option界面和选关界面是否存在
    private bool StartOptionPanelExist = false;
    private bool SelectGuanPanelExist = false;
    // Use this for initialization
    void Start()
    {
        Start_UI.transform.SetParent(Root.transform);
        btnStartUIOption = Start_UI.transform.Find("bg/Btn_Options").GetComponent<Button>();
        btnStartUIOption.onClick.AddListener(OnClickOption);
        btnStart = Start_UI.transform.Find("bg/Btn_Start").GetComponent<Button>();
        btnStart.onClick.AddListener(OnClickStart);

    }

    private void OnClickStart()
    {
        if (!SelectGuanPanelExist)
        {
            SelectGuan = Instantiate(Resources.Load("Prefab/UI/SelectGuan")) as GameObject;
            SelectGuan.transform.SetParent(Root.transform, false);
            StartOptionPanelExist = true;
        }
        if (SelectGuan != null)
        {
            SelectGuan.SetActive(true);
        }

        btnSelectGuanReturn = SelectGuan.transform.Find("btnReturn").GetComponent<Button>();
        btnSelectGuanReturn.onClick.AddListener(OnClickSSelectGuanReturn);
        btnLeft = SelectGuan.transform.Find("btnLeft").GetComponent<Button>();
        btnLeft.onClick.AddListener(OnBtnLeftClick);
        btnRight = SelectGuan.transform.Find("btnRight").GetComponent<Button>();
        btnRight.onClick.AddListener(OnBtnRightClick);
        selectGuanStage = SelectGuan.transform.Find("StageRoot").GetComponent<RectTransform>();
        Mask = selectGuanStage.transform.Find("Mask").GetComponent<RectTransform>();
        Mask.gameObject.SetActive(false);
        btnLeft.interactable = false;
        StageOneBtnOne = selectGuanStage.transform.Find("stageOne/btn1").GetComponent<Button>();
        StageOneBtnOne.onClick.AddListener(OnStageOneBtn1);
        StageOneBtnTwo = selectGuanStage.transform.Find("stageOne/btn2").GetComponent<Button>();
        StageOneBtnTwo.onClick.AddListener(OnStageOneBtn2);
        StageOneBtnThree = selectGuanStage.transform.Find("stageOne/btn3").GetComponent<Button>();
        StageOneBtnThree.onClick.AddListener(OnStageOneBtn3);
        StageTwoBtnOne = selectGuanStage.transform.Find("stageTwo/btn1").GetComponent<Button>();
        StageTwoBtnOne.onClick.AddListener(OnStageTwoBtn1);
        StageTwoBtnTwo = selectGuanStage.transform.Find("stageTwo/btn2").GetComponent<Button>();
        StageTwoBtnTwo.onClick.AddListener(OnStageTwoBtn2);
        StageTwoBtnThree = selectGuanStage.transform.Find("stageTwo/btn3").GetComponent<Button>();
        StageTwoBtnThree.onClick.AddListener(OnStageTwoBtn3);
        StageThreeBtnOne = selectGuanStage.transform.Find("stageThree/btn1").GetComponent<Button>();
        StageThreeBtnOne.onClick.AddListener(OnStageThreeBtn1);
        StageThreeBtnTwo = selectGuanStage.transform.Find("stageThree/btn2").GetComponent<Button>();
        StageThreeBtnTwo.onClick.AddListener(OnStageThreeBtn2);
        StageThreeBtnThree = selectGuanStage.transform.Find("stageThree/btn3").GetComponent<Button>();
        StageThreeBtnThree.onClick.AddListener(OnStageThreeBtn3);



        Start_UI.SetActive(false);
        if (Start_option != null)
        {
            Start_option.SetActive(false);
        }
    }

    private void OnStageThreeBtn3()
    {

    }

    private void OnStageThreeBtn2()
    {

    }

    private void OnStageThreeBtn1()
    {

    }

    private void OnStageTwoBtn3()
    {

    }

    private void OnStageTwoBtn2()
    {

    }

    private void OnStageTwoBtn1()
    {

    }

    private void OnStageOneBtn3()
    {

    }

    private void OnStageOneBtn2()
    {

    }

    private void OnStageOneBtn1()
    {

    }

    private void OnBtnRightClick()
    {
        Mask.gameObject.SetActive(true);
        Vector3 pos = selectGuanStage.transform.position + new Vector3(-1340, 0, 0);
        float dis = Vector3.Distance(selectGuanStage.transform.position, new Vector3(-2680, 0, 0));
        selectGuanStage.transform.DOMove(pos, 0.5f).OnComplete(JudgySelectGuanRjghtStagePos);
        if (dis<2030)
        {
            btnRight.interactable = false;
        }
        else
        {
            btnLeft.interactable = true;
        }
        Debug.Log("Right dis : " + dis);

    }

    private void JudgySelectGuanRjghtStagePos()
    {
        Mask.gameObject.SetActive(false);
    }

    private void OnBtnLeftClick()
    {
        Mask.gameObject.SetActive(true);
        Vector3 pos = selectGuanStage.transform.position + new Vector3(1340, 0, 0);
        selectGuanStage.transform.DOMove(pos, 0.5f).OnComplete(JudgySelectGuanLeftStagePos);
        float dis = Vector3.Distance(selectGuanStage.transform.position, new Vector3(0, 0, 0));
        if (dis <810)
        {
            btnLeft.interactable = false;
        }
        else
        {
            btnRight.interactable = true;
        }
        Debug.Log("Left dis : " +dis);
    }

    private void JudgySelectGuanLeftStagePos()
    {
        Mask.gameObject.SetActive(false);
    }

    public void OnClickOption()
    {

        if (!StartOptionPanelExist)
        {
            Start_option = Instantiate(Resources.Load("Prefab/UI/StartUI_Option")) as GameObject;
            Start_option.transform.SetParent(Root.transform, false);
            StartOptionPanelExist = true;
        }
        if (Start_option != null)
        {
            Start_option.SetActive(true);
        }
        btnStartOptionReturn = Start_option.transform.Find("bg/btnReturn").GetComponent<Button>();
        btnStartOptionReturn.onClick.AddListener(OnClickSSelectGuanReturn);
        Start_UI.SetActive(false);
        if (SelectGuan != null)
        {
            SelectGuan.SetActive(false);
        }

    }

    private void OnClickSSelectGuanReturn()
    {
        Start_UI.SetActive(true);
        if (Start_option != null)
        {
            Start_option.SetActive(false);
        }
        if (SelectGuan != null)
        {
            SelectGuan.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
