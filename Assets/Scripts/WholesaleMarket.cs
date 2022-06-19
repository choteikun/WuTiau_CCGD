using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WholesaleMarket : MonoBehaviour
{
    public GameObject uiRoot;

    public MyStore playerStore;
    public MyStoreObj playerStoreObj;
    public WholesaleMarketObj wholesaleMarketObj;

    [Header("價格浮動大小修正曲線")]
    public AnimationCurve priceFluctuationCurve;
    [Header("淤積期發生曲線(擬邏輯曲線)")]
    public AnimationCurve siltationPeriodCurve;
    [Header("僱傭成本浮動大小修正曲線")]
    public AnimationCurve costPerHireFluctuationCurve;

    [Header("訂定原物料一次的供給量")]
    public int itemAmount;
    [Header("訂定人力一次的供給量")]
    public int addStaffOnce;
    [Header("變化後目前商品價格")]
    public int curItemPrice;
    [Header("變化後目前僱傭成本")]
    public int curCostPerHire;
    [Header("員工日薪")]
    public int storeStaffDailySalary;

    TMP_Text itemAmountText;//供給一次的資源量
    TMP_Text curItemPriceText;//變化後目前商品價格
    TMP_Text addStaffOnceText;//供給一次的人數
    TMP_Text curCostPerHireText;//變化後目前僱傭成本
    TMP_Text curMax_InputItemText;//目前&最大資源量
    TMP_Text curMax_StaffsText;//目前&最大員工數

    Image Sur1;
    Image Med1;
    Image Clo1;

    Image Sur2;
    Image Med2;
    Image Clo2;

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//透明
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//不透明

    void Start()
    {
        itemAmountText = uiRoot.transform.Find("ItemAmountText(TMP)").GetComponent<TMP_Text>();
        curItemPriceText = uiRoot.transform.Find("CurItemPriceText(TMP)").GetComponent<TMP_Text>();
        addStaffOnceText = uiRoot.transform.Find("AddStaffOnceText(TMP)").GetComponent<TMP_Text>();
        curCostPerHireText = uiRoot.transform.Find("CurCostPerHireText(TMP)").GetComponent<TMP_Text>();
        curMax_InputItemText = uiRoot.transform.Find("Cur&Max_InputItemText(TMP)").GetComponent<TMP_Text>();
        curMax_StaffsText = uiRoot.transform.Find("Cur&Max_StaffsText(TMP)").GetComponent<TMP_Text>();

        Sur1 = uiRoot.transform.Find("SugarIcon1(Image)").GetComponent<Image>();
        Med1 = uiRoot.transform.Find("MedIcon1(Image)").GetComponent<Image>();
        Clo1 = uiRoot.transform.Find("CloIcon1(Image)").GetComponent<Image>();

        Sur2 = uiRoot.transform.Find("SugarIcon2(Image)").GetComponent<Image>();
        Med2 = uiRoot.transform.Find("MedIcon2(Image)").GetComponent<Image>();
        Clo2 = uiRoot.transform.Find("CloIcon2(Image)").GetComponent<Image>();


        playerStore = GetComponent<MyStore>();
        updateEveryDay();//每天價格刷新
    }

    void Update()
    {
        if (GameTime.UpdateEveryDay)
        {
            updateEveryDay();
            playerStoreObj.myCoin -= storeStaffDailySalary;//每日員工薪水
        }
        itemAmountText.text = itemAmount.ToString();
        curItemPriceText.text = curItemPrice.ToString();
        addStaffOnceText.text = addStaffOnce.ToString();
        curCostPerHireText.text = curCostPerHire.ToString();
        curMax_InputItemText.text = playerStoreObj.curInputItems.ToString() + "/" + playerStoreObj.maxInputItems.ToString();
        curMax_StaffsText.text = playerStoreObj.curStaffs.ToString() + "/" + playerStoreObj.maxStaffs.ToString();

        switch (playerStoreObj.kindOfStore)
        {
            case "糖郊":
                Sur1.color = alpha1;
                Sur2.color = alpha1;

                Med1.color = alpha0;
                Med2.color = alpha0;
                Clo1.color = alpha0;
                Clo2.color = alpha0;
                break;
            case "南郊":
                Med1.color = alpha1;
                Med2.color = alpha1;

                Sur1.color = alpha0;
                Sur2.color = alpha0;
                Clo1.color = alpha0;
                Clo2.color = alpha0;
                break;
            case "北郊":
                Clo1.color = alpha1;
                Clo2.color = alpha1;

                Sur1.color = alpha0;
                Sur2.color = alpha0;
                Med1.color = alpha0;
                Med2.color = alpha0;
                break;
        }
    }
    public void updateEveryDay()//每天價格刷新方法
    {
        SetPriceFluctuation(Random.Range(1.0f, 5.0f));//一個軸向的隨機選數
        SetPerHireFluctuation(Random.Range(1.0f, 5.0f));
    }
    public void SetPriceFluctuation(float fluctuation)//SetPriceFluctuation用來設一軸向的值再利用animation.curve功能可以得出另一軸向的值
    {
        curItemPrice = (int)Mathf.Round(wholesaleMarketObj.itemPrice * priceFluctuationCurve.Evaluate(fluctuation));//價格(另一軸向)在浮動域裡變化
    }
    public void SetPerHireFluctuation(float fluctuation)//SetPriceFluctuation用來設一軸向的值再利用animation.curve功能可以得出另一軸向的值
    {
        curCostPerHire = (int)Mathf.Round(wholesaleMarketObj.costPerHire * costPerHireFluctuationCurve.Evaluate(fluctuation));//僱傭成本(另一軸向)在浮動域裡變化
    }
    public void ItemBuy()//購買原物料按鈕
    {
        AudioSourceController.PlaySE("Cho_Sounds", "drop_se");
        playerStoreObj.curInputItems += itemAmount;//供給一次
        playerStoreObj.myCoin -= curItemPrice;//買一次扣一次錢
    }
    public void CostPerHireOnce()//購買人力按鈕
    {
        AudioSourceController.PlaySE("Cho_Sounds", "drop_se");
        if (playerStoreObj.curStaffs < playerStoreObj.maxStaffs)
        {
            playerStoreObj.curStaffs += 1;//人力+1
            playerStoreObj.myCoin -= curCostPerHire;//買一次扣一次錢
        }
        else
        {
            Debug.Log("員工數量已達到最大值，按壓無效");
        }
    }
}
