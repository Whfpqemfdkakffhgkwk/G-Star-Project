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
	public TextMeshProUGUI ResultText;
	public GameObject ResultWindow;
	public GameObject RollGetButtonOff;
	public GameObject RollGetButton;

	public bool RollReady;

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
		if (TimerEnd >= DateTime.Now)
		{
			DateTime NowTime = DateTime.Now;
			TimeSpan Timercalc = TimerEnd - NowTime;
			RemainTime.text = Timercalc.Hours + " : " + Timercalc.Minutes + " : " + Timercalc.Seconds;
			//Debug.Log(Timercalc.Hours+" : "+ Timercalc.Minutes+" : "+ Timercalc.Seconds);
			RollGetButtonOff.SetActive(true);
			RollGetButton.SetActive(false);
		}
		else if (RollReady == false)
		{
			RemainTime.text = "Roll End";
			RollGetButtonOff.SetActive(false);
			RollGetButton.SetActive(true);
		}
		else
		{
			RemainTime.text = "Roll Ready";
		}
	}

	public void RollStart()
	{
		TimerEnd = DateTime.Now.AddHours(9);
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
		TimerEnd = default;
		int RollResult = Random.Range(0, 11);
		ResultText.text = RollResult.ToString();
		ResultWindow.SetActive(true);
		RollReady = true;
		Refresh();
	}

	public void CloseResult()
	{
		ResultWindow.SetActive(false);
	}
}
