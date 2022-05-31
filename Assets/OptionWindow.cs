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
            Debug.Log("音量大小當前的值===" + AudioSourceController.volumeAllScale);
            //Debug.Log("音量大小當前的值===" + soundSlider.value);
        });
        screenBrightness.value = 10;
        screenBrightness.onChanged.Add(() => { Debug.Log("畫面亮度條當前的值===" + soundSlider.value); });
    }
    void Update()
    {

    }
}
