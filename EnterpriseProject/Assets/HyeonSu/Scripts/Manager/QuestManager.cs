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

    [Header("Save")]
    [SerializeField] private SaveVariables saveVariables;

    private void Update()
    {
        OrganizeStatusText();
    }
    void OrganizeStatusText()
    {
        //��ġ, �ʴ� ���׷��̵�� �̸� ������ ��ųʸ��� �ٲ㼭 �̸� �ٲ� ��
        for (int i = 0; i < Touch.Length; i++)
        {
            Touch[i].text = $"��ġ ���׷��̵� - {i + 1} : " + saveVariables.QU_Touch[i].ToString() + " / " + ((10 * saveVariables.QUN_Touch[i]) + 10).ToString();
            if (saveVariables.QU_Touch[i] >= ((10 * saveVariables.QUN_Touch[i]) + 10))
                TouchBtns[i].color = new Color(1, 1, 1, 1);
        }
        for (int i = 0; i < Second.Length; i++)
        {
            Second[i].text = $"�ʴ� ���׷��̵� - {i + 1} : " + saveVariables.QU_Second[i].ToString() + " / " + ((10 * saveVariables.QUN_Second[i]) + 10).ToString();
            if (saveVariables.QU_Second[i] >= ((10 * saveVariables.QUN_Second[i]) + 10))
                SecondBtns[i].color = new Color(1, 1, 1, 1);
        }
        Gold.text = "ȹ�� ��� : " + saveVariables.QU_Gold.ToString() + " / " + ((5000 * saveVariables.QUN_Gold) + 5000).ToString();
        if (saveVariables.QU_Gold >= ((5000 * saveVariables.QUN_Gold) + 5000))
            GoldBtn.color = new Color(1, 1, 1, 1);
        Click.text = "Ŭ�� Ƚ�� : " + saveVariables.QU_Click.ToString() + " / " + ((300 * saveVariables.QUN_Click) + 300).ToString();
        if (saveVariables.QU_Click >= ((300 * saveVariables.QUN_Click) + 300))
            ClickBtn.color = new Color(1, 1, 1, 1);
        PlayTime.text = "�÷��� Ÿ�� : " + saveVariables.QU_PlayTime.ToString() + " / " + ((100 * saveVariables.QUN_PlayTime) + 100).ToString();
        if (saveVariables.QU_PlayTime >= ((100 * saveVariables.QUN_PlayTime) + 100))
            PlayTimeBtn.color = new Color(1, 1, 1, 1);
        Draw.text = "ĳ���� ���� Ƚ�� : " + saveVariables.QU_Draw.ToString() + " / " + ((1 * saveVariables.QUN_Draw) + 1).ToString();
        if (saveVariables.QU_Draw >= ((1 * saveVariables.QUN_Draw) + 1))
            DrawBtn.color = new Color(1, 1, 1, 1);
    }
    public void ButtonState(Image PressObj)//<- ���� ������Ʈ
    {
        if (PressObj.color == new Color(1, 1, 1, 1))
        {
            for (int i = 0; i < Touch.Length; i++)
            {
                if (PressObj == TouchBtns[i])
                {
                    TouchBtns[i].color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                    saveVariables.QUN_Touch[i]++;
                    return;
                }
            }
            for (int i = 0; i < Second.Length; i++)
            {
                if (PressObj == SecondBtns[i])
                {
                    SecondBtns[i].color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                    saveVariables.QUN_Second[i]++;
                    return;
                }
            }

            if (PressObj == GoldBtn)
            {
                GoldBtn.color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                saveVariables.QUN_Gold++;
            }
            else if (PressObj == ClickBtn)
            {
                ClickBtn.color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                saveVariables.QUN_Click++;
            }
            else if (PressObj == PlayTimeBtn)
            {
                PlayTimeBtn.color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                saveVariables.QUN_PlayTime++;
            }
            else if (PressObj == DrawBtn)
            {
                DrawBtn.color = new Color(50 / 255, 50 / 255, 50 / 255, 1);
                saveVariables.QUN_Draw++;
            }
        }
        //if ���� ������Ʈ�� ���� 1,1,1,1�̸�
        //���� ������Ʈ ã��
        //�� 50/255�� �ٲٰ�
        //ī��Ʈ 1�߰��Ѵ�
    }
}
