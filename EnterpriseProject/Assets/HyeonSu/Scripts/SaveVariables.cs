using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class SaveVariables : ScriptableObject
{
    [Header("재화")]
    public double AllTouchMonmey, AllSecondMoney;
    public double gold;
    public double diamond;
    [Header("퀘스트")]
    [Tooltip("퀘스트 - 터치업그레이드")]public int[] QU_Touch;
    [Tooltip("퀘스트 - 초당업그레이드")]public int[] QU_Second;
    [Tooltip("퀘스트 - 획득골드")]public int QU_Gold;
    [Tooltip("퀘스트 - 클릭횟수")]public int QU_Click;
    [Tooltip("퀘스트 - 플레이타임")]public int QU_PlayTime;
    [Tooltip("퀘스트 - 뽑은횟수")]public int QU_Draw; //아직 안함

    [Tooltip("보상횟수 - 터치업그레이드")] public int[] QUN_Touch;
    [Tooltip("보상횟수 - 초당업그레이드")] public int[] QUN_Second;
    [Tooltip("보상횟수 - 획득골드")] public int QUN_Gold;
    [Tooltip("보상횟수 - 클릭횟수")] public int QUN_Click;
    [Tooltip("보상횟수 - 플레이타임")] public int QUN_PlayTime;
    [Tooltip("보상횟수 - 뽑은횟수")] public int QUN_Draw;
    [Header("호감도 퀘스트")]
    public bool[] LeeTaeyeon;
    public bool[] JeongSeoYoon;
    public bool[] LeeYerin;
    public bool[] SongYeonHa;
    public bool[] SeongJunAh;
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