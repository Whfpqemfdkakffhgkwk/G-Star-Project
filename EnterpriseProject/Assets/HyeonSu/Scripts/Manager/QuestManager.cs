using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    [SerializeField] private Text[] Touch, Second;
    [SerializeField] private Text Gold, Click, PlayTime, Draw;

    [SerializeField] private Image[] TouchBtns, SecondBtns;
    [SerializeField] private Image GoldBtn, ClickBtn, PlayTimeBtn, DrawBtn;

    [SerializeField] private Slider[] TouchSliders, SecondSliders;
    [SerializeField] private Slider GoldSlider, ClickSlider, PlayTimeSlider, DrawSlider;

    Dictionary<int, string> TouchName = new Dictionary<int, string>();
    Dictionary<int, string> SecondName = new Dictionary<int, string>();

    SaveVariables saveVariables;

    private void Start()
    {
        AddDictionary();
        saveVariables = SaveManager.Instance.saveVariables;
    }
    private void Update()
    {
        OrganizeStatusText();
    }
    void AddDictionary()
    {
        TouchName.Add(0, "피시방");
        TouchName.Add(1, "노래방");
        TouchName.Add(2, "헬스장");
        TouchName.Add(3, "도서실");
        SecondName.Add(0, "옥탑방");
        SecondName.Add(1, "스탠다드룸");
        SecondName.Add(2, "딜럭스룸");
        SecondName.Add(3, "스위트룸");
    }
    void OrganizeStatusText()
    {
        for (int i = 0; i < Touch.Length; i++)
        {
            Touch[i].text = saveVariables.QU_Touch[i].ToString() + "/" + ((10 * saveVariables.QUN_Touch[i]) + 10).ToString();
            TouchSliders[i].value = (saveVariables.QU_Touch[i] - 10f * saveVariables.QUN_Touch[i]) / 10;
            if (saveVariables.QU_Touch[i] >= ((10 * saveVariables.QUN_Touch[i]) + 10))
                TouchBtns[i].color = new Color(1, 1, 1, 1);
        }
        for (int i = 0; i < Second.Length; i++)
        {
            Second[i].text = saveVariables.QU_Second[i].ToString() + "/" + ((10 * saveVariables.QUN_Second[i]) + 10).ToString();
            SecondSliders[i].value = (saveVariables.QU_Second[i] - 10f * saveVariables.QUN_Second[i]) / 10;
            if (saveVariables.QU_Second[i] >= ((10 * saveVariables.QUN_Second[i]) + 10))
                SecondBtns[i].color = new Color(1, 1, 1, 1);
        }
        Gold.text = saveVariables.QU_Gold.ToString() + "/" + ((5000 * saveVariables.QUN_Gold) + 5000).ToString();
        GoldSlider.value = (saveVariables.QU_Gold - 5000f * saveVariables.QUN_Gold) / 5000;
        if (saveVariables.QU_Gold >= ((5000 * saveVariables.QUN_Gold) + 5000))
            GoldBtn.color = new Color(1, 1, 1, 1);
        Click.text = saveVariables.QU_Click.ToString() + "/" + ((300 * saveVariables.QUN_Click) + 300).ToString();
        ClickSlider.value = (saveVariables.QU_Click - 300 * saveVariables.QU_Click) / 300;
        if (saveVariables.QU_Click >= ((300 * saveVariables.QUN_Click) + 300))
            ClickBtn.color = new Color(1, 1, 1, 1);
        PlayTime.text = saveVariables.QU_PlayTime.ToString() + "/" + ((100 * saveVariables.QUN_PlayTime) + 100).ToString();
        PlayTimeSlider.value = (saveVariables.QU_PlayTime - 100 * saveVariables.QUN_PlayTime) / 100;
        if (saveVariables.QU_PlayTime >= ((100 * saveVariables.QUN_PlayTime) + 100))
            PlayTimeBtn.color = new Color(1, 1, 1, 1);
        Draw.text = saveVariables.QU_Draw.ToString() + "/" + ((1 * saveVariables.QUN_Draw) + 1).ToString();
        DrawSlider.value = (saveVariables.QU_Draw - 1f * saveVariables.QUN_Draw) / 1;
        if (saveVariables.QU_Draw >= ((1 * saveVariables.QUN_Draw) + 1))
            DrawBtn.color = new Color(1, 1, 1, 1);
    }
    public void ButtonState(Image PressObj)//<- 누른 오브젝트
    {
        if (PressObj.color == new Color(1, 1, 1, 1))
        {
            for (int i = 0; i < Touch.Length; i++)
            {
                if (PressObj == TouchBtns[i])
                {
                    TouchBtns[i].color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                    saveVariables.QUN_Touch[i]++;
                    StartCoroutine(QuestReward(10 *(i + 1)));
                    return;
                }
            }
            for (int i = 0; i < Second.Length; i++)
            {
                if (PressObj == SecondBtns[i])
                {
                    SecondBtns[i].color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                    saveVariables.QUN_Second[i]++;
                    StartCoroutine(QuestReward(10 * (i + 1)));
                    return;
                }
            }

            if (PressObj == GoldBtn)
            {
                GoldBtn.color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                saveVariables.QUN_Gold++;
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == ClickBtn)
            {
                ClickBtn.color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                saveVariables.QUN_Click++;
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == PlayTimeBtn)
            {
                PlayTimeBtn.color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                saveVariables.QUN_PlayTime++;
                StartCoroutine(QuestReward(10));
            }
            else if (PressObj == DrawBtn)
            {
                DrawBtn.color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
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
