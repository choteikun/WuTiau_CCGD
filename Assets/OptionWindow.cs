using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class OptionWindow : Window
{
    protected override void OnInit()
    {
        this.contentPane = UIPackage.CreateObject("OptionPackage", "OptionWindow").asCom;    

        GSlider soundSlider = this.contentPane.GetChild("SoundSlider").asSlider;
        GSlider screenBrightness = this.contentPane.GetChild("ScreenBrightness").asSlider;
        soundSlider.value = 10;
        soundSlider.onChanged.Add(() => 
        {
            AudioSourceController.volumeAllScale = (float)soundSlider.value / 100;
            GRoot.inst.soundVolume = (float)soundSlider.value / 100;
            Debug.Log("���q�j�p��e����===" + AudioSourceController.volumeAllScale);
            //Debug.Log("���q�j�p��e����===" + soundSlider.value);
        });
        screenBrightness.value = 10;
        screenBrightness.onChanged.Add(() => { Debug.Log("�e���G�ױ���e����===" + soundSlider.value); });
    }
    void Update()
    {

    }
}
