using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    Animator anim;
    public WholesaleMarket wholesaleMarket;
    public WholesaleMarketObj wholesaleMarketObj;
    public GameObject rootGameUi;

    GameObject wholesaleMarketPanel;
    GameObject storeLvPanel;
    GameObject siltEventObj;//淤積事件Obj

    [SerializeField]
    private MyStoreObj myStoreObj;

    Image day1;
    Image day2;
    Image day3;
    Image day4;
    Image day5;
    Image day6;
    Image day7;

    Image sunnyImage;
    Image siltImage;
    

    float siltationPeriodDay;

    bool fold;//摺疊按鈕
    bool dayChange;
    bool daySiltationPeriodEventChange;//淤積期前三天的變化

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//透明
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//不透明

    void Start()
    {
        fold = false;
        anim = gameObject.GetComponent<Animator>();

        dayChange = false;
        daySiltationPeriodEventChange = false;

        wholesaleMarketPanel = rootGameUi.transform.Find("WholesaleMarket").gameObject;
        storeLvPanel = rootGameUi.transform.Find("StoreLv").gameObject;

        if (myStoreObj.kindOfStore == "糖郊")
        {
            rootGameUi.transform.Find("SugarStoreTag(Image)").gameObject.GetComponent<Image>().color = alpha1;
            rootGameUi.transform.Find("SugarStore(Image)").gameObject.GetComponent<Image>().color = alpha1;
        }
        else if (myStoreObj.kindOfStore == "南郊")
        {
            rootGameUi.transform.Find("DrugStoreTag(Image)").gameObject.GetComponent<Image>().color = alpha1;
            rootGameUi.transform.Find("DrugStore(Image)").gameObject.GetComponent<Image>().color = alpha1;
        }
        else if (myStoreObj.kindOfStore == "北郊")
        {
            rootGameUi.transform.Find("ClothStoreTag(Image)").gameObject.GetComponent<Image>().color = alpha1;
            rootGameUi.transform.Find("ClothStore(Image)").gameObject.GetComponent<Image>().color = alpha1;
        }
        day1 = rootGameUi.transform.Find("Day(Image)1").gameObject.GetComponent<Image>();
        day2 = rootGameUi.transform.Find("Day(Image)2").gameObject.GetComponent<Image>();
        day3 = rootGameUi.transform.Find("Day(Image)3").gameObject.GetComponent<Image>();
        day4 = rootGameUi.transform.Find("Day(Image)4").gameObject.GetComponent<Image>();
        day5 = rootGameUi.transform.Find("Day(Image)5").gameObject.GetComponent<Image>();
        day6 = rootGameUi.transform.Find("Day(Image)6").gameObject.GetComponent<Image>();
        day7 = rootGameUi.transform.Find("Day(Image)7").gameObject.GetComponent<Image>();

        sunnyImage = rootGameUi.transform.Find("sunny(Image)").gameObject.GetComponent<Image>();
        siltImage = rootGameUi.transform.Find("silt(Image)").gameObject.GetComponent<Image>();
        siltEventObj = rootGameUi.transform.Find("SiltEvent").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!wholesaleMarket)
        {
            wholesaleMarket = GetComponent<WholesaleMarket>();
        }

        if (GameTime.Day == 0)
        {
            DayAlpha0_odd();
            SiltationPeriod_even();
            day1.color = alpha1;
        }
        else if(GameTime.Day == 1)
        {
            DayAlpha0_even();
            SiltationPeriod_odd();
            day2.color = alpha1;
        }
        else if (GameTime.Day == 2)
        {
            DayAlpha0_odd();
            SiltationPeriod_even();
            day3.color = alpha1;
        }
        else if (GameTime.Day == 3)
        {
            SiltationPeriod_odd();
            DayAlpha0_even();
            day4.color = alpha1;
        }
        else if (GameTime.Day == 4)
        {
            DayAlpha0_odd();
            day5.color = alpha1;

            //淤積期結束了，第5天開始一定是晴天
            siltImage.color = alpha0;
            sunnyImage.color = alpha1;
        }
        else if (GameTime.Day == 5)
        {
            DayAlpha0_even();
            day6.color = alpha1;
        }
        else if (GameTime.Day == 6)
        {
            DayAlpha0_odd();
            day7.color = alpha1;
        }
        else if (GameTime.Day == 7)
        {
            SceneManager.LoadScene(5);
        }
    }
    public void DayAlpha0_even()
    {
        if (!dayChange)
        {
            day1.color = alpha0;
            day2.color = alpha0;
            day3.color = alpha0;
            day4.color = alpha0;
            day5.color = alpha0;
            day6.color = alpha0;
            day7.color = alpha0;
            myStoreObj.myCoin -= myStoreObj.curStaffs * wholesaleMarket.storeStaffDailySalary;//每日付員工薪資
            dayChange = true;
        }  
    }
    public void DayAlpha0_odd()
    {
        if (dayChange)
        {
            day1.color = alpha0;
            day2.color = alpha0;
            day3.color = alpha0;
            day4.color = alpha0;
            day5.color = alpha0;
            day6.color = alpha0;
            day7.color = alpha0;
            myStoreObj.myCoin -= myStoreObj.curStaffs * wholesaleMarket.storeStaffDailySalary;//每日付員工薪資
            dayChange = false;
        }
    }
    public void SiltationPeriod_even()
    {
        if (!daySiltationPeriodEventChange)
        {
            siltationPeriodDay = GameTime.Day;
            SiltationPeriodEvent();
            daySiltationPeriodEventChange = true;
        }
    }
    public void SiltationPeriod_odd()
    {
        if (daySiltationPeriodEventChange)
        {
            siltationPeriodDay = GameTime.Day;
            SiltationPeriodEvent();
            daySiltationPeriodEventChange = false;
        }
    }
    public void SiltationPeriodEvent()//淤積期事件
    {
        if (Probability(Mathf.Round(wholesaleMarket.siltationPeriodCurve.Evaluate(siltationPeriodDay) * 100)))//按淤積期給定機率
        {
            siltEventObj.SetActive(true);
            wholesaleMarket.curItemPrice += (int)Mathf.Round(wholesaleMarketObj.itemPrice * 0.1f);//如果觸發機率批發市場原物料價格上漲110%
            siltImage.color = alpha1;
            sunnyImage.color = alpha0;
        }
        else
        {
            siltImage.color = alpha0;
            sunnyImage.color = alpha1;
        }
    }
    public void OperateButton()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "papperflip_se");
        wholesaleMarketPanel.SetActive(false);
        storeLvPanel.SetActive(false);
    }
    public void WholeasaleMarket()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "papperflip_se");
        wholesaleMarketPanel.SetActive(true);
        storeLvPanel.SetActive(false);
    }
    public void StoreLv()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "papperflip_se");
        wholesaleMarketPanel.SetActive(false);
        storeLvPanel.SetActive(true);
    }

    public bool Probability(float percent)//確率
    {
        float probabilityRate = Random.value * 100.0f;
        if (percent == 100.0f && probabilityRate == percent)
        {
            return true;
        }
        else if (probabilityRate < percent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void FoldButton()
    {
        fold = !fold;
        anim.SetBool("Fold", fold);
    }
    public void SiltEventCheckButton()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "papperflip_se");
        siltEventObj.SetActive(false);
    }
}
