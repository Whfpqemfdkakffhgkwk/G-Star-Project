using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening;

[Serializable]
public struct TalkData
{
    public string Talker;
    public int Background;
    public string talk;
    public int Emotion;
}
[Serializable]
public struct TalkDatas
{
    //깨끗하게 정리할 것.
    public List<TalkData> LeeTaeyeon1;
    public List<TalkData> LeeTaeyeon2;
    public List<TalkData> LeeTaeyeon3;
    public List<TalkData> LeeTaeyeon4;
    public List<TalkData> LeeTaeyeon5;
    public List<TalkData> JeongSeoYoon1;
    public List<TalkData> JeongSeoYoon2;
    public List<TalkData> JeongSeoYoon3;
    public List<TalkData> JeongSeoYoon4;
    public List<TalkData> JeongSeoYoon5;
    public List<TalkData> LeeYerin1;
    public List<TalkData> LeeYerin2;
    public List<TalkData> LeeYerin3;
    public List<TalkData> LeeYerin4;
    public List<TalkData> LeeYerin5;
    public List<TalkData> SongYeonHa1;
    public List<TalkData> SongYeonHa2;
    public List<TalkData> SongYeonHa3;
    public List<TalkData> SongYeonHa4;
    public List<TalkData> SongYeonHa5;
    public List<TalkData> SeongJunAh1;
    public List<TalkData> SeongJunAh2;
    public List<TalkData> SeongJunAh3;
    public List<TalkData> SeongJunAh4;
    public List<TalkData> SeongJunAh5;
}
public class Dialoue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TalkTxt;
    [SerializeField] private Text NameTxt;
    [SerializeField] private Image Background;
    [SerializeField] private Sprite[] BKspr;
    [SerializeField, Tooltip("이태연, 정서윤, 이예린, 송연하, 성준아")] private Sprite[] CharacterSpr;
    [SerializeField] private Sprite[] LeeTaeyeonSpr, JeongSeoYoonSpr, LeeYerinSpr, SongYeonHaSpr, SeongJunAhSpr;
    [SerializeField] private Sprite ButlerSpr;
    [SerializeField] private Image Character;
    [SerializeField] private Button EndBtn;
    private Color LeeTaeyeonColor, JeongSeoYoonColor, LeeYerinColor, SongYeonHaColor, SeongJunAhColor, NormalColor;
    Dictionary<string, List<TalkData>> TalkDic = new Dictionary<string, List<TalkData>>();

    private void Awake()
    {
        ColorUtility.TryParseHtmlString("#ffffff", out NormalColor);
        ColorUtility.TryParseHtmlString("#ec578d", out LeeTaeyeonColor);
        ColorUtility.TryParseHtmlString("#fed59c", out JeongSeoYoonColor);
        ColorUtility.TryParseHtmlString("#ffffff", out LeeYerinColor);
        ColorUtility.TryParseHtmlString("#4f4857", out SongYeonHaColor);
        ColorUtility.TryParseHtmlString("#ffffff", out SeongJunAhColor);
        var loadedJson = Resources.Load<TextAsset>("TalkData");
        var StoryData = JsonUtility.FromJson<TalkDatas>(loadedJson.ToString());
        #region 대화묶음들 가져오기
        TalkDic.Add("LeeTaeyeon1", StoryData.LeeTaeyeon1);
        TalkDic.Add("LeeTaeyeon2", StoryData.LeeTaeyeon2);
        TalkDic.Add("LeeTaeyeon3", StoryData.LeeTaeyeon3);
        TalkDic.Add("LeeTaeyeon4", StoryData.LeeTaeyeon4);
        TalkDic.Add("LeeTaeyeon5", StoryData.LeeTaeyeon5);

        TalkDic.Add("JeongSeoYoon1", StoryData.JeongSeoYoon1);
        TalkDic.Add("JeongSeoYoon2", StoryData.JeongSeoYoon2);
        TalkDic.Add("JeongSeoYoon3", StoryData.JeongSeoYoon3);
        TalkDic.Add("JeongSeoYoon4", StoryData.JeongSeoYoon4);
        TalkDic.Add("JeongSeoYoon5", StoryData.JeongSeoYoon5);

        TalkDic.Add("LeeYerin1", StoryData.LeeYerin1);
        TalkDic.Add("LeeYerin2", StoryData.LeeYerin2);
        TalkDic.Add("LeeYerin3", StoryData.LeeYerin3);
        TalkDic.Add("LeeYerin4", StoryData.LeeYerin4);
        TalkDic.Add("LeeYerin5", StoryData.LeeYerin5);

        TalkDic.Add("SongYeonHa1", StoryData.SongYeonHa1);
        TalkDic.Add("SongYeonHa2", StoryData.SongYeonHa2);
        TalkDic.Add("SongYeonHa3", StoryData.SongYeonHa3);
        TalkDic.Add("SongYeonHa4", StoryData.SongYeonHa4);
        TalkDic.Add("SongYeonHa5", StoryData.SongYeonHa5);

        TalkDic.Add("SeongJunAh1", StoryData.SeongJunAh1);
        TalkDic.Add("SeongJunAh2", StoryData.SeongJunAh2);
        TalkDic.Add("SeongJunAh3", StoryData.SeongJunAh3);
        TalkDic.Add("SeongJunAh4", StoryData.SeongJunAh4);
        TalkDic.Add("SeongJunAh5", StoryData.SeongJunAh5);
        #endregion
        this.gameObject.SetActive(false);
    }
    public IEnumerator StoryStart(string TalkSelect)
    {
        this.gameObject.SetActive(true);
        FirstTalkerChange(TalkSelect);
        for (int i = 0; i < TalkDic[TalkSelect].Count; i++)
        {
            //각 대화마다 실행해야 할 내용 여기다가
            TalkerChange(TalkDic[TalkSelect][i].Talker);
            EmotionChange(TalkSelect, TalkDic[TalkSelect][i].Talker, i);
            BackgroundChange(TalkDic[TalkSelect][i].Background);
            NameTxt.text = TalkDic[TalkSelect][i].Talker;
            yield return StartCoroutine(Typing(TalkTxt, TalkDic[TalkSelect][i].talk));

            if (i + 1 == TalkDic[TalkSelect].Count) continue;
            yield return StartCoroutine(Waiting());
        }
        //창끄기
        yield return new WaitForSeconds(1.5f);
        EndBtn.onClick.Invoke();
        gameObject.SetActive(false);
    }
    IEnumerator Typing(TextMeshProUGUI text, string str)
    {
        var wait = new WaitForSeconds(0.05f);
        yield return wait;
        for (int i = 0; i <= str.Length; i++)
        {
            text.text = str.Substring(0, i);
            if (Input.GetMouseButton(0))
            {
                text.text = str.Substring(0, str.Length);
                break;
            }
            yield return wait;
        }
        yield return null;
    }
    IEnumerator Waiting()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                yield return new WaitForSeconds(0.1f);
                yield break;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
    void BackgroundChange(int num)
    {
        Background.sprite = BKspr[num];
    }
    void FirstTalkerChange(string TalkSelect)
    {
        for (int i = 0; i < 10; i++)
        {
            if (TalkDic[TalkSelect][i].Talker != "주인공")
            {
                TalkerChange(TalkDic[TalkSelect][i].Talker);

                if (TalkDic[TalkSelect][i].Talker == "이태연")
                {
                    Character.sprite = CharacterSpr[0];
                    TalkTxt.colorGradient = new VertexGradient(LeeTaeyeonColor, LeeTaeyeonColor, NormalColor, NormalColor);
                }
                else if (TalkDic[TalkSelect][i].Talker == "정서윤")
                {
                    Character.sprite = CharacterSpr[1];
                    TalkTxt.colorGradient = new VertexGradient(JeongSeoYoonColor, JeongSeoYoonColor, NormalColor, NormalColor);
                }
                else if (TalkDic[TalkSelect][i].Talker == "이예린")
                {
                    Character.sprite = CharacterSpr[2];
                    TalkTxt.colorGradient = new VertexGradient(LeeYerinColor, LeeYerinColor, NormalColor, NormalColor);
                }
                else if (TalkDic[TalkSelect][i].Talker == "송연하")
                {
                    Character.sprite = CharacterSpr[3];
                    TalkTxt.colorGradient = new VertexGradient(SongYeonHaColor, SongYeonHaColor, NormalColor, NormalColor);
                }
                else if (TalkDic[TalkSelect][i].Talker == "성준아")
                {
                    Character.sprite = CharacterSpr[4];
                    TalkTxt.colorGradient = new VertexGradient(SeongJunAhColor, SeongJunAhColor, NormalColor, NormalColor);
                }
                break;
            }
        }
    }
    void EmotionChange(string TalkSelect, string Talker, int arr)
    {
        if (Talker == "이태연")
        {
            for (int v = 1; v <= 3; v++)//표정 개수 변동 필요
            {
                if (TalkDic[TalkSelect][arr].Emotion == v)
                {
                    Character.sprite = LeeTaeyeonSpr[v - 1];
                    //캐릭터 표정 바꾸기
                    return;
                }
            }
        }
        else if (Talker == "정서윤")
        {
            for (int v = 1; v <= 3; v++)//표정 개수 변동 필요
            {
                if (TalkDic[TalkSelect][arr].Emotion == v)
                {
                    Character.sprite = JeongSeoYoonSpr[v - 1];
                    //캐릭터 표정 바꾸기
                    return;
                }

            }
        }
        else if (Talker == "이예린")
        {
            for (int v = 1; v <= 2; v++)//표정 개수 변동 필요
            {
                if (TalkDic[TalkSelect][arr].Emotion == v)
                {
                    Character.sprite = LeeYerinSpr[v - 1];
                    //캐릭터 표정 바꾸기
                    return;
                }
            }
        }
        else if (Talker == "송연하")
        {
            for (int v = 1; v <= 2; v++)//표정 개수 변동 필요
            {
                if (TalkDic[TalkSelect][arr].Emotion == v)
                {
                    Character.sprite = SongYeonHaSpr[v - 1];
                    //캐릭터 표정 바꾸기
                    return;
                }
            }

        }
        else if (Talker == "성준아")
        {
            for (int v = 1; v <= 4; v++)//표정 개수 변동 필요
            {
                if (TalkDic[TalkSelect][arr].Emotion == v)
                {
                    Character.sprite = SeongJunAhSpr[v - 1];
                    //캐릭터 표정 바꾸기
                    return;
                }
            }
        }
        else if(Talker == "이예린 집사")
        {
            Character.sprite = ButlerSpr;
        }
    }
    /// <summary>
    /// 이 함수 안에 주인공이 대화 중일 경우 연출 넣어야함
    /// </summary>
    /// <param name="talker"></param>
    void TalkerChange(string talker)
    {
        if (talker == "주인공")
        {
            Character.rectTransform.DOScale(new Vector2(0.1f, 0.1f), 0.5f);
            Character.rectTransform.DOScale(new Vector2(1, 1), 0.5f);
        }
        else
        {
            Character.rectTransform.DOScale(new Vector2(0.1f, 0.1f), 0.5f);
            Character.rectTransform.DOScale(new Vector2(1, 1), 0.5f);
        }
    }
}