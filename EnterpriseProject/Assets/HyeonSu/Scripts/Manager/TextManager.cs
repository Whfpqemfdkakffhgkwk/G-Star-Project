using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;
using static SaveVariables;

public class TextManager : MonoBehaviour
{
    [SerializeField, Tooltip("Ŭ�� ���� �迭")] private Text[] ClickPrice = new Text[8];
    [SerializeField, Tooltip("Ŭ�� �ܰ� �迭")] private Text[] ClickStep = new Text[8];
    [SerializeField, Tooltip("Ŭ�� ������ �迭")] private Text[] ClickInc = new Text[8];
    [SerializeField, Tooltip("Ŭ�� ����̹��� �迭")] private GameObject[] ClickRock = new GameObject[8];

    [SerializeField, Tooltip("�ʴ� ���� �迭")] private Text[] SecondPrice = new Text[8];
    [SerializeField, Tooltip("�ʴ� �ܰ� �迭")] private Text[] SecondStep = new Text[8];
    [SerializeField, Tooltip("�ʴ� ������ �迭")] private Text[] SecondInc = new Text[8];

    [SerializeField] private Text GoldText;
    [SerializeField] private Text TouchText;
    [SerializeField] private Text PerSecText;

    [SerializeField]
    private SaveVariables saveVariables;
    private void FixedUpdate()
    {
        PriceText(ClickPrice, ClickStep, ClickRock, saveVariables.TouchType);
        IncrementText(ClickInc, saveVariables.TouchType);

        PriceText(SecondPrice, SecondStep, null, saveVariables.SecondType);
        IncrementText(SecondInc, saveVariables.SecondType);

        GoodsText(GoldText, saveVariables.gold);
        GoodsText(TouchText, saveVariables.AllTouchMonmey);
        GoodsText(PerSecText, saveVariables.AllSecondMoney);
        //���̾�
    }
    void PriceText(Text[] CKtexts, Text[] SPtexts, GameObject[] RockImg, GoodsList[] Goods)
    {
        for (int i = 0; i < CKtexts.Length; i++)
        {
            CKtexts[i].text = Goods[i].UpgradeCost.ToString();
            if (Goods[i].UpgradeStep == 0)
            {
                SPtexts[i].text = "���";
                //RockImg[i].SetActive(true);
            }
            else
            {
                SPtexts[i].text = "LV." + Goods[i].UpgradeStep.ToString();
                //RockImg[i].SetActive(false);
            }
        }
    }
    void IncrementText(Text[] texts, GoodsList[] Goods)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "+ " + (ulong)(Goods[i].UpgradeCost * ((ulong)Goods[i].UpgradeStep + 1 / 10.0f));
        }
    }
    void GoodsText(Text text, double good)
    {
        text.text = good.ToString();
    }
}
