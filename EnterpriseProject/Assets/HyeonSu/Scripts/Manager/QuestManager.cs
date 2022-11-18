using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    [SerializeField] private Text[] Touch, Second;
    [SerializeField] private Text Gold, Click, PlayTime, Draw;

    [SerializeField] private Image[] TouchStatus, SecondStatus;
    [SerializeField] private Image GoldStatus, ClickStatus, PlayTimeStatus, DrawStatus;

    [SerializeField] private Slider[] TouchSliders, SecondSliders;
    [SerializeField] private Slider GoldSlider, ClickSlider, PlayTimeSlider, DrawSlider;

    [SerializeField] private Text[] TouchLists, SecondLists;
    [SerializeField] private Text GoldList, ClickList, PlayTimeList, DrawList;

    [SerializeField] private Button TalkBtn;
    [SerializeField] private GameObject Notice, QuestNotice;

    [SerializeField] private Image[] TalkBtnImages;
    [SerializeField] private Sprite OnTalkBtnSpr, TalkBtnSpr;

    [SerializeField] private Slider[] CrushSliders;

    Dictionary<int, string> TouchName = new Dictionary<int, string>();
    Dictionary<int, string> SecondName = new Dictionary<int, string>();

    SaveVariables saveVariables;

    private void Awake()
    {
        saveVariables = SaveManager.Instance.saveVariables;
    }

    private void Start()
    {
        AddDictionary();
    }
    private void Update()
    {
        OrganizeStatusText();
        CrushUpdate();
    }
    void AddDictionary()
    {
        TouchName.Add(0, "노래방");
        TouchName.Add(1, "도서실");
        TouchName.Add(2, "헬스장");
        TouchName.Add(3, "피시방");
        SecondName.Add(0, "반지하");
        SecondName.Add(1, "스탠다드룸");
        SecondName.Add(2, "딜럭스룸");
        SecondName.Add(3, "스위트룸");
    }
    void CrushUpdate()
    {
        for (int i = 0; i < saveVariables.LeeTaeyeon.Length; i++)
        {
            TalkBtnImages[i].sprite = TalkBtnSpr;
        }
        Notice.SetActive(false);
        for (int i = 0; i < saveVariables.LeeTaeyeon.Length; i++)
        {
            if (saveVariables.LeeTaeyeon[i] && saveVariables.isLeeTaeyeon)
            {
                Notice.SetActive(true);
                TalkBtnImages[0].sprite = OnTalkBtnSpr;
            }
        }
        for (int i = 0; i < saveVariables.JeongSeoYoon.Length; i++)
        {
            if (saveVariables.JeongSeoYoon[i] && saveVariables.isJeongSeoYoon)
            {
                Notice.SetActive(true);
                TalkBtnImages[1].sprite = OnTalkBtnSpr;
            }
        }
        for (int i = 0; i < saveVariables.LeeYerin.Length; i++)
        {
            if (saveVariables.LeeYerin[i] && saveVariables.isLeeYerin)
            {
                Notice.SetActive(true);
                TalkBtnImages[2].sprite = OnTalkBtnSpr;
            }
        }
        for (int i = 0; i < saveVariables.SongYeonHa.Length; i++)
        {
            if (saveVariables.SongYeonHa[i] && saveVariables.isSongYeonHa)
            {
                Notice.SetActive(true);
                TalkBtnImages[3].sprite = OnTalkBtnSpr;
            }
        }
        for (int i = 0; i < saveVariables.SeongJunAh.Length; i++)
        {
            if (saveVariables.SeongJunAh[i] && saveVariables.isSeongJunAh)
            {
                Notice.SetActive(true);
                TalkBtnImages[4].sprite = OnTalkBtnSpr;
            }
        }
        CrushSliders[0].value = saveVariables.LeeTaeyeonCrush;
        CrushSliders[1].value = saveVariables.JeongSeoYoonCrush;
        CrushSliders[2].value = saveVariables.LeeYerinCrush;
        CrushSliders[3].value = saveVariables.SongYeonHaCrush;
        CrushSliders[4].value = saveVariables.SeongJunAhCrush;
    }
    void OrganizeStatusText()
    {
        QuestNotice.SetActive(false);
        for (int i = 0; i < Touch.Length; i++)
        {
            Touch[i].text = saveVariables.QU_Touch[i].ToString() + "/" + ((10 * saveVariables.QUN_Touch[i]) + 10).ToString();
            TouchLists[i].text = $"'{TouchName[i]}' 레벨을 {(10 * saveVariables.QUN_Touch[i]) + 10}레벨 올리기";
            TouchSliders[i].value = (saveVariables.QU_Touch[i] - 10f * saveVariables.QUN_Touch[i]) / 10;
            if (saveVariables.QU_Touch[i] >= ((10 * saveVariables.QUN_Touch[i]) + 10))
            {
                TouchStatus[i].color = new Color(1, 1, 1, 1);
                QuestNotice.SetActive(true);
            }
        }

        for (int i = 0; i < Second.Length; i++)
        {
            Second[i].text = saveVariables.QU_Second[i].ToString() + "/" + ((10 * saveVariables.QUN_Second[i]) + 10).ToString();
            SecondLists[i].text = $"'{SecondName[i]}' 레벨을 {(10 * saveVariables.QUN_Second[i]) + 10}레벨 올리기";
            SecondSliders[i].value = (saveVariables.QU_Second[i] - 10f * saveVariables.QUN_Second[i]) / 10;
            if (saveVariables.QU_Second[i] >= ((10 * saveVariables.QUN_Second[i]) + 10))
            {
                SecondStatus[i].color = new Color(1, 1, 1, 1);
                QuestNotice.SetActive(true);
            }
        }

        Gold.text = saveVariables.QU_Gold.ToString() + "/" + (ulong)(1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1));
        GoldList.text = $"골드를 {(ulong)(1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1))}원 획득하기";
        GoldSlider.value = (saveVariables.QU_Gold) / (1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1));
        if (saveVariables.QU_Gold >= (1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1)))
        {
            GoldStatus.color = new Color(1, 1, 1, 1);
            QuestNotice.SetActive(true);
        }

        Click.text = saveVariables.QU_Click.ToString() + "/" + ((300 * saveVariables.QUN_Click) + 300).ToString();
        ClickList.text = $"터치를 {(300 * saveVariables.QUN_Click) + 300}번 하기";
        ClickSlider.value = (saveVariables.QU_Click - 300f * saveVariables.QUN_Click) / 300; //
        if (saveVariables.QU_Click >= ((300 * saveVariables.QUN_Click) + 300))
        {
            ClickStatus.color = new Color(1, 1, 1, 1);
            QuestNotice.SetActive(true);
        }

        PlayTime.text = saveVariables.QU_PlayTime.ToString() + "/" + ((100 * saveVariables.QUN_PlayTime) + 100).ToString();
        PlayTimeList.text = $"{(100 * saveVariables.QUN_PlayTime) + 100}초 플레이하기";
        PlayTimeSlider.value = (saveVariables.QU_PlayTime - 100 * saveVariables.QUN_PlayTime) / 100;
        if (saveVariables.QU_PlayTime >= ((100 * saveVariables.QUN_PlayTime) + 100))
        {
            PlayTimeStatus.color = new Color(1, 1, 1, 1);
            QuestNotice.SetActive(true);
        }

        Draw.text = saveVariables.QU_Draw.ToString() + "/" + ((1 * saveVariables.QUN_Draw) + 1).ToString();
        DrawList.text = $"캐릭터를 {(1 * saveVariables.QUN_Draw) + 1}번 뽑으세요";
        DrawSlider.value = (saveVariables.QU_Draw - 1f * saveVariables.QUN_Draw) / 1;
        if (saveVariables.QU_Draw >= ((1 * saveVariables.QUN_Draw) + 1))
        {
            DrawStatus.color = new Color(1, 1, 1, 1);
            QuestNotice.SetActive(true);
        }
    }
    public void ButtonState(Image PressObj)//<- 누른 오브젝트
    {
        if (PressObj.color == new Color(1, 1, 1, 1))
        {
            for (int i = 0; i < Touch.Length; i++)
            {
                if (PressObj == TouchStatus[i])
                {
                    TouchStatus[i].color = new Color(1, 1, 1, 0);
                    saveVariables.QUN_Touch[i]++;
                    StartCoroutine(QuestReward(10 * (i + 1)));
                    return;
                }
            }
            for (int i = 0; i < Second.Length; i++)
            {
                if (PressObj == SecondStatus[i])
                {
                    SecondStatus[i].color = new Color(1, 1, 1, 0);
                    saveVariables.QUN_Second[i]++;
                    StartCoroutine(QuestReward(10 * (i + 1)));
                    return;
                }
            }

            if (PressObj == GoldStatus)
            {
                GoldStatus.color = new Color(1, 1, 1, 0);
                saveVariables.QU_Gold -= (ulong)(1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1));
                saveVariables.QUN_Gold++;
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == ClickStatus)
            {
                ClickStatus.color = new Color(1, 1, 1, 0);
                saveVariables.QUN_Click++;
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == PlayTimeStatus)
            {
                PlayTimeStatus.color = new Color(1, 1, 1, 0);
                saveVariables.QUN_PlayTime++;
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == DrawStatus)
            {
                DrawStatus.color = new Color(1, 1, 1, 0);
                saveVariables.QUN_Draw++;
                StartCoroutine(QuestReward(50));
            }
        }
        //if 누른 오브젝트가 색이 1,1,1,1이면
        //누른 오브젝트 찾고
        //색 50/255로 바꾸고
        //카운트 1추가한다
    }
    IEnumerator QuestReward(int GetDia)
    {
        yield return new WaitForSeconds(1.4f);
        saveVariables.diamond += GetDia;
    }
}
