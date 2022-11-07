using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;

public class Roll : MonoBehaviour
{
    DateTime TimerEnd;
    public TextMeshProUGUI RemainTime;
    public GameObject RollGetButtonOff;
    public GameObject RollGetButton;
    public Image RemainTimeBackground;

    public bool RollReady;

    public Sprite OnImg;
    public Sprite OffImg;

    private int TimerHour;
    private int TimerMin;
    private int TimerSec;

    void Start()
    {
        TimerEnd = default;
        //1초마다 숫자 변경하게 반복
        InvokeRepeating("Refresh", 0, 1);
    }

    void Update()
    {

    }

    void Refresh()
    {
        string Hour;
        string Min;
        string Sec;
        if (TimerEnd >= DateTime.Now)
        {
            DateTime NowTime = DateTime.Now;
            TimeSpan Timercalc = TimerEnd - NowTime;
            Hour = Timercalc.Hours.ToString();
            if (Timercalc.Hours < 10)
            {
                Hour = "0" + Timercalc.Hours;
            }
            Min = Timercalc.Minutes.ToString();
            if (Timercalc.Minutes < 10)
            {
                Min = "0" + Timercalc.Minutes;
            }
            Sec = Timercalc.Seconds.ToString();
            if (Timercalc.Seconds < 10)
            {
                Sec = "0" + Timercalc.Seconds;
            }
            RemainTime.text = Hour + " : " + Min + " : " + Sec;
            //Debug.Log(Timercalc.Hours+" : "+ Timercalc.Minutes+" : "+ Timercalc.Seconds);
            RollGetButtonOff.SetActive(true);
            RollGetButton.SetActive(false);
            RemainTimeBackground.sprite = OffImg;
        }
        else if (RollReady == false)
        {
            RemainTime.text = "00 : 00 : 00";
            RollGetButtonOff.SetActive(false);
            RollGetButton.SetActive(true);
            RemainTimeBackground.sprite = OnImg;
        }
        else
        {
            if (TimerSec >= 60)
            {
                TimerMin++;
                TimerSec -= 60;
            }
            if (TimerMin >= 60)
            {
                TimerHour++;
                TimerMin -= 60;
            }
            if (TimerHour >= 9)
            {
                TimerHour = 9;
                TimerMin = 0;
                TimerSec = 0;
            }

            Hour = TimerHour.ToString();
            if (TimerHour < 10)
            {
                Hour = "0" + TimerHour;
            }
            Min = TimerMin.ToString();
            if (TimerMin < 10)
            {
                Min = "0" + TimerMin;
            }
            Sec = TimerSec.ToString();
            if (TimerSec < 10)
            {
                Sec = "0" + TimerSec;
            }
            RemainTime.text = Hour + " : " + Min + " : " + Sec;
            RemainTimeBackground.sprite = OnImg;
        }
    }

    public void RollStart()
    {
        //TimerEnd = DateTime.Now.AddHours(9);
        TimerEnd = DateTime.Now.AddSeconds(TimerHour * 3600 + TimerMin * 60 + TimerSec);
        RollReady = false;
        Refresh();
    }

    public void RollSkip()
    {
        //대충 광고 본 후
        TimerEnd = DateTime.Now.AddSeconds(-1);
        Refresh();
    }

    public void RollGet()
    {
        SaveVariables SaveMG = SaveManager.Instance.saveVariables;
        TimerEnd = default;
        int RollResult = Random.Range(0, 5);
        if (RollResult == 0)
        {
            SaveMG.isLeeTaeyeon = true;
        }
        if (RollResult == 1)
        {
            SaveMG.isJeongSeoYoon = true;
        }
        if (RollResult == 2)
        {
            SaveMG.isLeeYerin = true;
        }
        if (RollResult == 3)
        {
            SaveMG.isSongYeonHa = true;
        }
        if (RollResult == 4)
        {
            SaveMG.isSeongJunAh = true;
        }
        RollReady = true;
        Refresh();
    }

    public void HourUp()
    {
        TimerHour++;
        Refresh();
    }
    public void MinUp()
    {
        if (TimerHour != 9)
        {
            TimerMin++;
        }
        Refresh();
    }
    public void SecUp()
    {
        if (TimerHour != 9)
        {
            TimerSec++;
        }
        Refresh();
    }
    public void HourDown()
    {
        if (TimerHour >= 1)
        {
            TimerHour--;
        }
        Refresh();
    }
    public void MinDown()
    {
        if (TimerMin >= 1)
        {
            TimerMin--;
        }
        Refresh();
    }
    public void SecDown()
    {
        if (TimerSec >= 1)
        {
            TimerSec--;
        }
        Refresh();
    }
}
