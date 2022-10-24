using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    [SerializeField] Text[] QuestStatus;

    [SerializeField] private Text[] Touch, Second;
    [SerializeField] private Text Gold, Click, PlayTime, Draw;

    [SerializeField] private Image[] TouchBtns, SecondBtns;
    [SerializeField] private Image GoldBtn, ClickBtn, PlayTimeBtn, DrawBtn;

    [SerializeField] private SaveVariables saveVariables;

    private void Update()
    {
        OrganizeStatusText();
    }
    void OrganizeStatusText()
    {
        for (int i = 0; i < Touch.Length; i++)
        {
            Touch[i].text = saveVariables.QU_Touch[i].ToString() + " / " + ((10 * saveVariables.QUN_Touch[i]) + 10).ToString();
            if (saveVariables.QU_Touch[i] >= ((10 * saveVariables.QUN_Touch[i]) + 10))
            {
                TouchBtns[i].color = new Color(1, 1, 1, 1);
            }
        }
        for (int i = 0; i < Second.Length; i++)
            Touch[i].text = saveVariables.QU_Second[i].ToString() + " / " + ((10 * saveVariables.QUN_Second[i]) + 10).ToString();
        Gold.text = saveVariables.QU_Gold.ToString() + " / " + ((5000 * saveVariables.QUN_Gold) + 5000).ToString();
        Click.text = saveVariables.QU_Click.ToString() + " / " + ((300 * saveVariables.QUN_Click) + 300).ToString();
        PlayTime.text = saveVariables.QU_PlayTime.ToString() + " / " + ((100 * saveVariables.QUN_PlayTime) + 100).ToString();
        Draw.text = saveVariables.QU_Draw.ToString() + " / " + ((1 * saveVariables.QUN_Draw) + 1).ToString();
    }
    protected virtual void ButtonState(Image PressObj)//<- 누른 오브젝트
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
        //if 누른 오브젝트가 색이 1,1,1,1이면
        //누른 오브젝트 찾고
        //색 50/255로 바꾸고
        //카운트 1추가한다
    }
}
