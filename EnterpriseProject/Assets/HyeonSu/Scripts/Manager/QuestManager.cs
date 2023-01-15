using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    [Tooltip("퀘스트 클리어가 됐는지 확인하는 bool값")] private bool[] isTouch, isSecond;
    [Tooltip("퀘스트 클리어가 됐는지 확인하는 bool값")] private bool isGold, isClick, isPlayTime, isDraw;

    [SerializeField] private GameObject[] TouchCannes, SecondCannes;
    [SerializeField] private GameObject GoldCannes, ClickCannes, PlayTimeCannes, DrawCannes;

    [SerializeField] private Text[] Touch, Second;
    [SerializeField] private Text Gold, Click, PlayTime, Draw;

    [SerializeField] private Image[] TouchStatus, SecondStatus;
    [SerializeField] private Image GoldStatus, ClickStatus, PlayTimeStatus, DrawStatus;

    [SerializeField] private Slider[] TouchSliders, SecondSliders;
    [SerializeField] private Slider GoldSlider, ClickSlider, PlayTimeSlider, DrawSlider;

    [SerializeField] private Text[] TouchLists, SecondLists;
    [SerializeField] private Text GoldList, ClickList, PlayTimeList, DrawList;

    [SerializeField] private Button TalkBtn;
    [SerializeField] private GameObject QuestNotice;

    [SerializeField] private Image[] TalkBtnImages;
    [SerializeField] private Sprite OnTalkBtnSpr, TalkBtnSpr;

    [SerializeField] private Slider[] CrushSliders;

    [SerializeField] private List<GameObject> QuestList;

    Dictionary<int, string> TouchName = new Dictionary<int, string>();
    Dictionary<int, string> SecondName = new Dictionary<int, string>();

    SaveVariables saveVariables;

    private void Start()
    {
        saveVariables = SaveManager.Instance.saveVariables;
        isTouch = new bool[4];
        isSecond = new bool[4];
        AddDictionary();
    }
    private void Update()
    {
        OrganizeStatusText();
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
    /// <summary>
    /// 리스트 새로고침
    /// </summary>
    /// <param name="Proceed">새로고칠 퀘스트 칸</param>
    /// <param name="RefreshKinds">어떻게 고칠지 종류(활성화, 비활성화)</param>
    public void ListRefresh(GameObject Proceed, bool RefreshKinds)
    {
        if (RefreshKinds)
        {
            QuestList.Remove(Proceed);
            QuestList.Insert(0, Proceed);
            QuestList[0].transform.SetAsFirstSibling();
        }
        else
        {
            QuestList.Remove(Proceed);
            QuestList.Add(Proceed);
            QuestList[QuestList.Count - 1].transform.SetAsLastSibling();
        }
    }


    //void CrushUpdate()
    //{
    //    for (int i = 0; i < saveVariables.LeeTaeyeon.Length; i++)
    //    {
    //        TalkBtnImages[i].sprite = TalkBtnSpr;
    //    }
    //    QuestNotice.SetActive(false);
    //    for (int i = 0; i < saveVariables.LeeTaeyeon.Length; i++)
    //    {
    //        if (saveVariables.LeeTaeyeon[i] && saveVariables.isLeeTaeyeon)
    //        {
    //            QuestNotice.SetActive(true);
    //            TalkBtnImages[0].sprite = OnTalkBtnSpr;
    //        }
    //    }
    //    for (int i = 0; i < saveVariables.JeongSeoYoon.Length; i++)
    //    {
    //        if (saveVariables.JeongSeoYoon[i] && saveVariables.isJeongSeoYoon)
    //        {
    //            QuestNotice.SetActive(true);
    //            TalkBtnImages[1].sprite = OnTalkBtnSpr;
    //        }
    //    }
    //    for (int i = 0; i < saveVariables.LeeYerin.Length; i++)
    //    {
    //        if (saveVariables.LeeYerin[i] && saveVariables.isLeeYerin)
    //        {
    //            QuestNotice.SetActive(true);
    //            TalkBtnImages[2].sprite = OnTalkBtnSpr;
    //        }
    //    }
    //    for (int i = 0; i < saveVariables.SongYeonHa.Length; i++)
    //    {
    //        if (saveVariables.SongYeonHa[i] && saveVariables.isSongYeonHa)
    //        {
    //            QuestNotice.SetActive(true);
    //            TalkBtnImages[3].sprite = OnTalkBtnSpr;
    //        }
    //    }
    //    for (int i = 0; i < saveVariables.SeongJunAh.Length; i++)
    //    {
    //        if (saveVariables.SeongJunAh[i] && saveVariables.isSeongJunAh)
    //        {
    //            QuestNotice.SetActive(true);
    //            TalkBtnImages[4].sprite = OnTalkBtnSpr;
    //        }
    //    }
    //}

    void QuestNoticeUpdate(bool NoticeState)
    {
        if(NoticeState)
        {
            QuestNotice.SetActive(NoticeState);
        }
    }
    void OrganizeStatusText()
    {
        for (int i = 0; i < Touch.Length; i++)
        {
            Touch[i].text = saveVariables.QU_Touch[i].ToString() + "/" + ((10 * saveVariables.QUN_Touch[i]) + 10).ToString();
            TouchLists[i].text = $"'{TouchName[i]}' 레벨을 {(10 * saveVariables.QUN_Touch[i]) + 10}레벨 올리기";
            TouchSliders[i].value = (saveVariables.QU_Touch[i] - 10f * saveVariables.QUN_Touch[i]) / 10;
            QuestNoticeUpdate(saveVariables.QU_Touch[i] >= (10 * saveVariables.QUN_Touch[i]) + 10);
            if (saveVariables.QU_Touch[i] >= ((10 * saveVariables.QUN_Touch[i]) + 10) && !isTouch[i])
            {
                isTouch[i] = true;
                TouchStatus[i].color = new Color(1, 1, 1, 1);
                ListRefresh(TouchCannes[i], isTouch[i]);
            }
        }

        for (int i = 0; i < Second.Length; i++)
        {
            Second[i].text = saveVariables.QU_Second[i].ToString() + "/" + ((10 * saveVariables.QUN_Second[i]) + 10).ToString();
            SecondLists[i].text = $"'{SecondName[i]}' 레벨을 {(10 * saveVariables.QUN_Second[i]) + 10}레벨 올리기";
            SecondSliders[i].value = (saveVariables.QU_Second[i] - 10f * saveVariables.QUN_Second[i]) / 10;
            QuestNoticeUpdate(saveVariables.QU_Second[i] >= (10 * saveVariables.QUN_Second[i]) + 10);
            if (saveVariables.QU_Second[i] >= ((10 * saveVariables.QUN_Second[i]) + 10) && !isSecond[i])
            {
                isSecond[i] = true;
                SecondStatus[i].color = new Color(1, 1, 1, 1);
                ListRefresh(SecondCannes[i], isSecond[i]);
            }
        }

        Gold.text = saveVariables.QU_Gold.ToString() + "/" + (ulong)(1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1));
        GoldList.text = $"골드를 {(ulong)(1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1))}원 획득하기";
        GoldSlider.value = (saveVariables.QU_Gold) / (1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1));
        QuestNoticeUpdate(saveVariables.QU_Gold >= (1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1)));
        if (saveVariables.QU_Gold >= (1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1)) && !isGold)
        {
            isGold = true;
            GoldStatus.color = new Color(1, 1, 1, 1);
            ListRefresh(GoldCannes, isGold);
        }

        Click.text = saveVariables.QU_Click.ToString() + "/" + ((300 * saveVariables.QUN_Click) + 300).ToString();
        ClickList.text = $"터치를 {(300 * saveVariables.QUN_Click) + 300}번 하기";
        ClickSlider.value = (saveVariables.QU_Click - 300f * saveVariables.QUN_Click) / 300; //
        QuestNoticeUpdate(saveVariables.QU_Click >= ((300 * saveVariables.QUN_Click) + 300));
        if (saveVariables.QU_Click >= ((300 * saveVariables.QUN_Click) + 300) && !isClick)
        {
            isClick = true;
            ClickStatus.color = new Color(1, 1, 1, 1);
            ListRefresh(ClickCannes, isClick);
        }

        PlayTime.text = saveVariables.QU_PlayTime.ToString() + "/" + ((100 * saveVariables.QUN_PlayTime) + 100).ToString();
        PlayTimeList.text = $"{(100 * saveVariables.QUN_PlayTime) + 100}초 플레이하기";
        PlayTimeSlider.value = (saveVariables.QU_PlayTime - 100 * saveVariables.QUN_PlayTime) / 100;
        QuestNoticeUpdate(saveVariables.QU_PlayTime >= ((100 * saveVariables.QUN_PlayTime) + 100));
        if (saveVariables.QU_PlayTime >= ((100 * saveVariables.QUN_PlayTime) + 100) && !isPlayTime)
        {
            isPlayTime = true;
            PlayTimeStatus.color = new Color(1, 1, 1, 1);
            ListRefresh(PlayTimeCannes, isPlayTime);
        }

        Draw.text = saveVariables.QU_Draw.ToString() + "/" + ((1 * saveVariables.QUN_Draw) + 1).ToString();
        DrawList.text = $"캐릭터를 {(1 * saveVariables.QUN_Draw) + 1}번 뽑으세요";
        DrawSlider.value = (saveVariables.QU_Draw - 1f * saveVariables.QUN_Draw) / 1;
        QuestNoticeUpdate(saveVariables.QU_Draw >= ((1 * saveVariables.QUN_Draw) + 1));
        if (saveVariables.QU_Draw >= ((1 * saveVariables.QUN_Draw) + 1) && !isDraw)
        {
            isDraw = true;
            DrawStatus.color = new Color(1, 1, 1, 1);
            ListRefresh(DrawCannes, isDraw);
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
                    isTouch[i] = false;
                    QuestNotice.SetActive(false);
                    ListRefresh(TouchCannes[i], isTouch[i]);
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
                    QuestNotice.SetActive(false);
                    isSecond[i] = false;
                    ListRefresh(SecondCannes[i], isSecond[i]);
                    StartCoroutine(QuestReward(10 * (i + 1)));
                    return;
                }
            }

            if (PressObj == GoldStatus)
            {
                GoldStatus.color = new Color(1, 1, 1, 0);
                saveVariables.QU_Gold -= (ulong)(1000 * Mathf.Pow(10, saveVariables.QUN_Gold + 1));
                saveVariables.QUN_Gold++;
                QuestNotice.SetActive(false);
                isGold = false;
                ListRefresh(GoldCannes, isGold);
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == ClickStatus)
            {
                ClickStatus.color = new Color(1, 1, 1, 0);
                saveVariables.QUN_Click++;
                QuestNotice.SetActive(false);
                isClick = false;
                ListRefresh(ClickCannes, isClick);
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == PlayTimeStatus)
            {
                PlayTimeStatus.color = new Color(1, 1, 1, 0);
                saveVariables.QUN_PlayTime++;
                QuestNotice.SetActive(false);
                isPlayTime = false;
                ListRefresh(PlayTimeCannes, isPlayTime);
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == DrawStatus)
            {
                DrawStatus.color = new Color(1, 1, 1, 0);
                saveVariables.QUN_Draw++;
                QuestNotice.SetActive(false);
                isDraw = false;
                ListRefresh(DrawCannes, isDraw);
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
