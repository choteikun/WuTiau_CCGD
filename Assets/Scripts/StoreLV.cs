using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreLV : MonoBehaviour
{
    public MyStoreObj myStoreObj;
    public WholesaleMarket wholesaleMarket;

    public GameObject uiRoot;

    int nextMyStoreLv;
    int nextMaxInputItems;
    int nextMaxOutputItems;
    int nextMaxStaffs;

    Button storeLvUpButton;

    //下排商店升級面板資訊
    Image lvUpInfoImage;
    //下排商店Lv3的升級面板資訊
    Image lvUpInfoImageLv3;
    //員工日薪加總資訊
    Image totalStaffDailySalaryImage;
    //遊戲目標
    Image gameTargetImage;

    //商店樣貌
    Image nextLv2SurStoreImage;
    Image nextLv3SurStoreImage;

    Image nextLv2MedStoreImage;
    Image nextLv3MedStoreImage;

    Image nextLv2CloStoreImage;
    Image nextLv3CloStoreImage;


    TMP_Text lvUpCostText;
    TMP_Text totalStaffDailySalaryText;
    TMP_Text gameTargetText;

    TMP_Text curMyStoreLvText;
    TMP_Text curMaxInputItemsText;
    TMP_Text curMaxOutputItemsText;
    TMP_Text curMaxStaffsText;

    TMP_Text nextMyStoreLvText;
    TMP_Text nextMaxInputItemsText;
    TMP_Text nextMaxOutputItemsText;
    TMP_Text nextMaxStaffsText;

    bool switchButton;

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//透明
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//不透明
    void Start()
    {
        switchButton = false;

        storeLvUpButton = uiRoot.transform.Find("LvUp(Button)").GetComponent<Button>();

        lvUpInfoImage = uiRoot.transform.Find("LvUpInfo(Image)").GetComponent<Image>();
        lvUpInfoImageLv3 = uiRoot.transform.Find("LvUpInfoLv3(Image)").GetComponent<Image>();
        totalStaffDailySalaryImage = uiRoot.transform.Find("TotalStaffDailySalary(Image)").GetComponent<Image>();
        gameTargetImage = uiRoot.transform.Find("GameTarget(Image)").GetComponent<Image>();

        nextLv2SurStoreImage = uiRoot.transform.Find("NextLv2SurStoreImage(Image)").GetComponent<Image>();
        nextLv3SurStoreImage = uiRoot.transform.Find("NextLv3SurStoreImage(Image)").GetComponent<Image>();

        nextLv2MedStoreImage = uiRoot.transform.Find("NextLv2MedStoreImage(Image)").GetComponent<Image>();
        nextLv3MedStoreImage = uiRoot.transform.Find("NextLv3MedStoreImage(Image)").GetComponent<Image>();

        nextLv2CloStoreImage = uiRoot.transform.Find("NextLv2CloStoreImage(Image)").GetComponent<Image>();
        nextLv3CloStoreImage = uiRoot.transform.Find("NextLv3CloStoreImage(Image)").GetComponent<Image>();

        lvUpCostText = uiRoot.transform.Find("LvUpCostText(TMP)").GetComponent<TMP_Text>();
        totalStaffDailySalaryText = uiRoot.transform.Find("TotalStaffDailySalaryText(TMP)").GetComponent<TMP_Text>();
        gameTargetText = uiRoot.transform.Find("GameTargetText(TMP)").GetComponent<TMP_Text>();

        curMyStoreLvText = uiRoot.transform.Find("CurMyStoreLvText(TMP)").GetComponent<TMP_Text>();
        curMaxInputItemsText = uiRoot.transform.Find("CurMaxInputItemsText(TMP)").GetComponent<TMP_Text>();
        curMaxOutputItemsText = uiRoot.transform.Find("CurMaxOutputItemsText(TMP)").GetComponent<TMP_Text>();
        curMaxStaffsText = uiRoot.transform.Find("CurMaxStaffsText(TMP)").GetComponent<TMP_Text>();

        nextMyStoreLvText = uiRoot.transform.Find("NextMyStoreLvText(TMP)").GetComponent<TMP_Text>();
        nextMaxInputItemsText = uiRoot.transform.Find("NextMaxInputItemsText(TMP)").GetComponent<TMP_Text>();
        nextMaxOutputItemsText = uiRoot.transform.Find("NextMaxOutputItemsText(TMP)").GetComponent<TMP_Text>();
        nextMaxStaffsText = uiRoot.transform.Find("NextMaxStaffsText(TMP)").GetComponent<TMP_Text>();


    }
    void Update()
    {
        Debug.Log("NextLvUpStore : " + myStoreObj.myStoreNextLv);
        if (!wholesaleMarket)
        {
            wholesaleMarket = GetComponent<WholesaleMarket>();
        }
        storeLvUpButton.interactable = myStoreObj.myCoin >= myStoreObj.levelUpCost ? true : false;

        lvUpCostText.text = myStoreObj.levelUpCost.ToString();//顯示當前商店升級所需的費用

        switch (myStoreObj.kindOfStore)
        {
            case "糖郊":
                SurStoreVallSet();
                break;
            case "南郊":
                MedStoreVallSet();
                break;
            case "北郊":
                CloStoreVallSet();
                break;
        }
        if (switchButton)
        {
            CurLvInfoToString();//現有升級資訊顯示

            totalStaffDailySalaryImage.color = alpha0;//隱藏全體人力一天加總的薪資
            totalStaffDailySalaryText.color = alpha0;
            gameTargetImage.color = alpha0;//隱藏遊戲目標
            gameTargetText.color = alpha0;
            

            if (myStoreObj.myStoreLv == 3)
            {
                lvUpInfoImage.color = alpha0;//隱藏LV2以前的升級資訊   
                lvUpInfoImageLv3.color = alpha1;//顯示LV3的升級資訊 

                NextLvUpInfoAlpha0();//隱藏下一個升級的資訊
            }
            else
            {
                lvUpInfoImage.color = alpha1;//顯示LV2以前的升級資訊
                lvUpInfoImageLv3.color = alpha0;//隱藏LV3的升級資訊

                NextLvInfoToString();//升級面板資訊預覽
            }
            
        }
        else
        {
            AllLvUpInfoAlpha0();//隱藏所有升級資訊

            totalStaffDailySalaryImage.color = alpha1;//顯示全體人力一天加總的薪資
            totalStaffDailySalaryText.color = alpha1;
            gameTargetImage.color = alpha1;
            gameTargetText.color = alpha1;

            totalStaffDailySalaryText.text = (myStoreObj.curStaffs * wholesaleMarket.storeStaffDailySalary).ToString();
            gameTargetText.text = myStoreObj.myTargetCoin.ToString();
        }
        
    }
    public void StoreLvUp()
    {
        if (myStoreObj.myStoreLv < 3)
        {
            myStoreObj.myStoreLv++;
            myStoreObj.myCoin -= myStoreObj.levelUpCost;
            if (myStoreObj.myStoreNextLv < 3)
            {
                myStoreObj.myStoreNextLv = myStoreObj.myStoreLv + 1;
            }
        }
    }
    public void SwitchButton()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "papperflip_se");
        switchButton = !switchButton;
    }
    public void SurStoreVallSet()//糖郊升級的屬性配置
    {
        NextMedStoreImageAlpha0();
        NextCloStoreImageAlpha0();

        if (myStoreObj.myStoreLv == 1)
        {
            myStoreObj.maxInputItems = 2000;
            myStoreObj.maxOutputItems = 1200;
            myStoreObj.maxStaffs = 3;
            myStoreObj.levelUpCost = 5000;
        }
        else if (myStoreObj.myStoreLv == 2)
        {
            myStoreObj.maxInputItems = 6000;
            myStoreObj.maxOutputItems = 3600;
            myStoreObj.maxStaffs = 5;
            myStoreObj.levelUpCost = 10000;
        }
        else if (myStoreObj.myStoreLv == 3)
        {
            myStoreObj.maxInputItems = 12000;
            myStoreObj.maxOutputItems = 7200;
            myStoreObj.maxStaffs = 7;
            myStoreObj.levelUpCost = 15000;
        }
        //商店下一級的預覽
        if (myStoreObj.myStoreNextLv == 2)
        {
            nextLv2SurStoreImage.color = alpha1;
            nextLv3SurStoreImage.color = alpha0;

            nextMaxInputItems = 6000;
            nextMaxOutputItems = 3600;
            nextMaxStaffs = 5;
        }
        else if (myStoreObj.myStoreNextLv == 3)
        {
            nextLv3SurStoreImage.color = alpha1;
            nextLv2SurStoreImage.color = alpha0;

            nextMaxInputItems = 12000;
            nextMaxOutputItems = 7200;
            nextMaxStaffs = 7;
        }
    }
    public void MedStoreVallSet()//南郊升級的屬性配置
    {
        NextSurStoreImageAlpha0();
        NextCloStoreImageAlpha0();

        if (myStoreObj.myStoreLv == 1)
        {
            myStoreObj.maxInputItems = 500;
            myStoreObj.maxOutputItems = 300;
            myStoreObj.maxStaffs = 2;
            myStoreObj.levelUpCost = 5000;
        }
        else if (myStoreObj.myStoreLv == 2)
        {
            myStoreObj.maxInputItems = 1500;
            myStoreObj.maxOutputItems = 900;
            myStoreObj.maxStaffs = 4;
            myStoreObj.levelUpCost = 10000;
        }
        else if (myStoreObj.myStoreLv == 3)
        {
            myStoreObj.maxInputItems = 3000;
            myStoreObj.maxOutputItems = 1800;
            myStoreObj.maxStaffs = 5;
            myStoreObj.levelUpCost = 15000;
        }
        //商店下一級的預覽
        if (myStoreObj.myStoreNextLv == 2)
        {
            nextLv2MedStoreImage.color = alpha1;
            nextLv3MedStoreImage.color = alpha0;

            nextMaxInputItems = 1500;
            nextMaxOutputItems = 900;
            nextMaxStaffs = 4;
        }
        else if (myStoreObj.myStoreNextLv == 3)
        {
            nextLv2MedStoreImage.color = alpha0;
            nextLv3MedStoreImage.color = alpha1;

            nextMaxInputItems = 3000;
            nextMaxOutputItems = 1800;
            nextMaxStaffs = 5;
        }
    }
    public void CloStoreVallSet()//北郊升級的屬性配置
    {
        NextSurStoreImageAlpha0();
        NextMedStoreImageAlpha0();

        if (myStoreObj.myStoreLv == 1)
        {
            myStoreObj.maxInputItems = 1000;
            myStoreObj.maxOutputItems = 600;
            myStoreObj.maxStaffs = 3;
            myStoreObj.levelUpCost = 5000;
        }
        else if (myStoreObj.myStoreLv == 2)
        {
            myStoreObj.maxInputItems = 3000;
            myStoreObj.maxOutputItems = 1800;
            myStoreObj.maxStaffs = 5;
            myStoreObj.levelUpCost = 10000;
        }
        else if (myStoreObj.myStoreLv == 3)
        {
            myStoreObj.maxInputItems = 6000;
            myStoreObj.maxOutputItems = 3600;
            myStoreObj.maxStaffs = 6;
            myStoreObj.levelUpCost = 15000;
        }
        //商店下一級的預覽
        if (myStoreObj.myStoreNextLv == 2)
        {
            nextLv2CloStoreImage.color = alpha1;
            nextLv3CloStoreImage.color = alpha0;

            nextMaxInputItems = 3000;
            nextMaxOutputItems = 1800;
            nextMaxStaffs = 5;
        }
        else if (myStoreObj.myStoreNextLv == 3)
        {
            nextLv2CloStoreImage.color = alpha0;
            nextLv3CloStoreImage.color = alpha1;

            nextMaxInputItems = 6000;
            nextMaxOutputItems = 3600;
            nextMaxStaffs = 7;
        }
    }

    public void NextSurStoreImageAlpha0()//糖郊所有升級預覽圖的alpha為0
    {
        nextLv2SurStoreImage.color = alpha0;
        nextLv3SurStoreImage.color = alpha0;
    }
    public void NextMedStoreImageAlpha0()//南郊所有升級預覽圖的alpha為0
    {
        nextLv2MedStoreImage.color = alpha0;
        nextLv3MedStoreImage.color = alpha0;
    }
    public void NextCloStoreImageAlpha0()//北郊所有升級預覽圖的alpha為0
    {
        nextLv2CloStoreImage.color = alpha0;
        nextLv3CloStoreImage.color = alpha0;
    }

    public void CurLvInfoToString()//現有升級資訊顯示
    {
        curMyStoreLvText.text = myStoreObj.myStoreLv.ToString();
        curMyStoreLvText.color = alpha1;
        curMaxInputItemsText.text = myStoreObj.maxInputItems.ToString();
        curMaxInputItemsText.color = alpha1;
        curMaxOutputItemsText.text = myStoreObj.maxOutputItems.ToString();
        curMaxOutputItemsText.color = alpha1;
        curMaxStaffsText.text = myStoreObj.maxStaffs.ToString();
        curMaxStaffsText.color = alpha1;
    }
    public void NextLvInfoToString()//下一個升級資訊預覽
    {
        nextMyStoreLvText.text = myStoreObj.myStoreNextLv.ToString();
        nextMyStoreLvText.color = alpha1;
        nextMaxInputItemsText.text = nextMaxInputItems.ToString();
        nextMaxInputItemsText.color = alpha1;
        nextMaxOutputItemsText.text = nextMaxOutputItems.ToString();
        nextMaxOutputItemsText.color = alpha1;
        nextMaxStaffsText.text = nextMaxStaffs.ToString();
        nextMaxStaffsText.color = alpha1;
    }
    public void AllLvUpInfoAlpha0()//隱藏所有升級資訊
    {
        lvUpInfoImage.color = alpha0;//隱藏Lv3以前的升級資訊板

        lvUpInfoImageLv3.color = alpha0;//隱藏Lv3的升級資訊板

        curMyStoreLvText.color = alpha0;
        curMaxInputItemsText.color = alpha0;
        curMaxOutputItemsText.color = alpha0;
        curMaxStaffsText.color = alpha0;

        NextLvUpInfoAlpha0(); //隱藏下一個升級資訊
    }
    public void NextLvUpInfoAlpha0()//隱藏下一個升級資訊
    {
        nextMyStoreLvText.color = alpha0;
        nextMaxInputItemsText.color = alpha0;
        nextMaxOutputItemsText.color = alpha0;
        nextMaxStaffsText.color = alpha0;
    }
}
