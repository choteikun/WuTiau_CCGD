using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class GSliderTest : MonoBehaviour
{
    private GComponent root;

    private GSlider playerSlider;

    void Awake()
    {
        //UIPackage.AddPackage("UI/Basics");
    }


    // Use this for initialization
    void Start()
    {
        root = GetComponent<UIPanel>().ui;

        playerSlider = root.GetChild("SlideTest").asSlider;
        playerSlider.value = 0;
        playerSlider.onChanged.Add(() => {

            Debug.Log("�ưʱ���e����===" + playerSlider.value);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
