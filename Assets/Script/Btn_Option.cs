using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Option : MonoBehaviour {

    public Button btnOption;
    private GameObject Instance;
	// Use this for initialization
	void Start () {
        btnOption.GetComponent<Button>().onClick.AddListener(() =>{ OnClickOption(); });
   
    }

    public void OnClickOption()
    {
        GameObject obj = Instantiate(Resources.Load("Prefab/UI/StartUI_Option")) as GameObject;
      
    }

    // Update is called once per frame
    void Update () {
		
	}
}
