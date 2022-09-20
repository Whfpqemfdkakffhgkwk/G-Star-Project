using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class SaveVariables : ScriptableObject
{
    public UpgradeType[] upgradeType;
    [System.Serializable]
    public struct UpgradeType
    {
        public int UpgradeStep;
        public int UpgradeCost;
        public int UpgradeMagnification;
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