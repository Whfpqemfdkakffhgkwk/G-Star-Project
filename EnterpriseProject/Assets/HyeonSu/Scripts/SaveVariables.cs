using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class SaveVariables : ScriptableObject
{
    [Header("��ȭ")]
    public double AllTouchMonmey, AllSecondMoney;
    public double gold;
    public double diamond;
    [Header("����Ʈ")]
    [Tooltip("����Ʈ - ��ġ���׷��̵�")] public int[] QU_Touch;
    [Tooltip("����Ʈ - �ʴ���׷��̵�")] public int[] QU_Second;
    [Tooltip("����Ʈ - ȹ����")] public int QU_Gold;
    [Tooltip("����Ʈ - Ŭ��Ƚ��")] public int QU_Click;
    [Tooltip("����Ʈ - �÷���Ÿ��")] public int QU_PlayTime;
    [Tooltip("����Ʈ - ����Ƚ��")] public int QU_Draw; //���� ����

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
    private float leeTaeyeonCrush;
    private float jeongSeoYoonCrush;
    private float leeYerinCrush;
    private float songYeonHaCrush;
    private float seongJunAhCrush;
    [Header("ĳ���� ���")]
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isLeeTaeyeon;
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isJeongSeoYoon;
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isLeeYerin;
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isSongYeonHa;
    [Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isSeongJunAh;

    [Tooltip("ȣ����ȭ �ߴ� �ܰ�")] public float MaxLeeTaeyeon, MaxJeongSeoYoon, MaxLeeYerin, MaxSongYeonHa, MaxSeongJunAh;

    [Space(10)]
    public GoodsList[] TouchType;
    public GoodsList[] SecondType;

    public float LeeTaeyeonCrush
    {
        get { return leeTaeyeonCrush; }

        set
        {
            leeTaeyeonCrush = value;
            if (leeTaeyeonCrush >= MaxLeeTaeyeon)
            {
                if (MaxLeeTaeyeon == 20)
                    LeeTaeyeon[0] = true;
                else if (MaxLeeTaeyeon == 40)
                    LeeTaeyeon[1] = true;
                else if (MaxLeeTaeyeon == 60)
                    LeeTaeyeon[2] = true;
                else if (MaxLeeTaeyeon == 80)
                    LeeTaeyeon[3] = true;
                else if (MaxLeeTaeyeon == 100)
                    LeeTaeyeon[4] = true;
                MaxLeeTaeyeon += 20;
            }
        }
    }
    public float JeongSeoYoonCrush
    {
        get { return jeongSeoYoonCrush; }

        set
        {
            jeongSeoYoonCrush = value;
            if (jeongSeoYoonCrush >= MaxJeongSeoYoon)
            {
                if (MaxJeongSeoYoon == 20)
                    JeongSeoYoon[0] = true;
                else if (MaxJeongSeoYoon == 40)
                    JeongSeoYoon[1] = true;
                else if (MaxJeongSeoYoon == 60)
                    JeongSeoYoon[2] = true;
                else if (MaxJeongSeoYoon == 80)
                    JeongSeoYoon[3] = true;
                else if (MaxJeongSeoYoon == 100)
                    JeongSeoYoon[4] = true;
                MaxJeongSeoYoon += 20;
            }
        }
    }
    public float LeeYerinCrush
    {
        get { return leeYerinCrush; }

        set
        {
            leeYerinCrush = value;
            if (leeYerinCrush >= MaxLeeYerin)
            {
                if (MaxLeeYerin == 20)
                    LeeYerin[0] = true;
                else if (MaxLeeYerin == 40)
                    LeeYerin[1] = true;
                else if (MaxLeeYerin == 60)
                    LeeYerin[2] = true;
                else if (MaxLeeYerin == 80)
                    LeeYerin[3] = true;
                else if (MaxLeeYerin == 100)
                    LeeYerin[4] = true;
                MaxLeeYerin += 20;
            }
        }
    }
    public float SongYeonHaCrush
    {
        get { return songYeonHaCrush; }

        set
        {
            songYeonHaCrush = value;
            if (songYeonHaCrush >= MaxSongYeonHa)
            {
                if (MaxSongYeonHa == 20)
                    SongYeonHa[0] = true;
                else if (MaxSongYeonHa == 40)
                    SongYeonHa[1] = true;
                else if (MaxSongYeonHa == 60)
                    SongYeonHa[2] = true;
                else if (MaxSongYeonHa == 80)
                    SongYeonHa[3] = true;
                else if (MaxSongYeonHa == 100)
                    SongYeonHa[4] = true;
                MaxSongYeonHa += 20;
            }
        }
    }
    public float SeongJunAhCrush
    {
        get { return seongJunAhCrush; }

        set
        {
            seongJunAhCrush = value;
            if (seongJunAhCrush >= MaxSeongJunAh)
            {
                if (MaxSeongJunAh == 20)
                    SeongJunAh[0] = true;
                else if (MaxSeongJunAh == 40)
                    SeongJunAh[1] = true;
                else if (MaxSeongJunAh == 60)
                    SeongJunAh[2] = true;
                else if (MaxSeongJunAh == 80)
                    SeongJunAh[3] = true;
                else if (MaxSeongJunAh == 100)
                    SeongJunAh[4] = true;
                MaxSeongJunAh += 20;
            }
        }
    }
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