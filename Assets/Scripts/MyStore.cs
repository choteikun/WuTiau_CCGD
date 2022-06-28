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

    public float stockingTime;//�Ƴf�ɶ�(�@���ܰ�)
    public float shippingTime;//�X�f�ɶ�(�@���ܰ�)
    
    int curGameTimeMinute;//��U���C���ɶ�

    public bool stockingOnce;//�i�Ƴf�@��
    public bool shippingOnce;//�i�X�f�@��
    
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

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//�z��
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//���z��

    void Start()
    {
        stockingTime = (int)Mathf.Round(myStoreObj.stockingNeedTime - 2 * myStoreObj.stockingStaff);//��l�Ʈ���o�@���Ƴf�ɶ����p��
        shippingTime = (int)Mathf.Round(myStoreObj.shippingNeedTime - 2 * myStoreObj.shippingStaff);//��l�Ʈ���o�@���X�f�ɶ����p��
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
        if (myStoreObj.myCoin < 0)//���ȥ���
        {
            myStoreObj.missionState = false;
            SceneManager.LoadScene(5);
        }

        curGameTimeMinute = GameTime.Day * 12 + GameTime.Hour * 60 + GameTime.Minute;
        if (myStoreObj.stockingStaff > 0 && stockingOnce) //���H�O�B���\�X�f�@���ɡA�~�|�}�l�i��h�f�B��
        {
            stockingTime -= Time.deltaTime * 4.0f;
            if (stockingTime < 0)
            {
                stockingTime = 0;
                stockingOnce = false;//����X�f
                //�ثe��ƶq -= �Ƴf�q ; �ثe�ӫ~�q += �Ƴf�q
                Invoke("StockingOnce", 0.1f);//��O0.1f�ɶ��N����ഫ���ӫ~
            }
        }

        if (myStoreObj.shippingStaff > 0 && shippingOnce)
        {
            shippingTime -= Time.deltaTime * 4.0f;
            if (shippingTime < 0)
            {
                shippingTime = 0;
                shippingOnce = false;//����X�f
                //�ثe�ӫ~�q -= �X�f�q
                Invoke("ShippingOnce", 0.1f);//��O0.1f�ɶ��N�ӫ~�X�f
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
            //��ƶW�X�ܦs�̤j��
            myStoreObj.curInputItems = myStoreObj.maxInputItems;
        }
        if (myStoreObj.curOutputItems > myStoreObj.maxOutputItems)  
        {
            //�ӫ~�W�X�ܦs�̤j��
            myStoreObj.curOutputItems = myStoreObj.maxOutputItems;
        }

        if(myStoreObj.kindOfStore == "�}��")
        {
            inputSugarIcon.color = alpha1;
            outputSugarIcon.color = alpha1;

            inputMedIcon.color = alpha0;
            outputMedIcon.color = alpha0;
            inputCloIcon.color = alpha0;
            outputCloIcon.color = alpha0;
        }
        else if (myStoreObj.kindOfStore == "�n��")
        {
            inputMedIcon.color = alpha1;
            outputMedIcon.color = alpha1;

            inputSugarIcon.color = alpha0;
            outputSugarIcon.color = alpha0;
            inputCloIcon.color = alpha0;
            outputCloIcon.color = alpha0;
        }
        else if(myStoreObj.kindOfStore == "�_��")
        {
            inputCloIcon.color = alpha1;
            outputCloIcon.color = alpha1;

            inputSugarIcon.color = alpha0;
            outputSugarIcon.color = alpha0;
            inputMedIcon.color = alpha0;
            outputMedIcon.color = alpha0;
        }

        myCoinText.text = myStoreObj.myCoin.ToString();//���a���] 
        curStaffsText.text = myStoreObj.curStaffs.ToString();//�ثe�֦��H�O�ƶq

        stockingStaffText.text = myStoreObj.stockingStaff.ToString();
        shippingStaffText.text = myStoreObj.shippingStaff.ToString();

        stockingTimeText.text = ((int)stockingTime).ToString();
        shippingTimeText.text = ((int)shippingTime).ToString();

        curInputItemText.text = myStoreObj.curInputItems.ToString() + "/" + myStoreObj.maxInputItems.ToString();//  �{���귽�q/�̤j�귽�q
        curOutputItemText.text = myStoreObj.curOutputItems.ToString() + "/" + myStoreObj.maxOutputItems.ToString();//  �{���ӫ~�q/�̤j�ӫ~�q
    }
    //private void OnCoinChange(int coin)
    //{
    //    myCoinText.text = myStoreObj.MyCoin.ToString();//���a���] 
    //}
    public void stockingStaffButtonSub()
    { 
        if (myStoreObj.stockingStaff > 0)
        {
            stockingTime = (int)Mathf.Round(myStoreObj.stockingNeedTime - 2 * myStoreObj.stockingStaff);//�Ƴf�ɶ����p��
            myStoreObj.stockingStaff--;   
        }
    }
    public void stockingStaffButtonAdd()
    {  
        if ((myStoreObj.stockingStaff + myStoreObj.shippingStaff) < myStoreObj.curStaffs)//���s�u�b���W�L�̤j�H�O�Ʈɨϥ�
        {
            stockingTime = (int)Mathf.Round(myStoreObj.stockingNeedTime - 2 * myStoreObj.stockingStaff);//�Ƴf�ɶ����p��
            myStoreObj.stockingStaff++;
        }
    }
    public void shippingStaffButtonSub()
    {    
        if (myStoreObj.shippingStaff > 0) 
        {
            shippingTime = (int)Mathf.Round(myStoreObj.shippingNeedTime - 2 * myStoreObj.shippingStaff);//�X�f�ɶ����p��
            myStoreObj.shippingStaff--;
        }
    }
    public void shippingStaffButtonAdd()
    {      
        if ((myStoreObj.stockingStaff + myStoreObj.shippingStaff) < myStoreObj.curStaffs)//���s�u�b���W�L�̤j�H�O�Ʈɨϥ�
        {
            shippingTime = (int)Mathf.Round(myStoreObj.shippingNeedTime - 2 * myStoreObj.shippingStaff);//�X�f�ɶ����p��
            myStoreObj.shippingStaff++;
        }
    }
    public void StockingOnce()//�榸�Ƴf
    {
        if (myStoreObj.curInputItems > 0)
        {
            myStoreObj.curInputItems -= myStoreObj.stockingOnceAmount;
            myStoreObj.curOutputItems += myStoreObj.stockingOnceAmount;
        }
        stockingTime = (int)Mathf.Round(myStoreObj.stockingNeedTime - 2 * myStoreObj.stockingStaff);//�Ƴf�@���᭫�s��o�@���Ƴf�ɶ����p�� 
        stockingOnce = true;
    }
    public void ShippingOnce()//�榸�X�f
    { 
        if (myStoreObj.curOutputItems > 0)
        {
            myStoreObj.curOutputItems -= myStoreObj.shippingOnceAmount;
            myStoreObj.myCoin += myStoreObj.earnCoin;
        }
        shippingTime = (int)Mathf.Round(myStoreObj.shippingNeedTime - 2 * myStoreObj.shippingStaff);//�X�f�@���᭫�s��o�@���X�f�ɶ����p�� 
        shippingOnce = true;
    }
}
