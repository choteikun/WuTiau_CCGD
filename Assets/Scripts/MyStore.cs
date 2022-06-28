using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MyStore : MonoBehaviour
{
    public GameObject uiRoot;

    [SerializeField]
    private WholesaleMarket market;

    public MyStoreObj myStoreObj;   

    public float stockingTime;//備貨時間(一直變動)
    public float shippingTime;//出貨時間(一直變動)
    
    int curGameTimeMinute;//當下的遊戲時間

    public bool stockingOnce;//可備貨一次
    public bool shippingOnce;//可出貨一次
    
    TMP_Text myCoinText;
    TMP_Text curStaffsText;

    TMP_Text stockingStaffText;
    TMP_Text shippingStaffText;
    TMP_Text stockingTimeText;
    TMP_Text shippingTimeText;

    TMP_Text curInputItemText;
    TMP_Text curOutputItemText;

    Image inputSugarIcon;
    Image inputMedIcon;
    Image inputCloIcon;

    Image outputSugarIcon;
    Image outputMedIcon;
    Image outputCloIcon;

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//透明
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//不透明

    void Start()
    {
        stockingTime = (int)Mathf.Round(myStoreObj.stockingNeedTime - 2 * myStoreObj.stockingStaff);//初始化時獲得一次備貨時間的計算
        shippingTime = (int)Mathf.Round(myStoreObj.shippingNeedTime - 2 * myStoreObj.shippingStaff);//初始化時獲得一次出貨時間的計算
        stockingOnce = true;
        shippingOnce = true;
        //ShopSystem.OnCoinChange += OnCoinChange;

        myCoinText = uiRoot.transform.Find("MyCoinText(TMP)").GetComponent<TMP_Text>();
        curStaffsText = uiRoot.transform.Find("CurStaffsText(TMP)").GetComponent<TMP_Text>();

        stockingStaffText = uiRoot.transform.Find("StockingStaffText(TMP)").GetComponent<TMP_Text>();
        shippingStaffText = uiRoot.transform.Find("ShippingStaffText(TMP)").GetComponent<TMP_Text>();

        stockingTimeText = uiRoot.transform.Find("StockingTimeText(TMP)").GetComponent<TMP_Text>();
        shippingTimeText = uiRoot.transform.Find("ShippingTimeText(TMP)").GetComponent<TMP_Text>();

        curInputItemText = uiRoot.transform.Find("CurInputItemText(TMP)").GetComponent<TMP_Text>();
        curOutputItemText = uiRoot.transform.Find("CurOutputItemText(TMP)").GetComponent<TMP_Text>();

        inputSugarIcon = uiRoot.transform.Find("InputSugarIcon(Image)").GetComponent<Image>();
        inputMedIcon = uiRoot.transform.Find("InputMedIcon(Image)").GetComponent<Image>();
        inputCloIcon = uiRoot.transform.Find("InputCloIcon(Image)").GetComponent<Image>();

        outputSugarIcon = uiRoot.transform.Find("OutputSugarIcon(Image)").GetComponent<Image>();
        outputMedIcon = uiRoot.transform.Find("OutputMedIcon(Image)").GetComponent<Image>();
        outputCloIcon = uiRoot.transform.Find("OutputCloIcon(Image)").GetComponent<Image>();
    }

    void Update()
    {
        if (myStoreObj.myCoin < 0)//任務失敗
        {
            myStoreObj.missionState = false;
            SceneManager.LoadScene(5);
        }

        curGameTimeMinute = GameTime.Day * 12 + GameTime.Hour * 60 + GameTime.Minute;
        if (myStoreObj.stockingStaff > 0 && stockingOnce) //有人力且允許出貨一次時，才會開始進行搬貨運算
        {
            stockingTime -= Time.deltaTime * 4.0f;
            if (stockingTime < 0)
            {
                stockingTime = 0;
                stockingOnce = false;//不能出貨
                //目前原料量 -= 備貨量 ; 目前商品量 += 備貨量
                Invoke("StockingOnce", 0.1f);//花費0.1f時間將原料轉換成商品
            }
        }

        if (myStoreObj.shippingStaff > 0 && shippingOnce)
        {
            shippingTime -= Time.deltaTime * 4.0f;
            if (shippingTime < 0)
            {
                shippingTime = 0;
                shippingOnce = false;//不能出貨
                //目前商品量 -= 出貨量
                Invoke("ShippingOnce", 0.1f);//花費0.1f時間將商品出貨
            }
        }

        //Debug.Log();
        if (myStoreObj.curInputItems <= 0)
        {
            myStoreObj.curInputItems = 0;
        }
        if (myStoreObj.curOutputItems <= 0)
        {
            myStoreObj.curOutputItems = 0;
        }

        if (myStoreObj.curInputItems  > myStoreObj.maxInputItems)    
        {
            //原料超出倉存最大值
            myStoreObj.curInputItems = myStoreObj.maxInputItems;
        }
        if (myStoreObj.curOutputItems > myStoreObj.maxOutputItems)  
        {
            //商品超出倉存最大值
            myStoreObj.curOutputItems = myStoreObj.maxOutputItems;
        }

        if(myStoreObj.kindOfStore == "糖郊")
        {
            inputSugarIcon.color = alpha1;
            outputSugarIcon.color = alpha1;

            inputMedIcon.color = alpha0;
            outputMedIcon.color = alpha0;
            inputCloIcon.color = alpha0;
            outputCloIcon.color = alpha0;
        }
        else if (myStoreObj.kindOfStore == "南郊")
        {
            inputMedIcon.color = alpha1;
            outputMedIcon.color = alpha1;

            inputSugarIcon.color = alpha0;
            outputSugarIcon.color = alpha0;
            inputCloIcon.color = alpha0;
            outputCloIcon.color = alpha0;
        }
        else if(myStoreObj.kindOfStore == "北郊")
        {
            inputCloIcon.color = alpha1;
            outputCloIcon.color = alpha1;

            inputSugarIcon.color = alpha0;
            outputSugarIcon.color = alpha0;
            inputMedIcon.color = alpha0;
            outputMedIcon.color = alpha0;
        }

        myCoinText.text = myStoreObj.myCoin.ToString();//玩家錢包 
        curStaffsText.text = myStoreObj.curStaffs.ToString();//目前擁有人力數量

        stockingStaffText.text = myStoreObj.stockingStaff.ToString();
        shippingStaffText.text = myStoreObj.shippingStaff.ToString();

        stockingTimeText.text = ((int)stockingTime).ToString();
        shippingTimeText.text = ((int)shippingTime).ToString();

        curInputItemText.text = myStoreObj.curInputItems.ToString() + "/" + myStoreObj.maxInputItems.ToString();//  現有資源量/最大資源量
        curOutputItemText.text = myStoreObj.curOutputItems.ToString() + "/" + myStoreObj.maxOutputItems.ToString();//  現有商品量/最大商品量
    }
    //private void OnCoinChange(int coin)
    //{
    //    myCoinText.text = myStoreObj.MyCoin.ToString();//玩家錢包 
    //}
    public void stockingStaffButtonSub()
    { 
        if (myStoreObj.stockingStaff > 0)
        {
            stockingTime = (int)Mathf.Round(myStoreObj.stockingNeedTime - 2 * myStoreObj.stockingStaff);//備貨時間的計算
            myStoreObj.stockingStaff--;   
        }
    }
    public void stockingStaffButtonAdd()
    {  
        if ((myStoreObj.stockingStaff + myStoreObj.shippingStaff) < myStoreObj.curStaffs)//按鈕只在不超過最大人力數時使用
        {
            stockingTime = (int)Mathf.Round(myStoreObj.stockingNeedTime - 2 * myStoreObj.stockingStaff);//備貨時間的計算
            myStoreObj.stockingStaff++;
        }
    }
    public void shippingStaffButtonSub()
    {    
        if (myStoreObj.shippingStaff > 0) 
        {
            shippingTime = (int)Mathf.Round(myStoreObj.shippingNeedTime - 2 * myStoreObj.shippingStaff);//出貨時間的計算
            myStoreObj.shippingStaff--;
        }
    }
    public void shippingStaffButtonAdd()
    {      
        if ((myStoreObj.stockingStaff + myStoreObj.shippingStaff) < myStoreObj.curStaffs)//按鈕只在不超過最大人力數時使用
        {
            shippingTime = (int)Mathf.Round(myStoreObj.shippingNeedTime - 2 * myStoreObj.shippingStaff);//出貨時間的計算
            myStoreObj.shippingStaff++;
        }
    }
    public void StockingOnce()//單次備貨
    {
        if (myStoreObj.curInputItems > 0)
        {
            myStoreObj.curInputItems -= myStoreObj.stockingOnceAmount;
            myStoreObj.curOutputItems += myStoreObj.stockingOnceAmount;
        }
        stockingTime = (int)Mathf.Round(myStoreObj.stockingNeedTime - 2 * myStoreObj.stockingStaff);//備貨一次後重新獲得一次備貨時間的計算 
        stockingOnce = true;
    }
    public void ShippingOnce()//單次出貨
    { 
        if (myStoreObj.curOutputItems > 0)
        {
            myStoreObj.curOutputItems -= myStoreObj.shippingOnceAmount;
            myStoreObj.myCoin += myStoreObj.earnCoin;
        }
        shippingTime = (int)Mathf.Round(myStoreObj.shippingNeedTime - 2 * myStoreObj.shippingStaff);//出貨一次後重新獲得一次出貨時間的計算 
        shippingOnce = true;
    }
}
