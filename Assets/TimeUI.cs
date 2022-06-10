using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private void OnEnable()
    {
        GameTime.OnMinuteChanged += UpdateTime;
        GameTime.OnHourChanged += UpdateTime;
        GameTime.OnDayChanged += UpdateTime;
    }
    private void OnDisable()
    {
        GameTime.OnMinuteChanged -= UpdateTime;
        GameTime.OnHourChanged -= UpdateTime;
        GameTime.OnDayChanged -= UpdateTime;
    }

    void UpdateTime()
    {
        timeText.text = $"{GameTime.Day:00}:{GameTime.Hour:00}:{GameTime.Minute:00}";
    }
}
