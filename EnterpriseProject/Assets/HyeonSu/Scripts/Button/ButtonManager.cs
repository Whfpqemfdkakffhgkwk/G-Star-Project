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
    [SerializeField] private ScrollRect QuestScroll;
    [SerializeField] private GameObject[] TalkPopup;
    [SerializeField] private GameObject[] TouchBtns, SecondBtns, SpecialBtns;

    private bool isPopup = false;

    private string BtnChar;

    [SerializeField] private Image[] TalkerImages, TalkBtnImages;
    [SerializeField] private Sprite[] TalkerSprs;
    [SerializeField] private Sprite TalkBtnImgOn;

    [SerializeField] private GameObject DiamondDirectingObj, GoldDirectingObj, ParticleObj;
    [SerializeField] private GameObject ItemWindow, SettingWindow;
    [SerializeField] private Text UseItemExplan, GoldItemCountTxt, FeverItemCountTxt;
    [SerializeField] private Button UseItemBtn, ManyMoneyBtn, FeverBtn;

    [SerializeField] private GameObject canvas, DiamondCanvas, content;

    [SerializeField] private QuestManager questManager;
    [SerializeField] private TextManager textManager;

    [SerializeField] private Dialoue dialoue;

    [SerializeField] private GameObject QuitWindow;

    [SerializeField] private Character LeeTaecharacter, Jeongcharater, LeeYaecharater, Songcharater;

    SaveVariables saveVariables;

    private float RemainingItemTime;
    private void Start()
    {
        saveVariables = SaveManager.Instance.saveVariables;
        QuestClose();
        StartCoroutine(MainSecond());
    }

    private void FixedUpdate()
    {
        RemainingItemTime -= Time.deltaTime;
        ItemCountUpdate();
        TalkerOpen();
        QuitCheck();
        ItemOpenCheck();
    }
    public void MainClick()
    {
        SoundManager.Instance.PlaySoundClip("SFX_MainClick", SoundType.SFX);
        DirectingGold(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        StartCoroutine(GoldDelay());
        GameObject particle = Instantiate(ParticleObj, content.transform);
        particle.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        particle.transform.position = new Vector3(particle.transform.position.x, particle.transform.position.y, 0);
        Destroy(particle, 0.8f);
    }
    void QuitCheck()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                QuitWindow.transform.localScale = new Vector2(0, 0);
                QuitWindow.SetActive(true);
                QuitWindow.transform.DOScale(new Vector2(1, 1), 0.5f);
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
        saveVariables.QU_Gold += (ulong)saveVariables.AllSecondMoney;
        yield return new WaitForSeconds(1);
        saveVariables.QU_PlayTime++;
        StartCoroutine(MainSecond());
    }
    /*public void UpgradePressBtns()
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
    }*/

    public void UpgradePressBtns()
    {
        StartCoroutine("UpgradeProgress");
    }

    public void UpgradeReleaseBtns()
    {
        StopCoroutine("UpgradeProgress");
    }

    IEnumerator UpgradeProgress()
    {
        while (true)
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
            yield return new WaitForSeconds(0.1f);
        }
    }

    void UpgradeBtn(GoodsList[] list, int arr)
    {
        if (saveVariables.gold >= (ulong)list[arr].UpgradeCost)
        {
            SoundManager.Instance.PlaySoundClip("SFX_UpgradeSound", SoundType.SFX);
            //퀘스트 업그레이드
            if (list == saveVariables.TouchType)
            {
                saveVariables.QU_Touch[arr]++;
                saveVariables.QU_TouchHeart[arr]++;
                //강화 비용 깎기
                saveVariables.gold -= (ulong)list[arr].UpgradeCost;
                //강화 수치(n강)
                list[arr].UpgradeStep++;
                //터치당 돈 업글
                saveVariables.AllTouchMonmey += 4;
                //강화 비용 올리기
                list[arr].UpgradeCost = saveVariables.AllTouchMonmey * ((20f + ((arr * 10f)) + (list[arr].UpgradeStep % 2f)));
            }
            else if (list == saveVariables.SecondType)
            {
                saveVariables.QU_Second[arr]++;
                saveVariables.gold -= (ulong)list[arr].UpgradeCost;
                //강화 수치(n강)
                list[arr].UpgradeStep++;
                //초당 돈 업글
                saveVariables.AllTouchMonmey += 10;

                //강화 비용 늘리기
                list[arr].UpgradeCost += saveVariables.AllSecondMoney * (30f + ((arr * 10f) + (list[arr].UpgradeStep / 2f)));

            }
        }
    }
    void ItemCountUpdate()
    {

        GoldItemCountTxt.text = $"{saveVariables.ManyMoney}개 보유중";
        if (saveVariables.ItemMultiply == 1)
        {
            FeverItemCountTxt.text = $"{saveVariables.Fever}개 보유중";
        }
        else
        {
            FeverItemCountTxt.text = $"{System.Math.Truncate(RemainingItemTime)} / 300";
        }
    }
    public void UseItemClose()
    {
        ItemWindow.SetActive(false);
        ItemWindow.transform.GetChild(0).transform.localScale = new Vector2(0, 0);
    }
    public void UseItemOpen()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "ManyMoney")
        {
            //아이템을 사용하시겠습니까?
            UseItemExplan.text = $"터치 수당의 1500배\n{saveVariables.AllTouchMonmey * 1500}를 획득합니다";
            UseItemBtn.onClick.RemoveAllListeners();
            UseItemBtn.onClick.AddListener(UseItem_ManyMoney);
            UseItemBtn.onClick.AddListener(UseItemClose);
        }
        else
        {
            UseItemExplan.text = "3분동안 터치 수당이\n50배 증가합니다";
            UseItemBtn.onClick.RemoveAllListeners();
            UseItemBtn.onClick.AddListener(UseItem_Fever);
            UseItemBtn.onClick.AddListener(UseItemClose);
        }
        ItemWindow.SetActive(true);
        ItemWindow.transform.SetAsLastSibling();
        ItemWindow.transform.GetChild(0).transform.DOScale(new Vector2(1, 1), 0.5f);
    }

    void UseItem_ManyMoney()
    {
        saveVariables.gold += saveVariables.AllTouchMonmey * 1500;
        saveVariables.QU_Gold += (ulong)saveVariables.AllTouchMonmey * 1500;
        saveVariables.ManyMoney--;
    }
    void UseItem_Fever()
    {
        saveVariables.ItemMultiply = 50;
        saveVariables.Fever--;
        StartCoroutine(FeverEnd());
    }
    IEnumerator FeverEnd()
    {
        RemainingItemTime = 300;
        yield return new WaitForSeconds(300);
        saveVariables.ItemMultiply = 1;
    }
    public void SettingOpen()
    {
        SettingWindow.SetActive(true);
        SettingWindow.transform.SetAsLastSibling();
        SettingWindow.transform.GetChild(0).DOScale(new Vector3(1, 1), 0.5f);
    }
    public void SettingClose()
    {
        SettingWindow.SetActive(false);
        SettingWindow.transform.GetChild(0).localScale = new Vector2(0, 0);
    }

    public void QuestOpen()
    {
        QuestScroll.enabled = false;
        StartCoroutine(HandleOn());
        QuestWindow.SetActive(true);
        QuestWindow.transform.SetAsLastSibling();
        QuestWindow.transform.GetChild(0).DOScale(new Vector2(1, 1), 0.5f);

        IEnumerator HandleOn()
        {
            yield return new WaitForSeconds(0.01f);
            QuestScroll.enabled = true;
        }
    }
    public void QuestClose()
    {
        QuestWindow.SetActive(false);

        QuestWindow.transform.GetChild(0).localScale = new Vector2(0, 0);
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
        for (int i = 0; i < 25; i++)
        {
            GameObject SummonedObject = ObjPool.GetObject(EPoolType.dia, cur.position);
            #region 기본 세팅
            SummonedObject.transform.SetParent(DiamondCanvas.transform);
            SummonedObject.transform.position = cur.position;
            SummonedObject.transform.localScale = new Vector3(1, 1, 1);
            #endregion
            Vector2 RandomPos = new Vector2(SummonedObject.transform.localPosition.x + Random.Range(-200f, 200f),
                                            SummonedObject.transform.localPosition.y + Random.Range(-100f, -400f));
            SummonedObject.transform.DOLocalMove(RandomPos, 1.0f);
            StartCoroutine(DirectingDiamondCor(SummonedObject));
        }
    }
    void DirectingGold(Vector3 cur)
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject SummonedObject = ObjPool.GetObject(EPoolType.gold, canvas.transform.position);
            #region 기본 세팅
            SummonedObject.transform.SetParent(content.transform);
            SummonedObject.transform.localScale = new Vector3(1, 1, 1);
            SummonedObject.transform.position = cur;
            #endregion
            Vector2 RandomPos = new Vector2(SummonedObject.transform.localPosition.x + Random.Range(-200f, 200f),
                                            SummonedObject.transform.localPosition.y + Random.Range(-100f, -400f));
            SummonedObject.transform.DOLocalMove(RandomPos, 0.7f);
            StartCoroutine(DirectingGoldCor(SummonedObject));
        }
    }
    public void StartDialog()
    {
        StartCoroutine(dialoue.StoryStart($"{BtnChar}{EventSystem.current.currentSelectedGameObject.name}"));
    }
    int TalkPopupArr(GameObject CurrentObj)
    {
        return int.Parse(CurrentObj.name) - 1;
    }
    public void TalkOff()
    {
        TalkPopup[TalkPopupArr(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject)].SetActive(false);
        TalkPopup[TalkPopupArr(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject)].transform.GetChild(0).localScale = new Vector2(0, 0);
        isPopup = false;
    }
    public void TalkClick()
    {
        if (!isPopup)
        {
            isPopup = true;
            BtnChar = EventSystem.current.currentSelectedGameObject.name;
            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "LeeTaeyeon":
                    TalkPopup[0].SetActive(true);
                    TalkPopup[0].transform.SetAsLastSibling();
                    TalkPopup[0].transform.GetChild(0).DOScale(new Vector2(1, 1), 0.5f);
                    break;
                case "JeongSeoYoon":
                    TalkPopup[1].SetActive(true);
                    TalkPopup[1].transform.SetAsLastSibling();
                    TalkPopup[1].transform.GetChild(0).DOScale(new Vector2(1, 1), 0.5f);
                    break;
                case "LeeYerin":
                    TalkPopup[2].SetActive(true);
                    TalkPopup[2].transform.SetAsLastSibling();
                    TalkPopup[2].transform.GetChild(0).DOScale(new Vector2(1, 1), 0.5f);
                    break;
                case "SongYeonHa":
                    TalkPopup[3].SetActive(true);
                    TalkPopup[3].transform.SetAsLastSibling();
                    TalkPopup[3].transform.GetChild(0).DOScale(new Vector2(1, 1), 0.5f);
                    break;
            }
        }
    }
    void ItemOpenCheck()
    {
        if (saveVariables.ManyMoney > 0)
        {
            ManyMoneyBtn.enabled = true;
            ManyMoneyBtn.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            ManyMoneyBtn.enabled = false;
            ManyMoneyBtn.GetComponent<Image>().color = new Color(70 / 255f, 70 / 255f, 70 / 255f, 1);
        }
        if (saveVariables.Fever > 0)
        {
            FeverBtn.enabled = true;
            FeverBtn.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            FeverBtn.enabled = false;
            FeverBtn.GetComponent<Image>().color = new Color(70 / 255f, 70 / 255f, 70 / 255f, 1);
        }
    }
    void TalkerOpen()
    {
        bool[] OpenCheck = new bool[3] { saveVariables.isJeongSeoYoon, saveVariables.isLeeYerin, saveVariables.isSongYeonHa };
        for (int i = 0; i < OpenCheck.Length; i++)
        {
            if (OpenCheck[i])
            {
                TalkerImages[i].sprite = TalkerSprs[i];
                TalkBtnImages[i].sprite = TalkBtnImgOn;
                TalkBtnImages[i].GetComponent<Button>().enabled = true;
            }
        }
    }

    public void TestGold()
    {
        saveVariables.gold += 100000;
    }
    public void TestDia()
    {
        saveVariables.diamond += 1000;
    }

    IEnumerator DirectingDiamondCor(GameObject obj)
    {
        yield return new WaitForSeconds(1.0f);
        obj.transform.DOLocalMove(new Vector2(264, 1347), 0.5f);
        yield return new WaitForSeconds(0.5f);
        ObjPool.ReturnObject(EPoolType.dia, obj);
    }
    IEnumerator DirectingGoldCor(GameObject obj)
    {
        yield return new WaitForSeconds(0.7f);
        obj.transform.DOMove(Camera.main.ScreenToWorldPoint(new Vector2(477.2f, 2796)), 0.5f);
        yield return new WaitForSeconds(0.5f);
        ObjPool.ReturnObject(EPoolType.gold, obj);
    }
    IEnumerator GoldDelay()
    {
        yield return new WaitForSeconds(1.1f);
        StartCoroutine(Count(saveVariables.gold + saveVariables.AllTouchMonmey, saveVariables.gold));
        saveVariables.gold += saveVariables.AllTouchMonmey;
        saveVariables.QU_Gold += (ulong)saveVariables.AllTouchMonmey;
        saveVariables.QU_Click++;

        IEnumerator Count(double target, double current)

        {

            float duration = 0.2f; // 카운팅에 걸리는 시간 설정. 
            double offset = (target - current) / duration;

            while (current < target)
            {
                current += offset * Time.deltaTime;
                textManager.GoldText.text = ((int)current).ToString();// string.Format("{0:####억 ####만 ####원}", (int)current).ToString();
                yield return null;

            }
            current = target;
            textManager.GoldText.text = ((int)current).ToString(); // string.Format("{0:####억 ####만 ####원}", (int)current).ToString();

        }
    }
}
