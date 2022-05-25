using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class OptionButton : MonoBehaviour
{
    private GComponent rootUI;
    private OptionWindow optionWindow;
    void Start()
    {
        rootUI = GetComponent<UIPanel>().ui;
        optionWindow = new OptionWindow();
        rootUI.GetChild("").onClick.Add(() => { optionWindow.Show(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
