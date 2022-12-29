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
	public GameObject RemainTime;
	public GameObject RollGetButtonOff;
	public GameObject RollGetButton;
	public Image RemainTimeBackground;

	public bool RollReady;

	public Sprite OnImg;
	public Sprite OffImg;

	private int TimerHour;
	private int TimerMin;
	private int TimerSec;

	public GameObject RollTrue;
	public GameObject RollFalse;
	public GameObject RollDenie;
	public GameObject TimeUpDown;

	public TextMeshProUGUI Price;

	public GameObject NotenougthDiamond;
	public GameObject RollResult;

	public Sprite[] ImageList;

	void Start()
	{
		TimerEnd = default;
		//1초마다 숫자 변경하게 반복
		InvokeRepeating("Refresh", 0, 1);
	}

	void Update()
	{
		/*Debug.Log(TimerEnd.Hour + " / " + TimerEnd.Minute + " / " + TimerEnd.Second);
		Debug.Log((TimerEnd.Hour * 3600 + TimerEnd.Minute * 60 + TimerEnd.Second));
		Debug.Log((TimerEnd.Hour * 3600 + TimerEnd.Minute * 60 + TimerEnd.Second) / 32400f);*/
	}

	public void Refresh()
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
			RemainTime.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = Hour + " : " + Min + " : " + Sec;
			//Debug.Log(Timercalc.Hours+" : "+ Timercalc.Minutes+" : "+ Timercalc.Seconds);
			RollGetButtonOff.SetActive(true);
			RollGetButton.SetActive(false);
			RemainTimeBackground.sprite = OffImg;
		}
		else if (RollReady == false)
		{
			RemainTime.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "00 : 00 : 00";
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
			RemainTime.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = Hour + " : " + Min + " : " + Sec;
			RemainTimeBackground.sprite = OnImg;
		}
		Price.text = (50 - (int)((TimerHour * 3600 + TimerMin * 60 + TimerSec) / 32400f * 50)).ToString();
		if (SaveManager.Instance.saveVariables.isLeeTaeyeon && SaveManager.Instance.saveVariables.isJeongSeoYoon && SaveManager.Instance.saveVariables.isLeeYerin && SaveManager.Instance.saveVariables.isSongYeonHa)
		{
			RollDenie.SetActive(true);
			RollFalse.SetActive(false);
			RollTrue.SetActive(false);
			RemainTime.SetActive(false);
		}
	}

	public void RollStart()
	{
		//TimerEnd = DateTime.Now.AddHours(9);
		TimerEnd = DateTime.Now.AddSeconds(TimerHour * 3600 + TimerMin * 60 + TimerSec);
		TimeSpan temp = TimerEnd - DateTime.Now;
		//if (SaveManager.Instance.saveVariables.diamond >= 50 - (int)((temp.Hours * 3600 + temp.Minutes * 60 + temp.Seconds) / 32400f * 50) && (int)((temp.Hours * 3600 + temp.Minutes * 60 + temp.Seconds)) > 647)
		if (SaveManager.Instance.saveVariables.diamond >= 50 - (int)((temp.Hours * 3600 + temp.Minutes * 60 + temp.Seconds) / 32400f * 50))
		{
			SaveManager.Instance.saveVariables.diamond -= (50 - (int)((temp.Hours * 3600 + temp.Minutes * 60 + temp.Seconds) / 32400f * 50));
			RollReady = false;
			RollFalse.SetActive(false);
			RollTrue.SetActive(true);
			TimeUpDown.SetActive(false);
			Refresh();
		}
		else
		{
			TimerEnd = DateTime.Now.AddSeconds(-1);
			RollFalse.SetActive(true);
			RollTrue.SetActive(false);
			TimeUpDown.SetActive(true);
			NotenougthDiamond.SetActive(true);
		}
	}

	public void RollSkip()
	{
		//대충 광고 본 후
		TimerEnd = DateTime.Now.AddSeconds(-1);
		Refresh();
	}

	public void RollGet()
	{
		bool[] SaveMG = { true, false, false, false, false };
		SaveMG[0] = SaveManager.Instance.saveVariables.isLeeTaeyeon;
		SaveMG[1] = SaveManager.Instance.saveVariables.isJeongSeoYoon;
		SaveMG[2] = SaveManager.Instance.saveVariables.isLeeYerin;
		SaveMG[3] = SaveManager.Instance.saveVariables.isSongYeonHa;
		SaveMG[4] = SaveManager.Instance.saveVariables.isSeongJunAh;
		string[] CharacterName = { "RLeeTaeyeon", "RJeongSeoYoon", "RLeeYerin", "RSongYeonHa" };
		TimerEnd = default;
		int RollResultData = Random.Range(0, 14);
		if (RollResultData <= 3)
		{
			if (SaveMG[RollResultData] == false)
			{
				GameObject.Find(CharacterName[RollResultData]).GetComponent<Animator>().SetTrigger("Happy");
				SaveManager.Instance.saveVariables.QU_Draw++;
				switch (RollResultData)
				{
					case 0:
						SaveManager.Instance.saveVariables.isLeeTaeyeon = true;
						RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[0];
						RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'이태연'을 획득했습니다!";
						break;
					case 1:
						SaveManager.Instance.saveVariables.isJeongSeoYoon = true;
						RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[1];
						RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'정서윤'을 획득했습니다!";
						break;
					case 2:
						SaveManager.Instance.saveVariables.isLeeYerin = true;
						RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[2];
						RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'이예린'을 획득했습니다!";
						break;
					case 3:
						SaveManager.Instance.saveVariables.isSongYeonHa = true;
						RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[3];
						RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'송연하'을 획득했습니다!";
						break;
				}
			}
			else
			{
				RollGet();
			}
		}
		else if (RollResultData >= 4)
		{
			Debug.Log("부스터 획득");
		}
		RollResult.SetActive(true);
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
