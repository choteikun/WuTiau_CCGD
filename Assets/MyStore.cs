using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStore : MonoBehaviour
{
    public int myCoin;

    public int maxStorage;//貨物總存最大值

    public int curInputItems;//目前原料量
    public int maxInputItems;//倉庫可存的最大原料量
    public int curOutputItems;//目前商品量
    public int maxOutputItems;//倉庫可存的最大商品量

    public int maxStaffs;//員工總數最大值
    public int stockingStaff;//備貨人員
    public int shippingStaff;//出貨人員

    public int StockingSpeed;//預計備貨時間
    public int ShippingSpeed;//預計出貨時間
    public int curStockingNeedTime;//當前備貨所需時間
    public int curShippingNeedTime;//當前出貨所需時間

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
            StockingSpeed = (int)Mathf.Round(curStockingNeedTime * (1 - 0.05f * stockingStaff));//算出預計時間           
            if ((startStockingTimer + StockingSpeed) - curGameTimeMinute <= 0)//備貨時間完成
            {
                StockingSpeed = 0;
                //目前原料量 -= 備貨量
                //目前商品量 += 出貨量
            }
        }
        Debug.Log("GameTime: "  + "curStockingNeedTime: " + curStockingNeedTime);
        if (curInputItems < maxInputItems)    
        {
            
        }
        else                                 
        {
            //原料超出倉存最大值
            
        }
        if (curOutputItems < maxOutputItems)  
        {
            
        }
        else                                  
        {
            //商品超出倉存最大值
           
        }
    }
    public void stockingButtonSub()
    {
        Invoke("StartStockingTimer", 0);//計時器紀錄開始
        if ((stockingStaff + shippingStaff) < maxStaffs)//按鈕只在不超過最大人力數時使用
        {
            stockingStaff--;
        }
    }
    public void stockingButtonAdd()
    {
        Invoke("StartStockingTimer", 0);//計時器紀錄開始
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
