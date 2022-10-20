using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class SaveVariables : ScriptableObject
{
    [Header("재화")]
    public double AllTouchMonmey, AllSecondMoney;
    public double gold;
    public double diamond;
    [Header("퀘스트")]
    public int[] QU_Touch;
    public int[] QU_Second;
    public int QU_Gold;
    public int QU_Click;
    public int QU_PlayTime;
    public int QU_Draw; //아직 안함
    [Space(10)]
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