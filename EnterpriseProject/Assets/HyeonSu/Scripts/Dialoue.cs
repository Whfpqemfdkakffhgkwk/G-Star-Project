using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
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
    [SerializeField] private Text TalkTxt;
    [SerializeField] private Text NameTxt;
    [SerializeField] private Image Background;
    [SerializeField] private Sprite[] BKspr;
    [SerializeField, Tooltip("이태연, 정서윤, 이예린, 송연하, 성준아")] private Sprite[] CharacterSpr;
    [SerializeField] private Sprite[] LeeTaeyeonSpr, JeongSeoYoonSpr, LeeYerinSpr, SongYeonHaSpr, SeongJunAhSpr, HeroSpr;
    [SerializeField] private Image[] Character;
    [SerializeField] private Button EndBtn;
    [SerializeField] private GameObject Butler;
    Dictionary<string, List<TalkData>> TalkDic = new Dictionary<string, List<TalkData>>();

    private void Awake()
    {
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
    IEnumerator Typing(Text text, string str)
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
                    Character[1].sprite = CharacterSpr[0];
                }
                else if (TalkDic[TalkSelect][i].Talker == "정서윤")
                {
                    Character[1].sprite = CharacterSpr[1];
                }
                else if (TalkDic[TalkSelect][i].Talker == "이예린")
                {
                    Character[1].sprite = CharacterSpr[2];
                }
                else if (TalkDic[TalkSelect][i].Talker == "송연하")
                {
                    Character[1].sprite = CharacterSpr[3];
                }
                else if (TalkDic[TalkSelect][i].Talker == "성준아")
                {
                    Character[1].sprite = CharacterSpr[4];
                }
                break;
            }
        }
        if (TalkDic[TalkSelect][0].Talker == "이태연")
        {
            Character[1].sprite = CharacterSpr[0];
        }
        else if (TalkDic[TalkSelect][0].Talker == "정서윤")
        {
            Character[1].sprite = CharacterSpr[1];
        }
        else if (TalkDic[TalkSelect][0].Talker == "이예린")
        {
            Character[1].sprite = CharacterSpr[2];
        }
        else if (TalkDic[TalkSelect][0].Talker == "송연하")
        {
            Character[1].sprite = CharacterSpr[3];
        }
        else if (TalkDic[TalkSelect][0].Talker == "성준아")
        {
            Character[1].sprite = CharacterSpr[4];
        }
    }
    void EmotionChange(string TalkSelect, string Talker, int arr)
    {
        if(Talker == "주인공")
        {
            for (int v = 1; v <= 3; v++)
            {
                if (TalkDic[TalkSelect][arr].Emotion == v)
                {
                    Character[0].sprite = HeroSpr[v - 1];
                }
            }
        }
        else if (Talker == "이태연")
        {
            for (int v = 1; v <= 3; v++)//표정 개수 변동 필요
            {
                if (TalkDic[TalkSelect][arr].Emotion == v)
                {
                    Character[1].sprite = LeeTaeyeonSpr[v - 1];
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
                    Character[1].sprite = JeongSeoYoonSpr[v - 1];
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
                    Character[1].sprite = LeeYerinSpr[v - 1];
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
                    Character[1].sprite = SongYeonHaSpr[v - 1];
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
                    Character[1].sprite = SeongJunAhSpr[v - 1];
                    //캐릭터 표정 바꾸기
                    return;
                }
            }
        }
    }
    void TalkerChange(string talker)
    {
        if (talker == "주인공")
        {
            Character[0].DOColor(new Color(1, 1, 1, 1), 0.5f);
            Character[0].rectTransform.DOScale(new Vector2(1, 1), 0.5f);
            Character[1].DOColor(new Color(180 / 255f, 180 / 255f, 180 / 255f, 0.8f), 0.5f);
            Character[1].rectTransform.DOScale(new Vector2(0.9f, 0.9f), 0.5f);
        }
        else if(talker ==  "이예린 집사")
        {
            Butler.SetActive(true);
            Character[1].gameObject.SetActive(false);
            Character[1].DOColor(new Color(180 / 255f, 180 / 255f, 180 / 255f, 0.8f), 0.5f);
            Character[1].rectTransform.DOScale(new Vector2(0.9f, 0.9f), 0.5f);
            Character[0].DOColor(new Color(180 / 255f, 180 / 255f, 180 / 255f, 0.8f), 0.5f);
            Character[0].rectTransform.DOScale(new Vector2(0.9f, 0.9f), 0.5f);
        }
        else
        {
            Butler.SetActive(false);
            Character[1].gameObject.SetActive(true);
            Character[1].DOColor(new Color(1, 1, 1, 1), 0.5f);
            Character[1].rectTransform.DOScale(new Vector2(1, 1), 0.5f);
            Character[0].DOColor(new Color(180 / 255f, 180 / 255f, 180 / 255f, 0.8f), 0.5f);
            Character[0].rectTransform.DOScale(new Vector2(0.9f, 0.9f), 0.5f);
        }
    }
}