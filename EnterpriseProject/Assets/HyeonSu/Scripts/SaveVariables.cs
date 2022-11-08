using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class SaveVariables : ScriptableObject
{
    [Header("��ȭ")]
    public double AllTouchMonmey, AllSecondMoney;
    public double gold;
    public double diamond;
    [Header("����Ʈ")]
    [Tooltip("����Ʈ - ��ġ���׷��̵�")]public int[] QU_Touch;
    [Tooltip("����Ʈ - �ʴ���׷��̵�")]public int[] QU_Second;
    [Tooltip("����Ʈ - ȹ����")]public int QU_Gold;
    [Tooltip("����Ʈ - Ŭ��Ƚ��")]public int QU_Click;
    [Tooltip("����Ʈ - �÷���Ÿ��")]public int QU_PlayTime;
    [Tooltip("����Ʈ - ����Ƚ��")]public int QU_Draw; //���� ����

    [Tooltip("����Ƚ�� - ��ġ���׷��̵�")] public int[] QUN_Touch;
    [Tooltip("����Ƚ�� - �ʴ���׷��̵�")] public int[] QUN_Second;
    [Tooltip("����Ƚ�� - ȹ����")] public int QUN_Gold;
    [Tooltip("����Ƚ�� - Ŭ��Ƚ��")] public int QUN_Click;
    [Tooltip("����Ƚ�� - �÷���Ÿ��")] public int QUN_PlayTime;
    [Tooltip("����Ƚ�� - ����Ƚ��")] public int QUN_Draw;
    [Header("ȣ���� ����Ʈ")]
    public bool[] LeeTaeyeon;
    public bool[] JeongSeoYoon;
    public bool[] LeeYerin;
    public bool[] SongYeonHa;
    public bool[] SeongJunAh;
    [Header("ȣ���� ����Ʈ �ܰ�")] //��Ʈ ��ǳ�� Ŭ���� ȣ���� ������ �ɵ�
    public float LeeTaeyeonCrush;
    public float JeongSeoYoonCrush;
    public float LeeYerinCrush;
    public float SongYeonHaCrush;
    public float SeongJunAhCrush;
    [Header("ĳ���� ���")]
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")]public bool isLeeTaeyeon;
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")]public bool isJeongSeoYoon;
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")]public bool isLeeYerin;
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")]public bool isSongYeonHa;
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")]public bool isSeongJunAh;
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