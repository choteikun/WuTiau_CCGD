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

    private float minuteToRealTime = 0.25f;//�{��C0.25����C���@����/�C���@��:�{��3����/�C��4�p��:�{��1����/�C��4����:�{��1��

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
            OnMinuteChanged?.Invoke();//?�N�䬰null check
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
