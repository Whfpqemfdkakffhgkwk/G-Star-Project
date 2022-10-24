using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class QuestBtn : QuestManager
{
    public void BtnClick()
    {
        Image ClickImg = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        base.ButtonState(ClickImg);
    }
}
