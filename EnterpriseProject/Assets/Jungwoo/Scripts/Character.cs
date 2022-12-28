using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
	public GameObject InformationPannel;
	public GameObject CharacterObj;
	public GameObject EvFalse;
	public GameObject EvTrue;
	public GameObject EvText;

	private SaveVariables SM;
	public GameObject CLeeTaeyeon;
	public GameObject CJeongSeoYoon;
	public GameObject CLeeYerin;
	public GameObject CSongYeonHa;

	public GameObject Background;

	public GameObject Pannel1;
	public GameObject Pannel2;
	public GameObject Pannel3;
	public GameObject Pannel4;

	public int LeeTaeyeonEvCount;
	public int JeongSeoYoonEvCount;
	public int LeeYerinEvCount;
	public int SongYeonHaEvCount;

	private float XLoc;
	private float YLoc;

	void Awake()
	{
		SM = SaveManager.Instance.saveVariables;
	}
	void Start()
	{
		if (name != "Character")
		{
			StartCoroutine(MoveCycle());
			StartCoroutine(Event());
		}
	}

	void Update()
	{
		if (name == "Character")
		{
			if (SM.isLeeTaeyeon == true)
			{
				CLeeTaeyeon.SetActive(true);
			}
			else
			{
				CLeeTaeyeon.SetActive(false);
			}
			if (SM.isJeongSeoYoon == true)
			{
				CJeongSeoYoon.SetActive(true);
			}
			else
			{
				CJeongSeoYoon.SetActive(false);
			}
			if (SM.isLeeYerin == true)
			{
				CLeeYerin.SetActive(true);
			}
			else
			{
				CLeeYerin.SetActive(false);
			}
			if (SM.isSongYeonHa == true)
			{
				CSongYeonHa.SetActive(true);
			}
			else
			{
				CSongYeonHa.SetActive(false);
			}
			GetComponent<RectTransform>().localPosition = new Vector3(Background.GetComponent<RectTransform>().localPosition.x, 0, 0);
			CLeeTaeyeon.transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "헬스장 " + SM.QU_Touch[2] + " / " + (10 + (((int)SM.LeeTaeyeonCrush / 20) * 10)) + " 번 업그레이드 하기";
			CJeongSeoYoon.transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "도서실 " + SM.QU_Touch[1] + " / " + (10 + (((int)SM.JeongSeoYoonCrush / 20) * 10)) + " 번 업그레이드 하기";
			CLeeYerin.transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "노래방 " + SM.QU_Touch[0] + " / " + (10 + (((int)SM.LeeYerinCrush / 20) * 10)) + " 번 업그레이드 하기";
			CSongYeonHa.transform.GetChild(4).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "피시방 " + SM.QU_Touch[3] + " / " + (10 + (((int)SM.SongYeonHaCrush / 20) * 10)) + " 번 업그레이드 하기";
			Pannel1.GetComponent<RectTransform>().localPosition = new Vector3(-Background.GetComponent<RectTransform>().localPosition.x, 530, 0);
			Pannel2.GetComponent<RectTransform>().localPosition = new Vector3(-Background.GetComponent<RectTransform>().localPosition.x, 530, 0);
			Pannel3.GetComponent<RectTransform>().localPosition = new Vector3(-Background.GetComponent<RectTransform>().localPosition.x, 530, 0);
			Pannel4.GetComponent<RectTransform>().localPosition = new Vector3(-Background.GetComponent<RectTransform>().localPosition.x, 530, 0);
		}
	}

	IEnumerator MoveCycle()
	{
		int Temp = 0;
		int LR = 0;
		while (true)
		{
			XLoc = CharacterObj.transform.localPosition.x;
			YLoc = CharacterObj.transform.localPosition.y;
			Temp = Random.Range(15, 31);
			if (Random.Range(0, 2) == 0)
			{
				LR = -1;
			}
			else
			{
				LR = 1;
			}
			if (this.name == "CLeeTaeyeon" && CharacterObj.transform.localPosition.x <= -550 - 1924 * 2)
			{
				LR = 1;
			}
			else if (this.name == "CLeeTaeyeon" && CharacterObj.transform.localPosition.x >= 550 - 1924 * 2)
			{
				LR = -1;
			}
			else if (this.name == "CJeongSeoYoon" && CharacterObj.transform.localPosition.x <= -550 - 1924 * 1)
			{
				LR = 1;
			}
			else if (this.name == "CJeongSeoYoon" && CharacterObj.transform.localPosition.x >= 550 - 1924 * 1)
			{
				LR = -1;
			}
			else if (this.name == "CLeeYerin" && CharacterObj.transform.localPosition.x <= -550 + 1924 * 2)
			{
				LR = 1;
			}
			else if (this.name == "CLeeYerin" && CharacterObj.transform.localPosition.x >= 550 + 1924 * 2)
			{
				LR = -1;
			}
			else if (this.name == "CSongYeonHa" && CharacterObj.transform.localPosition.x <= -550 + 1924 * 1)
			{
				LR = 1;
			}
			else if (this.name == "CSongYeonHa" && CharacterObj.transform.localPosition.x >= 550 + 1924 * 1)
			{
				LR = -1;
			}
			if (LR == 1)
			{
				GetComponent<SpriteRenderer>().flipX = false;
			}
			else
			{
				GetComponent<SpriteRenderer>().flipX = true;
			}
			GetComponent<Animator>().SetTrigger("Walk");
			for (int i = 0; i < Temp; i++)
			{
				if (CharacterObj.transform.localPosition.x >= 3500 && LR == 1)
				{

				}
				else if (CharacterObj.transform.localPosition.x <= -3500 && LR == -1)
				{

				}
				else
				{
					CharacterObj.transform.localPosition = new Vector3((XLoc + i * 10 * LR), YLoc, -1);
					yield return new WaitForSeconds(0.02f);
				}
			}
			GetComponent<Animator>().SetTrigger("Idle");
			yield return new WaitForSeconds(Random.Range(1.5f, 3f));
		}
	}

	IEnumerator Event()
	{
		while (true)
		{
			if (name == "CLeeTaeyeon" && SM.LeeTaeyeonCrush <= 80)
			{
				if (SM.QU_Touch[2] >= (10 + (((int)SM.LeeTaeyeonCrush / 20) * 10)))
				{
					EvFalse.SetActive(false);
					EvTrue.SetActive(true);
				}
				else
				{
					EvTrue.SetActive(false);
					EvFalse.SetActive(true);
					yield return new WaitForSeconds(2f);
					EvFalse.SetActive(false);
					EvText.SetActive(true);
					yield return new WaitForSeconds(2f);
					EvText.SetActive(false);
				}
			}
			if (name == "CJeongSeoYoon" && SM.JeongSeoYoonCrush <= 80)
			{
				if (SM.QU_Touch[1] >= (10 + (((int)SM.JeongSeoYoonCrush / 20) * 10)))
				{
					EvFalse.SetActive(false);
					EvTrue.SetActive(true);
				}
				else
				{
					EvTrue.SetActive(false);
					EvFalse.SetActive(true);
					yield return new WaitForSeconds(2f);
					EvFalse.SetActive(false);
					EvText.SetActive(true);
					yield return new WaitForSeconds(2f);
					EvText.SetActive(false);
				}
			}
			if (name == "CLeeYerin" && SM.LeeYerinCrush <= 80)
			{
				if (SM.QU_Touch[0] >= (10 + (((int)SM.LeeYerinCrush / 20) * 10)))
				{
					EvFalse.SetActive(false);
					EvTrue.SetActive(true);
				}
				else
				{
					EvTrue.SetActive(false);
					EvFalse.SetActive(true);
					yield return new WaitForSeconds(2f);
					EvFalse.SetActive(false);
					EvText.SetActive(true);
					yield return new WaitForSeconds(2f);
					EvText.SetActive(false);
				}
			}
			if (name == "CSongYeonHa" && SM.SongYeonHaCrush <= 80)
			{
				if (SM.QU_Touch[3] >= (10 + (((int)SM.SongYeonHaCrush / 20) * 10)))
				{
					EvFalse.SetActive(false);
					EvTrue.SetActive(true);
				}
				else
				{
					EvTrue.SetActive(false);
					EvFalse.SetActive(true);
					yield return new WaitForSeconds(2f);
					EvFalse.SetActive(false);
					EvText.SetActive(true);
					yield return new WaitForSeconds(2f);
					EvText.SetActive(false);
				}
			}
			yield return new WaitForSeconds(Random.Range(1f, 2f));
			//yield return new WaitForSeconds(Random.Range(10f, 20f));
		}
	}

	public void LeeTaeyeonEv()
	{
		//LeeTaeyeonEvCount++;
	}
	public void LeeTaeyeonEvTouch()
	{
		SM.LeeTaeyeonCrush += 20;
		LeeTaeyeonEvCount -= 10;
	}
	public void JeongSeoYoonEv()
	{
		//JeongSeoYoonEvCount++;
	}
	public void JeongSeoYoonEvTouch()
	{
		SM.JeongSeoYoonCrush += 20;
		JeongSeoYoonEvCount -= 10;
	}
	public void LeeYerinEv()
	{
		//LeeYerinEvCount++;
	}
	public void LeeYerinEvTouch()
	{
		SM.LeeYerinCrush += 20;
		LeeYerinEvCount -= 10;
	}
	public void SongYeonHaEv()
	{
		//SongYeonHaEvCount++;
	}
	public void SongYeonHaEvTouch()
	{
		SM.SongYeonHaCrush += 20;
		SongYeonHaEvCount -= 10;
	}
}