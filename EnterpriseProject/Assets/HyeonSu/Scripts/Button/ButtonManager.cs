using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SaveVariables;

public class ButtonManager : MonoBehaviour
{
	[SerializeField] Transform OnPos, OffPos;

	[SerializeField] private GameObject TouchWindow;
	[SerializeField] private GameObject QuestWindow;
	[SerializeField] private GameObject[] TouchBtns, SecondBtns;

	[SerializeField] private Image[] TalkerImages;
	[SerializeField] private Sprite[] TalkerSprs;

	[SerializeField] private GameObject DiamondDirectingObj, GoldDirectingObj, ParticleObj;

	[SerializeField] private GameObject canvas, DiamondCanvas;

	[SerializeField] private QuestManager questManager;

	[SerializeField] private Dialoue dialoue;

	[SerializeField] private GameObject QuitWindow;

 	[SerializeField] private Character LeeTaecharacter, Jeongcharater, LeeYaecharater, Songcharater;

	SaveVariables saveVariables;

	private bool OnQuest = false;
	private void Start()
	{
		saveVariables = SaveManager.Instance.saveVariables;
		StartCoroutine(MainSecond());
	}

	private void FixedUpdate()
	{
		TalkerOpen();
		QuitCheck();
	}
	public void MainClick()
	{
        SoundManager.Instance.PlaySoundClip("SFX_MainClick", SoundType.SFX);
        DirectingGold(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		StartCoroutine(GoldDelay());
		GameObject particle = Instantiate(ParticleObj, canvas.transform);
		particle.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		particle.transform.position = new Vector3(particle.transform.position.x, particle.transform.position.y, 0);
		Destroy(particle, 0.8f);
	}
	void QuitCheck()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKey(KeyCode.Escape))
			{
				QuitWindow.transform.localScale = new Vector2(0, 0);
				QuitWindow.SetActive(true);
				QuitWindow.transform.DOScale(new Vector2(1, 1), 0.7f);
			}
		}
	}
	public void QuitOrCancel()
	{
		if (EventSystem.current.currentSelectedGameObject.name.Equals("Quit"))
		{
			Application.Quit();
		}
		else
			QuitWindow.SetActive(false);
	}
    public IEnumerator MainSecond()
	{
		saveVariables.gold += saveVariables.AllSecondMoney;
		saveVariables.QU_Gold += (int)saveVariables.AllSecondMoney;
		yield return new WaitForSeconds(1);
		saveVariables.QU_PlayTime++;
		StartCoroutine(MainSecond());
	}
	public void UpgradePressBtns()
	{
		bool typeCheck = false;
		GameObject ClickObj = EventSystem.current.currentSelectedGameObject;
		for (int i = 0; i < TouchBtns.Length; i++)
		{
			typeCheck = true;
			if (TouchBtns[i] == ClickObj)
			{
				UpgradeBtn(saveVariables.TouchType, i);
				break;
			}
		}
		if (typeCheck)
		{
			for (int i = 0; i < SecondBtns.Length; i++)
			{
				if (SecondBtns[i] == ClickObj)
				{
					UpgradeBtn(saveVariables.SecondType, i);
					break;
				}
			}
		}
	}
	void UpgradeBtn(GoodsList[] list, int arr)
	{
		if (saveVariables.gold >= (ulong)list[arr].UpgradeCost)
		{
			SoundManager.Instance.PlaySoundClip("SFX_UpgradeSound", SoundType.SFX);
			//퀘스트 업그레이드
			if (list == saveVariables.TouchType)
				saveVariables.QU_Touch[arr]++;
			else if (list == saveVariables.SecondType)
				saveVariables.QU_Second[arr]++;
			//강화 비용 깎기
			saveVariables.gold -= (ulong)list[arr].UpgradeCost;
			//강화 수치(n강)
			list[arr].UpgradeStep++;
			//강화 비용 늘리기
			list[arr].UpgradeCost += (ulong)(list[arr].UpgradeCost * 0.2f); //밸런싱 해야하는 부분
			//강화 적용하기
			SaveManager.Instance.AllGoodPlus(list, arr);
		}
	}
	public void QuestMove()
	{
		GameObject ClickObj = EventSystem.current.currentSelectedGameObject;
		if (OnQuest == false)
		{
			ClickObj.transform.DOLocalMoveX(720, 1f);
			QuestWindow.transform.DOLocalMoveX(696, 1f);
			OnQuest = true;
		}
		else if (OnQuest == true)
		{
			ClickObj.transform.DOLocalMoveX(-295, 1f);
			QuestWindow.transform.DOLocalMoveX(-315, 1f);
			OnQuest = false;
		}
	}
	public void QuestClick()
	{
		Image ClickImg = EventSystem.current.currentSelectedGameObject.transform.GetChild(1).GetComponent<Image>();
		if (ClickImg.color == new Color(1, 1, 1, 1))
		{
			SoundManager.Instance.PlaySoundClip("SFX_QuestClick", SoundType.SFX);
			DirectingDiamond(EventSystem.current.currentSelectedGameObject.transform);
		}
		questManager.ButtonState(ClickImg);
	}
	void DirectingDiamond(Transform cur)
	{
		for (int i = 0; i < 50; i++)
		{
			GameObject SummonedObject = Instantiate(DiamondDirectingObj, cur);
			SummonedObject.transform.SetParent(DiamondCanvas.transform);
			Vector2 RandomPos = new Vector2(SummonedObject.transform.localPosition.x + Random.Range(-200f, 200f),
											SummonedObject.transform.localPosition.y + Random.Range(-100f, -400f));
			SummonedObject.transform.DOLocalMove(RandomPos, 1.0f);
			StartCoroutine(DirectingDiamondCor(SummonedObject));
			Destroy(SummonedObject, 1.4f);
		}
	}
	void DirectingGold(Vector3 cur)
	{
		for (int i = 0; i < 25; i++)
		{
			GameObject SummonedObject = Instantiate(GoldDirectingObj, canvas.transform);
			SummonedObject.transform.position = cur;
			//SummonedObject.transform.SetParent(canvas.transform);
			Vector2 RandomPos = new Vector2(SummonedObject.transform.localPosition.x + Random.Range(-200f, 200f),
											SummonedObject.transform.localPosition.y + Random.Range(-100f, -400f));
			SummonedObject.transform.DOLocalMove(RandomPos, 0.7f);
			StartCoroutine(DirectingGoldCor(SummonedObject));
			Destroy(SummonedObject, 1.1f);
		}
	}
	public void TalkClick() //누른 버튼이 누구 버튼인지 알아내고 각 캐릭터의 for문 돌리면 될듯
	{
		switch (EventSystem.current.currentSelectedGameObject.name)
		{
			case "LeeTaeyeon":
				for (int i = 0; i < saveVariables.LeeTaeyeon.Length; i++)
				{
					if (saveVariables.LeeTaeyeon[i])
					{
						saveVariables.LeeTaeyeon[i] = false;
						StartCoroutine(dialoue.StoryStart($"LeeTaeyeon{i + 1}"));
						saveVariables.LeeTaeyeonCrush++;
						return;
					}
				}
				break;
			case "JeongSeoYoon":
				for (int i = 0; i < saveVariables.JeongSeoYoon.Length; i++)
				{
					if (saveVariables.JeongSeoYoon[i])
					{
						saveVariables.JeongSeoYoon[i] = false;
						StartCoroutine(dialoue.StoryStart($"JeongSeoYoon{i + 1}"));
						saveVariables.JeongSeoYoonCrush++;
						return;
					}
				}
				break;
			case "LeeYerin":
				for (int i = 0; i < saveVariables.LeeYerin.Length; i++)
				{
					if (saveVariables.LeeYerin[i])
					{
						saveVariables.LeeYerin[i] = false;
						StartCoroutine(dialoue.StoryStart($"LeeYerin{i + 1}"));
						saveVariables.LeeYerinCrush++;
						return;
					}
				}
				break;
			case "SongYeonHa":
				for (int i = 0; i < saveVariables.SongYeonHa.Length; i++)
				{
					if (saveVariables.SongYeonHa[i])
					{
						saveVariables.SongYeonHa[i] = false;
						StartCoroutine(dialoue.StoryStart($"SongYeonHa{i + 1}"));
						saveVariables.SongYeonHaCrush++;
						return;
					}
				}
				break;
			case "SeongJunAh":
				for (int i = 0; i < saveVariables.SeongJunAh.Length; i++)
				{
					if (saveVariables.SeongJunAh[i])
					{
						saveVariables.SeongJunAh[i] = false;
						StartCoroutine(dialoue.StoryStart($"SeongJunAh{i + 1}"));
						saveVariables.SeongJunAhCrush++;
						return;
					}
				}
				break;
		}
	}
	void TalkerOpen()
	{
		if (saveVariables.isJeongSeoYoon)
			TalkerImages[0].sprite = TalkerSprs[0];
		if (saveVariables.isLeeYerin)
			TalkerImages[1].sprite = TalkerSprs[1];
		if (saveVariables.isSongYeonHa)
			TalkerImages[2].sprite = TalkerSprs[2];
		//오류나서 주석쳐둠
		//if (saveVariables.isSeongJunAh)
		//    TalkerImages[3].sprite = TalkerSprs[3];
	}
	IEnumerator DirectingDiamondCor(GameObject obj)
	{
		yield return new WaitForSeconds(1.0f);
		obj.transform.DOLocalMove(new Vector2(264, 1347), 0.5f);
	}
	IEnumerator DirectingGoldCor(GameObject obj)
	{
		yield return new WaitForSeconds(0.7f);
		obj.transform.DOLocalMove(new Vector2(-298, 1344), 0.5f);
	}
	IEnumerator GoldDelay()
	{
		yield return new WaitForSeconds(1.1f);
		saveVariables.gold += saveVariables.AllTouchMonmey;
		saveVariables.QU_Gold += (int)saveVariables.AllTouchMonmey;
		saveVariables.QU_Click++;
	}
}
