using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Roll : MonoBehaviour
{
	DateTime TimerEnd;
	public TextMeshProUGUI RemainTIme;
	public Button RollButton;
	void Start()
	{
		InvokeRepeating("Refresh", 0, 1);
	}

	void Update()
	{

	}

	void Refresh()
	{
		if (TimerEnd >= DateTime.Now)
		{
			DateTime NowTime = DateTime.Now;
			TimeSpan Timercalc = TimerEnd - NowTime;
			RemainTIme.text = Timercalc.Hours + " : " + Timercalc.Minutes + " : " + Timercalc.Seconds;
			//Debug.Log(Timercalc.Hours+" : "+ Timercalc.Minutes+" : "+ Timercalc.Seconds);
		}
		else
		{
			RemainTIme.text = "Roll End";
		}
	}

	public void PressRoll()
	{
		if (RollButton.GetComponentInChildren<TextMeshProUGUI>().text == "Start Roll")
		{
			TimerEnd = DateTime.Now.AddHours(9);
			RollButton.GetComponentInChildren<TextMeshProUGUI>().text = "Skip Roll";
			Refresh();
		}
		else if (RollButton.GetComponentInChildren<TextMeshProUGUI>().text == "Skip Roll")
		{
			//대충 광고 본 후
			TimerEnd = DateTime.Now.AddSeconds(-1);
			RollButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start Roll";
			Refresh();
		}
	}
}
