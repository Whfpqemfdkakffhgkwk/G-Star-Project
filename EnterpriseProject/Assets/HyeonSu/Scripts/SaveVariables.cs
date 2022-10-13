using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class SaveVariables : ScriptableObject
{
    public double AllTouchMonmey, AllSecondMoney;
    public double gold;
    public double diamond;
    public GoodsList[] TouchType;
    public GoodsList[] SecondType;


    [System.Serializable]
    public struct GoodsList
    {
        public int UpgradeStep;
        public double UpgradeCost;
    }
    //[Header("Money")]
    //public ulong gold;
    //[Header("Facility")]
    //public int facilityUpgrade; //업그레이드 단계
    //public ulong facilityUpgradePrice; //업그레이드 가격
    //public ulong facilityUpgradePriceMagnification; //업그레이드 배율
    //[Header("Room")]
    //public int roomUpgrade; //업그레이드 단계
    //public int roomUpgradePrice; //업그레이드 가격
    //public ulong roomUpgradePriceMagnification; //업그레이드 배율
    ////[Header("Teacher")]
    //[Header("TotalUpgrade")]
    //public ulong totalTouchGold;
}