using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class Bag_01 : MonoBehaviour
{
    private GComponent mainUI;
    private GButton playerView;
    private ItemWindow itemWindow;

    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        playerView = mainUI.GetChild("playerView").asButton;
        playerView.onClick.Add(UseItem);
        itemWindow = new ItemWindow();
        itemWindow.SetXY(0, 0);
        mainUI.GetChild("BagButton").onClick.Add(() => { itemWindow.Show(); });

    }


    void Update()
    {
        
    }
    private void UseItem()
    {
        playerView.icon = null;
        playerView.title = "ªÅ¥Õ";
    }
}
