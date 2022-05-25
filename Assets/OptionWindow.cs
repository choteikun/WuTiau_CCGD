using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class OptionWindow : Window
{
    protected override void OnInit()
    {
        this.contentPane = UIPackage.CreateObject("", "").asCom;
        GSlider soundSlider = contentPane.GetChild("").asSlider;
        soundSlider.value = 1;
        soundSlider.onChanged.Add(() => { Debug.Log("滑動條當前的值===" + soundSlider.value); });
    }
    void Update()
    {

    }
}
