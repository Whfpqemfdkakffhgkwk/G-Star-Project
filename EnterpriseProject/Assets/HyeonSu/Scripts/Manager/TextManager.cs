using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;
using static SaveVariables;

public class TextManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private Text[] ClickPrice = new Text[8]; //Ŭ�� ���� �迭
    [SerializeField] private Text[] ClickStep = new Text[8]; //Ŭ�� �ܰ� �迭
    [SerializeField] private Text GoldText;
    [SerializeField] private Text TouchText;
    [SerializeField] private Text PerSecText;

    [SerializeField]
    private SaveVariables saveVariables;
    private void FixedUpdate()
    {
        PriceText(ClickPrice, ClickStep, saveVariables.TouchType);
        GoodsText(GoldText, saveVariables.gold);
        GoodsText(TouchText, saveVariables.AllTouchMonmey);
        GoodsText(PerSecText, saveVariables.AllSecondMoney);
        //�ð���
        //���̾�
    }
    void PriceText(Text[] CKtexts, Text[] SPtests, GoodsList[] Goods)
    {
        for (int i = 0; i < CKtexts.Length; i++)
        {
            CKtexts[i].text = Goods[i].UpgradeCost.ToString();
            if (Goods[i].UpgradeStep == 0)
                SPtests[i].text = "���";
            else
                SPtests[i].text = "LV." + Goods[i].UpgradeStep.ToString();
        }
    }
    void GoodsText(Text text, double good)
    {
        text.text = good.ToString();
    }
}
