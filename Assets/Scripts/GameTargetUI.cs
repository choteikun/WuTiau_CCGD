using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTargetUI : MonoBehaviour
{
    public GameObject rootGameUi;
    public MyStoreObj myStoreObj;

    GameObject gameTargetUi;
    TMP_Text gameTargetText;

    void Start()
    {
        gameTargetUi = rootGameUi.transform.Find("GameTarget(Image)").gameObject;
        gameTargetText = gameTargetUi.transform.Find("GameTargetCoin(TMP)").GetComponent<TMP_Text>();
        gameTargetText.text = myStoreObj.myTargetCoin.ToString();
        gameTargetUi.SetActive(true);
    }

    public void GameTargetCheckButton()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "papperflip_se");
        gameTargetUi.SetActive(false);
    }
}
