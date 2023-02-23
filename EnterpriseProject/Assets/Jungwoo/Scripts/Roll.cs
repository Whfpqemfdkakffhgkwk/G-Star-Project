using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
		//1�ʸ��� ���� �����ϰ� �ݺ�
		InvokeRepeating("Refresh", 0, 1);
	}

	void Update()
	{

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
		//ĳ���� �� �̾��� �� �̱� ���� ���
		//if (SaveManager.Instance.saveVariables.isLeeTaeyeon && SaveManager.Instance.saveVariables.isJeongSeoYoon && SaveManager.Instance.saveVariables.isLeeYerin && SaveManager.Instance.saveVariables.isSongYeonHa)
		//{
		//	RollDenie.SetActive(true);
		//	RollFalse.SetActive(false);
		//	RollTrue.SetActive(false);
		//	RemainTime.SetActive(false);
		//}
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
			NotenougthDiamond.transform.localScale = new Vector2(0.5f, 0.5f);
			NotenougthDiamond.transform.parent.gameObject.SetActive(true);
			NotenougthDiamond.transform.DOScale(new Vector2(1, 1), 0.5f);
		}
	}

	public void RollSkip()
	{
		PlayAdvertisement.Instance.PlayingAd();
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
		int RollResultData = Random.Range(0, 24);
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
						RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'���¿�'�� ȹ���߽��ϴ�!";
						RollResult.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
						SaveManager.Instance.saveVariables.QU_TouchHeart[2] = 0;
						break;
					case 1:
						SaveManager.Instance.saveVariables.isJeongSeoYoon = true;
						RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[1];
						RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'������'�� ȹ���߽��ϴ�!";
						RollResult.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
						SaveManager.Instance.saveVariables.QU_TouchHeart[1] = 0;
						break;
					case 2:
						SaveManager.Instance.saveVariables.isLeeYerin = true;
						RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[2];
						RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'�̿���'�� ȹ���߽��ϴ�!";
						RollResult.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
						SaveManager.Instance.saveVariables.QU_TouchHeart[0] = 0;
						break;
					case 3:
						SaveManager.Instance.saveVariables.isSongYeonHa = true;
						RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[3];
						RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'�ۿ���'�� ȹ���߽��ϴ�!";
						RollResult.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
						SaveManager.Instance.saveVariables.QU_TouchHeart[3] = 0;
						break;
				}
			}
			else
			{
				RollGet();
			}
		}
		else if (RollResultData >= 4 && RollResultData <= 10)
		{
			SaveManager.Instance.saveVariables.ManyMoney += 1;
			RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[4];
			RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'ū�� ȹ��'�� ȹ���߽��ϴ�!";
			RollResult.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "��ġ ������ 1500�� ȹ�� �� �� �ִ� ������";
		}
		else if (RollResultData >= 11 && RollResultData <= 17)
		{
			SaveManager.Instance.saveVariables.Fever += 1;
			RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[5];
			RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'�ǹ�'�� ȹ���߽��ϴ�!";
			RollResult.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "3�е��� ��ġ ������ �����ϴ� ������";
		}
		else if (RollResultData >= 18 && RollResultData <= 20)
		{
			SaveManager.Instance.saveVariables.GodHand += 0.2f;
			RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[6];
			RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'���� ��'�� ȹ���߽��ϴ�!";
			RollResult.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "��ġ ���� ���������� 0.2%����, ��ø O";
		}
		else if (RollResultData >= 21 && RollResultData <= 23)
		{
			SaveManager.Instance.saveVariables.GoldenTicket += 0.2f;
			RollResult.transform.GetChild(0).GetComponent<Image>().sprite = ImageList[7];
			RollResult.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "'Ȳ�� Ƽ��'�� ȹ���߽��ϴ�!";
			RollResult.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "�̴ϰ��� ���� ���������� 0.2%����, ��ø O";
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
