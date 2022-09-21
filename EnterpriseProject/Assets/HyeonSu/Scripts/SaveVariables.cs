using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class SaveVariables : ScriptableObject
{
    public ulong gold;
    public ulong diamond;
    public UpgradeType[] upgradeType;
    [System.Serializable]
    public struct UpgradeType
    {
        public int UpgradeStep;
        public ulong UpgradeCost;
        public double UpgradeMagnification;
    }
    //[Header("Money")]
    //public ulong gold;
    //[Header("Facility")]
    //public int facilityUpgrade; //���׷��̵� �ܰ�
    //public ulong facilityUpgradePrice; //���׷��̵� ����
    //public ulong facilityUpgradePriceMagnification; //���׷��̵� ����
    //[Header("Room")]
    //public int roomUpgrade; //���׷��̵� �ܰ�
    //public int roomUpgradePrice; //���׷��̵� ����
    //public ulong roomUpgradePriceMagnification; //���׷��̵� ����
    ////[Header("Teacher")]
    //[Header("TotalUpgrade")]
    //public ulong totalTouchGold;
}