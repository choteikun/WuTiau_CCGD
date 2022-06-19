using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class OptionButton : MonoBehaviour
{
    public GameObject stopButtonUse;

    private GComponent rootUI;
    private OptionWindow optionWindow;
    private GameObject optionButtonClose;



    void Start()
    {      

        rootUI = GetComponent<UIPanel>().ui;
        
        optionWindow = new OptionWindow();
        //optionWindow.SetXY(400, 150);
        optionWindow.SetXY(Screen.width / 2 - 570, Screen.height / 2 - 400);
        
        rootUI.GetChild("OptionButton").onClick.Add(() => 
        {
            Time.timeScale = 0;
            stopButtonUse.SetActive(true);//將阻擋場景按鈕的Canvas Panel打開
            optionWindow.Show();//展示Option選單
        });

    }

    // Update is called once per frame
    void Update()
    {
        if (!optionButtonClose)//如果Option關閉按鈕為null
        {
            optionButtonClose = GameObject.Find("ButtonClose(Normal)");//尋找Option關閉按鈕
        }
        else
        {
            if (!optionButtonClose.activeSelf)
            {
                stopButtonUse.SetActive(false);//將阻擋場景按鈕的Canvas Panel關閉
                Time.timeScale = 1;
            }
        }
    }
}
