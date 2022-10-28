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
}
[Serializable]
public struct TalkDatas
{
    public List<TalkData> talks;
}
public class Dialoue : MonoBehaviour
{
    [SerializeField] private Text TalkTxt;
    [SerializeField] private Text NameTxt;
    [SerializeField] private Image Background;
    [SerializeField] private Sprite[] BKspr;
    [SerializeField] private Image[] Character;


    [SerializeField] private GameObject GoldDirectingObj;
    private void Start()
    {
        StartCoroutine(StoryStart());

    }
    IEnumerator StoryStart()
    {
        var loadedJson = Resources.Load<TextAsset>("AAA");
        var StoryData = JsonUtility.FromJson<TalkDatas>(loadedJson.ToString());
        for (int i = 0; i < StoryData.talks.Count; i++)
        {
            //각 대화마다 실행해야 할 내용 여기다가
            TalkerChange(StoryData.talks[i].Talker);
            BackgroundChange(StoryData.talks[i].Background);
            NameTxt.text = StoryData.talks[i].Talker;
            yield return StartCoroutine(Typing(TalkTxt, StoryData.talks[i].talk));

            if (i + 1 == StoryData.talks.Count) continue;
            yield return StartCoroutine(Waiting());
        }
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
    void TalkerChange(string talker)
    {
        switch (talker)
        {
            case "캐릭 1":
                Character[0].color = new Color(50 / 255f, 50 / 255f, 50 / 255f, 1);
                Character[0].rectTransform.localScale = new Vector2(0.8f, 0.8f);
                Character[1].color = new Color(1, 1, 1, 1);
                Character[1].rectTransform.localScale = new Vector2(1, 1);
                break;
            case "캐릭 2":
                Character[1].color = new Color(50 / 255f, 50 / 255f, 50 / 255f, 1);
                Character[1].rectTransform.localScale = new Vector2(0.8f, 0.8f);
                Character[0].color = new Color(1, 1, 1, 1);
                Character[0].rectTransform.localScale = new Vector2(1, 1);
                break;
            case "주인공":
                Character[0].color = new Color(50 / 255f, 50 / 255f, 50 / 255f, 1);
                Character[0].rectTransform.localScale = new Vector2(0.8f, 0.8f);
                Character[1].color = new Color(50 / 255f, 50 / 255f, 50 / 255f, 1);
                Character[1].rectTransform.localScale = new Vector2(0.8f, 0.8f);
                break;
        }
    }
    #region 메인씬에서 쓸 연출
    public void DirectingMoney()
    {
        Transform ClickPos = EventSystem.current.currentSelectedGameObject.transform;
        for (int i = 0; i < 50; i++)
        {
            GameObject SummonedObject = Instantiate(GoldDirectingObj, ClickPos);
            Vector2 RandomPos = new Vector2(SummonedObject.transform.position.x + UnityEngine.Random.Range(100f, 400f),
                                            SummonedObject.transform.position.y + UnityEngine.Random.Range(-100f, -400f));
            SummonedObject.transform.DOMove(RandomPos, 1.0f);
            StartCoroutine(DirectingMoneyCor(SummonedObject));
        }
    }
    IEnumerator DirectingMoneyCor(GameObject obj)
    {
        yield return new WaitForSeconds(1.0f);
        obj.transform.DOLocalMove(new Vector2(100, 1400), 0.5f);
    }
    #endregion
}