using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameTime : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static Action OnDayChanged;
    public static int Minute { get; private set; }
    public static int Hour { get; private set; }
    public static int Day { get; private set; }

    private float minuteToRealTime = 0.25f;//現實每0.25秒等於遊戲一分鐘/遊戲一天:現實3分鐘/遊戲4小時:現實1分鐘/遊戲4分鐘:現實1秒

    private float timer;

    

    private void Start()
    {
        Minute = 0;
        Hour = 0;
        timer = minuteToRealTime;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Minute++;
            OnMinuteChanged?.Invoke();//?意思為null check
            if (Minute >= 60)
            {
                Hour++;
                Minute = 0;
                OnHourChanged?.Invoke();
            }
            if (Hour >= 12)
            {
                Day++;
                Hour = 0;
                OnDayChanged?.Invoke();
            }
            timer = minuteToRealTime;
        }
    }
}
