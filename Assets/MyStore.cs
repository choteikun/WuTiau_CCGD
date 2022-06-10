using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStore : MonoBehaviour
{
    public int myCoin;

    public int maxStorage;//�f���`�s�̤j��

    public int curInputItems;//�ثe��ƶq
    public int maxInputItems;//�ܮw�i�s���̤j��ƶq
    public int curOutputItems;//�ثe�ӫ~�q
    public int maxOutputItems;//�ܮw�i�s���̤j�ӫ~�q

    public int maxStaffs;//���u�`�Ƴ̤j��
    public int stockingStaff;//�Ƴf�H��
    public int shippingStaff;//�X�f�H��

    public int StockingSpeed;//�w�p�Ƴf�ɶ�
    public int ShippingSpeed;//�w�p�X�f�ɶ�
    public int curStockingNeedTime;//��e�Ƴf�һݮɶ�
    public int curShippingNeedTime;//��e�X�f�һݮɶ�

    int curGameTimeMinute;
    int startStockingTimer;

    //public int[] itemSpeedCounter;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curGameTimeMinute = GameTime.Day * 12 + GameTime.Hour * 60 + GameTime.Minute;

        if (StockingSpeed > 0) 
        {
            StockingSpeed = (int)Mathf.Round(curStockingNeedTime * (1 - 0.05f * stockingStaff));//��X�w�p�ɶ�           
            if ((startStockingTimer + StockingSpeed) - curGameTimeMinute <= 0)//�Ƴf�ɶ�����
            {
                StockingSpeed = 0;
                //�ثe��ƶq -= �Ƴf�q
                //�ثe�ӫ~�q += �X�f�q
            }
        }
        Debug.Log("GameTime: "  + "curStockingNeedTime: " + curStockingNeedTime);
        if (curInputItems < maxInputItems)    
        {
            
        }
        else                                 
        {
            //��ƶW�X�ܦs�̤j��
            
        }
        if (curOutputItems < maxOutputItems)  
        {
            
        }
        else                                  
        {
            //�ӫ~�W�X�ܦs�̤j��
           
        }
    }
    public void stockingButtonSub()
    {
        Invoke("StartStockingTimer", 0);//�p�ɾ������}�l
        if ((stockingStaff + shippingStaff) < maxStaffs)//���s�u�b���W�L�̤j�H�O�Ʈɨϥ�
        {
            stockingStaff--;
        }
    }
    public void stockingButtonAdd()
    {
        Invoke("StartStockingTimer", 0);//�p�ɾ������}�l
        if ((stockingStaff + shippingStaff) < maxStaffs)
        {
            stockingStaff++;
        }
    }
    public void StartStockingTimer()
    {
        startStockingTimer = curGameTimeMinute;
    }
}
