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
            stopButtonUse.SetActive(true);//�N���׳������s��Canvas Panel���}
            optionWindow.Show();//�i��Option���
        });

    }

    // Update is called once per frame
    void Update()
    {
        if (!optionButtonClose)//�p�GOption�������s��null
        {
            optionButtonClose = GameObject.Find("ButtonClose(Normal)");//�M��Option�������s
        }
        else
        {
            if (!optionButtonClose.activeSelf)
            {
                stopButtonUse.SetActive(false);//�N���׳������s��Canvas Panel����
                Time.timeScale = 1;
            }
        }
    }
}
