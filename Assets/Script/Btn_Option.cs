using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Option : MonoBehaviour
{

    private  GameObject Start_option;
    public GameObject Start_UI;
    public GameObject Root;
    private Button btnStartUIOption;
    private Button btnStartOptionReturn;
    private GameObject Instance;
    private bool StartOptionPanelExist=false;
    // Use this for initialization
    void Start()
    {
        Start_UI.transform.SetParent(Root.transform);
        btnStartUIOption = Start_UI.transform.Find("bg/Btn_Options").GetComponent<Button>();
        btnStartUIOption.onClick.AddListener(OnClickOption);


    }

    public void OnClickOption()
    {
 
        if (!StartOptionPanelExist)
        {
            Start_option = Instantiate(Resources.Load("Prefab/UI/StartUI_Option")) as GameObject;
            Start_option.transform.SetParent(Root.transform,false);
            StartOptionPanelExist = true;
        }
        if (Start_option!=null)
        {
            Start_option.SetActive(true);
        }
        btnStartOptionReturn = Start_option.transform.Find("bg/btnReturn").GetComponent<Button>();
        btnStartOptionReturn.onClick.AddListener(OnClickReturn);
        Start_UI.SetActive(false);

    }

    private void OnClickReturn()
    {
        Start_UI.SetActive(true);
        Start_option.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
