using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [Header("Texts"), SerializeField]
    public Text Click1Text;
    public Text GoldText;
    public Text TouchText;
    public Text PerSecText;
    #region Test
    public SaveVariables saveVariables;
    #endregion
    private void FixedUpdate()
    {
        PriceText(Click1Text, saveVariables.upgradeType[0].UpgradeCost);
        GoodsText(GoldText, saveVariables.gold);
        GoodsText(TouchText, (ulong)saveVariables.upgradeType[0].UpgradeStep * (ulong)Mathf.Pow((ulong)saveVariables.upgradeType[0].UpgradeMagnification, 2));
        //시간당
        //다이아
    }
    void PriceText(Text text, ulong Goods)
    {
        text.text = Goods.ToString();
    }
    void GoodsText(Text text, ulong good)
    {
        text.text = good.ToString();
    }
}
