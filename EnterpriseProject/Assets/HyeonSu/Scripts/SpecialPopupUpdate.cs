using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecialPopupUpdate : MonoBehaviour
{
    [SerializeField] private Slider[] TalkGauges;
    [SerializeField] private Image[] TalkBtnImg;
    [SerializeField] private Button[] WebtoonBtns;
    [SerializeField] private TextMeshProUGUI[] WebtoonBtnTexts;
    [SerializeField] private Sprite TalkBtnImgOn, TalkBtnImgOff;
    [SerializeField] private GameObject[] PriceTexts;
    [SerializeField] private GameObject NotenoughtDiamondPopup;

    [SerializeField] private WebtoonManager webtoonManager;
    SaveVariables SV;

    private void Awake()
    {
        SV = SaveManager.Instance.saveVariables;
        for (int i = 0; i < WebtoonBtns.Length; i++)
        {
            WebtoonBtns[i].onClick.AddListener(BuySpecialPopup);
        }
        gameObject.transform.localScale = new Vector2(0, 0);
    }

    public void OnEnable()
    {
        if (SV == null)
            return;

        gameObject.GetComponent<ScrollRect>().enabled = false;
        StartCoroutine(HandleOn());
        int name = int.Parse(gameObject.name);

        switch (name)
        {
            case 1:
                for (int i = 0; i < TalkGauges.Length; i++)
                {
                    TalkGauges[i].value = SV.CurLeeTaeyeon / ((i + 1) * 20);
                    if (SV.LeeTaeyeon[i])
                    {
                        TalkBtnImg[i].sprite = TalkBtnImgOn;
                        TalkBtnImg[i].gameObject.transform.parent.GetComponent<Button>().enabled = true;
                    }
                    else
                    {
                        TalkBtnImg[i].sprite = TalkBtnImgOff;
                        TalkBtnImg[i].gameObject.transform.parent.GetComponent<Button>().enabled = false;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (SV.LeeTaeyeonWebtoonBuy[i] == true)
                    {
                        PriceTexts[i].SetActive(false);
                        WebtoonBtns[i].transform.GetChild(1).GetComponent<Image>().sprite = TalkBtnImgOn;
                        WebtoonBtnTexts[i].text = "대화하기";
                        WebtoonBtns[i].onClick.RemoveAllListeners();
                        WebtoonBtns[i].onClick.AddListener(() =>
                        {
                            webtoonManager.Webtoons[i].SetActive(true);
                            webtoonManager.gameObject.SetActive(true);
                        });
                        break;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < TalkGauges.Length; i++)
                {
                    TalkGauges[i].value = SV.CurJeongSeoYoon / ((i + 1) * 20);
                    if (SV.JeongSeoYoon[i])
                    {
                        TalkBtnImg[i].sprite = TalkBtnImgOn;
                        TalkBtnImg[i].gameObject.transform.parent.GetComponent<Button>().enabled = true;
                    }
                    else
                    {
                        TalkBtnImg[i].sprite = TalkBtnImgOff;
                        TalkBtnImg[i].gameObject.transform.parent.GetComponent<Button>().enabled = false;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (SV.JeongSeoYoonWebtoonBuy[i])
                    {
                        PriceTexts[i].SetActive(false);
                        WebtoonBtns[i].transform.GetChild(1).GetComponent<Image>().sprite = TalkBtnImgOn;
                        WebtoonBtnTexts[i].text = "대화하기";
                        WebtoonBtns[i].onClick.RemoveAllListeners();
                        WebtoonBtns[i].onClick.AddListener(() =>
                        {
                            webtoonManager.Webtoons[i + 3].SetActive(true);
                            webtoonManager.gameObject.SetActive(true);
                        });
                    }
                }
                break;
            case 3:
                for (int i = 0; i < TalkGauges.Length; i++)
                {
                    TalkGauges[i].value = SV.CurLeeYerin / ((i + 1) * 20);
                    if (SV.LeeYerin[i])
                    {
                        TalkBtnImg[i].sprite = TalkBtnImgOn;
                        TalkBtnImg[i].gameObject.transform.parent.GetComponent<Button>().enabled = true;
                    }
                    else
                    {
                        TalkBtnImg[i].sprite = TalkBtnImgOff;
                        TalkBtnImg[i].gameObject.transform.parent.GetComponent<Button>().enabled = false;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (SV.LeeYerinWebtoonBuy[i])
                    {
                        PriceTexts[i].SetActive(false);
                        WebtoonBtns[i].transform.GetChild(1).GetComponent<Image>().sprite = TalkBtnImgOn;
                        WebtoonBtnTexts[i].text = "대화하기";
                        WebtoonBtns[i].onClick.RemoveAllListeners();
                        WebtoonBtns[i].onClick.AddListener(() =>
                        {
                            webtoonManager.Webtoons[i + 6].SetActive(true);
                            webtoonManager.gameObject.SetActive(true);
                        });
                    }
                }
                break;
            case 4:
                for (int i = 0; i < TalkGauges.Length; i++)
                {
                    TalkGauges[i].value = SV.CurSongYeonHa / ((i + 1) * 20);
                    if (SV.SongYeonHa[i])
                    {
                        TalkBtnImg[i].sprite = TalkBtnImgOn;
                        TalkBtnImg[i].gameObject.transform.parent.GetComponent<Button>().enabled = true;
                    }
                    else
                    {
                        TalkBtnImg[i].sprite = TalkBtnImgOff;
                        TalkBtnImg[i].gameObject.transform.parent.GetComponent<Button>().enabled = false;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (SV.SongYeonHaWebtoonBuy[i])
                    {
                        PriceTexts[i].SetActive(false);
                        WebtoonBtns[i].transform.GetChild(1).GetComponent<Image>().sprite = TalkBtnImgOn;
                        WebtoonBtnTexts[i].text = "대화하기";
                        WebtoonBtns[i].onClick.RemoveAllListeners();
                        WebtoonBtns[i].onClick.AddListener(() =>
                        {
                            webtoonManager.Webtoons[i + 9].SetActive(true);
                            webtoonManager.gameObject.SetActive(true);
                        });
                    }
                }
                break;
        }

    }

    void BuySpecialPopup()
    {
        for (int i = 0; i < WebtoonBtns.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject == WebtoonBtns[i].gameObject)
            {
                if (SV.diamond >= SpecialTalkPrice(i))
                {
                print("a");
                    SV.diamond -= SpecialTalkPrice(i);

                    int name = int.Parse(gameObject.name);
                    switch (name)
                    {
                        case 1:
                            SV.LeeTaeyeonWebtoonBuy[i] = true;
                            break;
                        case 2:
                            SV.JeongSeoYoonWebtoonBuy[i] = true;
                            break;
                        case 3:
                            SV.LeeYerinWebtoonBuy[i] = true;
                            break;
                        case 4:
                            SV.SongYeonHaWebtoonBuy[i] = true;
                            break;
                    }

                    OnEnable();
                }
                else
                    //다이아 부족 팝업
                    NotenoughtDiamondPopup.SetActive(true);
                break;
            }
        }
    }
    int SpecialTalkPrice(int i)
    {
        if (i == 0)
            return 100;
        else if (i == 1)
            return 300;
        else if (i == 2)
            return 500;

        return 0;
    }

    IEnumerator HandleOn()
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<ScrollRect>().enabled = true;
    }
}
