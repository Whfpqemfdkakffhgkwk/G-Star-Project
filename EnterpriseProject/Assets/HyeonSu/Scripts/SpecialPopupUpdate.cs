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
    [SerializeField] private Button WebtoonBtn;
    [SerializeField] private TextMeshProUGUI WebtoonBtnTexts;
    [SerializeField] private Sprite TalkBtnImgOn, TalkBtnImgOff;
    [SerializeField] private GameObject PriceTexts;
    [SerializeField] private GameObject NotenoughtDiamondPopup;

    [SerializeField] private WebtoonManager webtoonManager;
    SaveVariables SV;

    private void Awake()
    {
        SV = SaveManager.Instance.saveVariables;
        WebtoonBtn.onClick.AddListener(BuySpecialPopup);
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
                if (SV.LeeTaeyeonWebtoonBuy == true)
                {
                    PriceTexts.SetActive(false);
                    WebtoonBtn.transform.GetChild(1).GetComponent<Image>().sprite = TalkBtnImgOn;
                    WebtoonBtnTexts.text = "대화하기";
                    WebtoonBtn.onClick.RemoveAllListeners();
                    WebtoonBtn.onClick.AddListener(() =>
                    {
                        webtoonManager.Webtoons[0].SetActive(true);
                        webtoonManager.gameObject.SetActive(true);
                    });
                    break;
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

                if (SV.JeongSeoYoonWebtoonBuy)
                {
                    PriceTexts.SetActive(false);
                    WebtoonBtn.transform.GetChild(1).GetComponent<Image>().sprite = TalkBtnImgOn;
                    WebtoonBtnTexts.text = "대화하기";
                    WebtoonBtn.onClick.RemoveAllListeners();
                    WebtoonBtn.onClick.AddListener(() =>
                    {
                        webtoonManager.Webtoons[1].SetActive(true);
                        webtoonManager.gameObject.SetActive(true);
                    });
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

                if (SV.LeeYerinWebtoonBuy)
                {
                    PriceTexts.SetActive(false);
                    WebtoonBtn.transform.GetChild(1).GetComponent<Image>().sprite = TalkBtnImgOn;
                    WebtoonBtnTexts.text = "대화하기";
                    WebtoonBtn.onClick.RemoveAllListeners();
                    WebtoonBtn.onClick.AddListener(() =>
                    {
                        webtoonManager.Webtoons[2].SetActive(true);
                        webtoonManager.gameObject.SetActive(true);
                    });
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

                if (SV.SongYeonHaWebtoonBuy)
                {
                    PriceTexts.SetActive(false);
                    WebtoonBtn.transform.GetChild(1).GetComponent<Image>().sprite = TalkBtnImgOn;
                    WebtoonBtnTexts.text = "대화하기";
                    WebtoonBtn.onClick.RemoveAllListeners();
                    WebtoonBtn.onClick.AddListener(() =>
                    {
                        webtoonManager.Webtoons[3].SetActive(true);
                        webtoonManager.gameObject.SetActive(true);
                    });

                }
                break;
        }

    }

    void BuySpecialPopup()
    {
        if (SV.diamond >= 1000)
        {
            SV.diamond -= 1000;

            int name = int.Parse(gameObject.name);
            switch (name)
            {
                case 1:
                    SV.LeeTaeyeonWebtoonBuy = true;
                    break;
                case 2:
                    SV.JeongSeoYoonWebtoonBuy = true;
                    break;
                case 3:
                    SV.LeeYerinWebtoonBuy = true;
                    break;
                case 4:
                    SV.SongYeonHaWebtoonBuy = true;
                    break;
            }

            OnEnable();
        }
        else
            //다이아 부족 팝업
            NotenoughtDiamondPopup.SetActive(true);

    }

    IEnumerator HandleOn()
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<ScrollRect>().enabled = true;
    }
}
