using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using static SaveVariables;
using UnityEditor;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Transform OnPos, OffPos;

    [SerializeField] private GameObject TouchWindow;
    [SerializeField] private GameObject QuestWindow;
    [SerializeField] private GameObject[] TouchBtns;
    [SerializeField] private GameObject[] SecondBtns;

    [SerializeField] private GameObject DiamondDirectingObj;

    [SerializeField] private GameObject canvas;

    [SerializeField] private QuestManager questManager;

    [SerializeField] private Dialoue dialoue;

    SaveVariables saveVariables;

    private bool OnQuest = false;
    private void Start()
    {
        saveVariables = SaveManager.Instance.saveVariables;
        StartCoroutine(MainSecond());
    }

    public void MainClick()
    {
        saveVariables.gold += saveVariables.AllTouchMonmey;
        saveVariables.QU_Gold += (int)saveVariables.AllTouchMonmey;
        saveVariables.QU_Click++;
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
                saveVariables.QU_Touch[i]++;
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
                    saveVariables.QU_Second[i]++;
                    break;
                }
            }
        }
    }
    void UpgradeBtn(GoodsList[] list, int arr)
    {
        if (saveVariables.gold >= (ulong)list[arr].UpgradeCost)
        {
            //강화 비용 깎기
            saveVariables.gold -= (ulong)list[arr].UpgradeCost;
            //강화 수치(n강)
            list[arr].UpgradeStep++;
            //강화 비용 늘리기
            list[arr].UpgradeCost += (ulong)(list[arr].UpgradeCost * ((ulong)list[arr].UpgradeStep));
            //강화 적용하기
            SaveManager.Instance.Combine();
        }
    }
    public void QuestMove()
    {
        GameObject ClickObj = EventSystem.current.currentSelectedGameObject;
        if (OnQuest == false)
        {
            ClickObj.transform.DOLocalMoveX(-153, 1f);
            QuestWindow.transform.DOLocalMoveX(-336, 1f);
            OnQuest = true;
        }
        else if (OnQuest == true)
        {
            ClickObj.transform.DOLocalMoveX(913, 1f);
            QuestWindow.transform.DOLocalMoveX(730, 1f);
            OnQuest = false;
        }
    }
    public void QuestClick()
    {
        Image ClickImg = EventSystem.current.currentSelectedGameObject.transform.GetChild(1).GetComponent<Image>();
        if (ClickImg.color == new Color(1, 1, 1, 1))
        {
            DirectingDiamond(EventSystem.current.currentSelectedGameObject.transform);
        }
        questManager.ButtonState(ClickImg);
    }
    void DirectingDiamond(Transform cur)
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject SummonedObject = Instantiate(DiamondDirectingObj, cur);
            SummonedObject.transform.SetParent(canvas.transform);
            Vector2 RandomPos = new Vector2(SummonedObject.transform.position.x + Random.Range(-200f, 200f),
                                            SummonedObject.transform.position.y + Random.Range(-100f, -400f));
            SummonedObject.transform.DOMove(RandomPos, 1.0f);
            StartCoroutine(DirectingDiamondCor(SummonedObject));
            Destroy(SummonedObject, 1.4f);
        }
    }
    public void TalkClick()
    {
        for (int i = 0; i < saveVariables.LeeTaeyeon.Length; i++)
        {
            if (saveVariables.LeeTaeyeon[i])
            {
                saveVariables.LeeTaeyeon[i] = false;
                StartCoroutine(dialoue.StoryStart($"LeeTaeyeon{i + 1}"));
                saveVariables.LeeTaeyeonStep++;
                return;
            }
        }
        for (int i = 0; i < saveVariables.JeongSeoYoon.Length; i++)
        {
            if (saveVariables.JeongSeoYoon[i])
            {
                saveVariables.JeongSeoYoon[i] = false;
                StartCoroutine(dialoue.StoryStart($"JeongSeoYoon{i + 1}"));
                saveVariables.JeongSeoYoonStep++;
                return;
            }
        }
        for (int i = 0; i < saveVariables.LeeYerin.Length; i++)
        {
            if (saveVariables.LeeYerin[i])
            {
                saveVariables.LeeYerin[i] = false;
                StartCoroutine(dialoue.StoryStart($"LeeYerin{i + 1}"));
                saveVariables.LeeYerinStep++;
                return;
            }
        }
        for (int i = 0; i < saveVariables.SongYeonHa.Length; i++)
        {
            if (saveVariables.SongYeonHa[i])
            {
                saveVariables.SongYeonHa[i] = false;
                StartCoroutine(dialoue.StoryStart($"SongYeonHa{i + 1}"));
                saveVariables.SongYeonHaStep++;
                return;
            }
        }
        for (int i = 0; i < saveVariables.SeongJunAh.Length; i++)
        {
            if (saveVariables.SeongJunAh[i])
            {
                saveVariables.SeongJunAh[i] = false;
                StartCoroutine(dialoue.StoryStart($"SeongJunAh{i + 1}"));
                saveVariables.SeongJunAhStep++;
                return;
            }
        }
    }
    IEnumerator DirectingDiamondCor(GameObject obj)
    {
        yield return new WaitForSeconds(1.0f);
        obj.transform.DOLocalMove(new Vector2(264, 1347), 0.5f);
    }
}
