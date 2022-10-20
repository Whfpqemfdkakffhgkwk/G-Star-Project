using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    [SerializeField] Text[] QuestStatus;

    [SerializeField] private Text[] Touch, Second; 
    [SerializeField] private Text Gold, Click, PlayTime, Draw;


    [SerializeField] private SaveVariables SaveVariables;
    void OrganizeStatusText()
    {
        for (int i = 0; i < Touch.Length; i++)
        {
            //Touch[i].text = 
        }
    }
}
