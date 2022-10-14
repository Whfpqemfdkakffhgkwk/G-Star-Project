using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class Roll : MonoBehaviour
{
	DateTime TimerEnd;
	public TextMeshProUGUI RemainTIme;
	public Button RollButton;
	public Button ResultButton;
	public TextMeshProUGUI ResultText;
	public GameObject ResultWindow;

	void Start()
	{
		TimerEnd = default;
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
			if (TimerEnd == default)
			{
				RemainTIme.text = "Roll Ready";
				ResultWindow.SetActive(false);
				ResultButton.gameObject.SetActive(false);
			}
			else
			{
				RemainTIme.text = "Roll End";
				ResultButton.gameObject.SetActive(true);
			}
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

	public void GetRoll()
	{
		TimerEnd = default;
		int RollResult = Random.Range(0, 11);
		ResultText.text = RollResult.ToString();
		ResultWindow.SetActive(true);
	}

	public void CloseResult()
	{
		ResultWindow.SetActive(false);
	}
}
