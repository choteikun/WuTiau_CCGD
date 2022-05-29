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
        optionWindow.SetXY(400, 150);
        
        rootUI.GetChild("OptionButton").onClick.Add(() => 
        {
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
            }
        }
    }
}
