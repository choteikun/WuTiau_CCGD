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

    [Header("����B�ʤj�p�ץ����u")]
    public AnimationCurve priceFluctuationCurve;
    [Header("�J�n���o�ͦ��u(���޿覱�u)")]
    public AnimationCurve siltationPeriodCurve;
    [Header("���Ħ����B�ʤj�p�ץ����u")]
    public AnimationCurve costPerHireFluctuationCurve;

    [Header("�q�w�쪫�Ƥ@�����ѵ��q")]
    public int itemAmount;
    [Header("�q�w�H�O�@�����ѵ��q")]
    public int addStaffOnce;
    [Header("�ܤƫ�ثe�ӫ~����")]
    public int curItemPrice;
    [Header("�ܤƫ�ثe���Ħ���")]
    public int curCostPerHire;
    [Header("���u���~")]
    public int storeStaffDailySalary;

    TMP_Text itemAmountText;//�ѵ��@�����귽�q
    TMP_Text curItemPriceText;//�ܤƫ�ثe�ӫ~����
    TMP_Text addStaffOnceText;//�ѵ��@�����H��
    TMP_Text curCostPerHireText;//�ܤƫ�ثe���Ħ���
    TMP_Text curMax_InputItemText;//�ثe&�̤j�귽�q
    TMP_Text curMax_StaffsText;//�ثe&�̤j���u��

    Image Sur1;
    Image Med1;
    Image Clo1;

    Image Sur2;
    Image Med2;
    Image Clo2;

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//�z��
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//���z��

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
        updateEveryDay();//�C�ѻ����s
    }

    void Update()
    {
        if (GameTime.UpdateEveryDay)
        {
            updateEveryDay();
            playerStoreObj.myCoin -= storeStaffDailySalary;//�C����u�~��
        }
        itemAmountText.text = itemAmount.ToString();
        curItemPriceText.text = curItemPrice.ToString();
        addStaffOnceText.text = addStaffOnce.ToString();
        curCostPerHireText.text = curCostPerHire.ToString();
        curMax_InputItemText.text = playerStoreObj.curInputItems.ToString() + "/" + playerStoreObj.maxInputItems.ToString();
        curMax_StaffsText.text = playerStoreObj.curStaffs.ToString() + "/" + playerStoreObj.maxStaffs.ToString();

        switch (playerStoreObj.kindOfStore)
        {
            case "�}��":
                Sur1.color = alpha1;
                Sur2.color = alpha1;

                Med1.color = alpha0;
                Med2.color = alpha0;
                Clo1.color = alpha0;
                Clo2.color = alpha0;
                break;
            case "�n��":
                Med1.color = alpha1;
                Med2.color = alpha1;

                Sur1.color = alpha0;
                Sur2.color = alpha0;
                Clo1.color = alpha0;
                Clo2.color = alpha0;
                break;
            case "�_��":
                Clo1.color = alpha1;
                Clo2.color = alpha1;

                Sur1.color = alpha0;
                Sur2.color = alpha0;
                Med1.color = alpha0;
                Med2.color = alpha0;
                break;
        }
    }
    public void updateEveryDay()//�C�ѻ����s��k
    {
        SetPriceFluctuation(Random.Range(1.0f, 5.0f));//�@�Ӷb�V���H�����
        SetPerHireFluctuation(Random.Range(1.0f, 5.0f));
    }
    public void SetPriceFluctuation(float fluctuation)//SetPriceFluctuation�Ψӳ]�@�b�V���ȦA�Q��animation.curve�\��i�H�o�X�t�@�b�V����
    {
        curItemPrice = (int)Mathf.Round(wholesaleMarketObj.itemPrice * priceFluctuationCurve.Evaluate(fluctuation));//����(�t�@�b�V)�b�B�ʰ���ܤ�
    }
    public void SetPerHireFluctuation(float fluctuation)//SetPriceFluctuation�Ψӳ]�@�b�V���ȦA�Q��animation.curve�\��i�H�o�X�t�@�b�V����
    {
        curCostPerHire = (int)Mathf.Round(wholesaleMarketObj.costPerHire * costPerHireFluctuationCurve.Evaluate(fluctuation));//���Ħ���(�t�@�b�V)�b�B�ʰ���ܤ�
    }
    public void ItemBuy()//�ʶR�쪫�ƫ��s
    {
        AudioSourceController.PlaySE("Cho_Sounds", "drop_se");
        playerStoreObj.curInputItems += itemAmount;//�ѵ��@��
        playerStoreObj.myCoin -= curItemPrice;//�R�@�����@����
    }
    public void CostPerHireOnce()//�ʶR�H�O���s
    {
        AudioSourceController.PlaySE("Cho_Sounds", "drop_se");
        if (playerStoreObj.curStaffs < playerStoreObj.maxStaffs)
        {
            playerStoreObj.curStaffs += 1;//�H�O+1
            playerStoreObj.myCoin -= curCostPerHire;//�R�@�����@����
        }
        else
        {
            Debug.Log("���u�ƶq�w�F��̤j�ȡA�����L��");
        }
    }
}
