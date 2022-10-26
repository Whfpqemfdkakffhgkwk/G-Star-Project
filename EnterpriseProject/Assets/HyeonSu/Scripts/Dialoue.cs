using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

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
    [SerializeField]private Text TalkTxt;
    [SerializeField] private Text NameTxt;
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
            if(Input.GetMouseButton(0))
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
}