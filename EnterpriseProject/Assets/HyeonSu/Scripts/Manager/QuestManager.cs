using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    [SerializeField] private GameObject Notice;

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
        TalkQuest();
        OrganizeStatusText();
    }
    void AddDictionary()
    {
        TouchName.Add(0, "�뷡��");
        TouchName.Add(1, "������");
        TouchName.Add(2, "�ｺ��");
        TouchName.Add(3, "�ǽù�");
        SecondName.Add(0, "��ž��");
        SecondName.Add(1, "���Ĵٵ��");
        SecondName.Add(2, "��������");
        SecondName.Add(3, "����Ʈ��");
    }
    void OrganizeStatusText()
    {
        for (int i = 0; i < Touch.Length; i++)
        {
            Touch[i].text = saveVariables.QU_Touch[i].ToString() + "/" + ((10 * saveVariables.QUN_Touch[i]) + 10).ToString();
            TouchLists[i].text = $"'{TouchName[i]}' ������ {(10 * saveVariables.QUN_Touch[i]) + 10}���� �ø���";
            TouchSliders[i].value = (saveVariables.QU_Touch[i] - 10f * saveVariables.QUN_Touch[i]) / 10;
            if (saveVariables.QU_Touch[i] >= ((10 * saveVariables.QUN_Touch[i]) + 10))
                TouchStatus[i].color = new Color(1, 1, 1, 1);
        }

        for (int i = 0; i < Second.Length; i++)
        {
            Second[i].text = saveVariables.QU_Second[i].ToString() + "/" + ((10 * saveVariables.QUN_Second[i]) + 10).ToString();
            SecondLists[i].text = $"'{SecondName[i]}' ������ {(10 * saveVariables.QUN_Second[i]) + 10}���� �ø���";
            SecondSliders[i].value = (saveVariables.QU_Second[i] - 10f * saveVariables.QUN_Second[i]) / 10;
            if (saveVariables.QU_Second[i] >= ((10 * saveVariables.QUN_Second[i]) + 10))
                SecondStatus[i].color = new Color(1, 1, 1, 1);
        }

        Gold.text = saveVariables.QU_Gold.ToString() + "/" + ((5000 * saveVariables.QUN_Gold) + 5000).ToString();
        GoldList.text = $"��带 {((5000 * saveVariables.QUN_Gold) + 5000)}�� ȹ���ϱ�";
        GoldSlider.value = (saveVariables.QU_Gold - 5000f * saveVariables.QUN_Gold) / 5000;
        if (saveVariables.QU_Gold >= ((5000 * saveVariables.QUN_Gold) + 5000))
            GoldStatus.color = new Color(1, 1, 1, 1);

        Click.text = saveVariables.QU_Click.ToString() + "/" + ((300 * saveVariables.QUN_Click) + 300).ToString();
        ClickList.text = $"��ġ�� {(300 * saveVariables.QUN_Click) + 300}�� �ϱ�";
        ClickSlider.value = (saveVariables.QU_Click - 300 * saveVariables.QU_Click) / 300;
        if (saveVariables.QU_Click >= ((300 * saveVariables.QUN_Click) + 300))
            ClickStatus.color = new Color(1, 1, 1, 1);

        PlayTime.text = saveVariables.QU_PlayTime.ToString() + "/" + ((100 * saveVariables.QUN_PlayTime) + 100).ToString();
        PlayTimeList.text = $"{(100 * saveVariables.QUN_PlayTime) + 100}�� �÷����ϱ�";
        PlayTimeSlider.value = (saveVariables.QU_PlayTime - 100 * saveVariables.QUN_PlayTime) / 100;
        if (saveVariables.QU_PlayTime >= ((100 * saveVariables.QUN_PlayTime) + 100))
            PlayTimeStatus.color = new Color(1, 1, 1, 1);

        Draw.text = saveVariables.QU_Draw.ToString() + "/" + ((1 * saveVariables.QUN_Draw) + 1).ToString();
        DrawList.text = $"ĳ���͸� {(1 * saveVariables.QUN_Draw) + 1}�� ��������";
        DrawSlider.value = (saveVariables.QU_Draw - 1f * saveVariables.QUN_Draw) / 1;
        if (saveVariables.QU_Draw >= ((1 * saveVariables.QUN_Draw) + 1))
            DrawStatus.color = new Color(1, 1, 1, 1);
    }
    void TalkQuest()
    {
        if(saveVariables.LeeTaeyeonStep == saveVariables.QUN_Touch[0])
        {
            TalkBtn.interactable = true;
            saveVariables.LeeTaeyeon[saveVariables.LeeTaeyeonStep - 1] = true;
            
            Notice.SetActive(true);
        }
        else if(saveVariables.JeongSeoYoonStep == saveVariables.QUN_Touch[1])
        {
            TalkBtn.interactable = true;
            saveVariables.JeongSeoYoon[saveVariables.JeongSeoYoonStep - 1] = true;
            Notice.SetActive(true);
        }
        else if(saveVariables.LeeYerinStep == saveVariables.QUN_Touch[2])
        {
            TalkBtn.interactable = true;
            saveVariables.LeeYerin[saveVariables.LeeYerinStep - 1] = true;
            Notice.SetActive(true);
        }
        else if (saveVariables.SongYeonHaStep == saveVariables.QUN_Touch[3])
        {
            TalkBtn.interactable = true;
            saveVariables.SongYeonHa[saveVariables.SongYeonHaStep - 1] = true;
            Notice.SetActive(true);
        }
        else if (saveVariables.SeongJunAhStep == saveVariables.QUN_Second[0])
        {
            TalkBtn.interactable = true;
            saveVariables.SeongJunAh[saveVariables.SeongJunAhStep - 1] = true;
            Notice.SetActive(true);
        }
        else
        {
            TalkBtn.interactable = false;
            Notice.SetActive(false);
        }
    }
    public void ButtonState(Image PressObj)//<- ���� ������Ʈ
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
        //if ���� ������Ʈ�� ���� 1,1,1,1�̸�
        //���� ������Ʈ ã��
        //�� 50/255�� �ٲٰ�
        //ī��Ʈ 1�߰��Ѵ�
    }
    IEnumerator QuestReward(int GetDia)
    {
        yield return new WaitForSeconds(1.4f);
        saveVariables.diamond += GetDia;
    }
}
