using UnityEngine;

[System.Serializable]
public class SaveVariables
{
	[Header("��ȭ")]
	public double AllTouchMonmey;
	public double AllSecondMoney;
	public double gold;
	public double diamond;
	public float ItemMultiply;
	public int ManyMoney;
	public int Fever;
	public float GodHand;
	public float GoldenTicket;
	[Header("����Ʈ")]
	[Tooltip("����Ʈ - ��ġ���׷��̵�")] public int[] QU_Touch;
	[Tooltip("����Ʈ - �ʴ���׷��̵�")] public int[] QU_Second;
	[Tooltip("����Ʈ - ȹ����")] public ulong QU_Gold;
	[Tooltip("����Ʈ - Ŭ��Ƚ��")] public int QU_Click;
	[Tooltip("����Ʈ - �÷���Ÿ��")] public int QU_PlayTime;
	[Tooltip("����Ʈ - ����Ƚ��")] public int QU_Draw;

	[Tooltip("����Ƚ�� - ��ġ���׷��̵�")] public int[] QUN_Touch;
	[Tooltip("����Ƚ�� - �ʴ���׷��̵�")] public int[] QUN_Second;
	[Tooltip("����Ƚ�� - ȹ����")] public ulong QUN_Gold;
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
	[Header("ȣ���� ����Ʈ �޼� ī��Ʈ")]
	public int[] QU_TouchHeart;
	[Header("ĳ���� ���")]
	[Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isLeeTaeyeon;
	[Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isJeongSeoYoon;
	[Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isLeeYerin;
	[Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isSongYeonHa;
	[Tooltip("ĳ���� �̾Ҵ��� Ȯ���ϴ� bool��")] public bool isSeongJunAh;
	[Header("ĳ���� ����ȴ�ȭ[ĳ����][�� ��ȭ]")]
	[Tooltip("[ĳ����][��ȭ]")] public bool[][] SpecialTalks;

	[Tooltip("ȣ����ȭ �ߴ� �ܰ�")] public float CurLeeTaeyeon, CurJeongSeoYoon, CurLeeYerin, CurSongYeonHa, CurSeongJunAh;

	[Space(10)]
	public GoodsList[] TouchType;
	public GoodsList[] SecondType;

	public float LeeTaeyeonCrush
	{
		get { return leeTaeyeonCrush; }

		set
		{
			leeTaeyeonCrush = value;
			if (leeTaeyeonCrush >= CurLeeTaeyeon)
			{
				if (CurLeeTaeyeon == 20)
					LeeTaeyeon[0] = true;
				else if (CurLeeTaeyeon == 40)
					LeeTaeyeon[1] = true;
				else if (CurLeeTaeyeon == 60)
					LeeTaeyeon[2] = true;
				else if (CurLeeTaeyeon == 80)
					LeeTaeyeon[3] = true;
				else if (CurLeeTaeyeon == 100)
					LeeTaeyeon[4] = true;
				CurLeeTaeyeon += 20;
			}
		}
	}
	public float JeongSeoYoonCrush
	{
		get { return jeongSeoYoonCrush; }

		set
		{
			jeongSeoYoonCrush = value;
			if (jeongSeoYoonCrush >= CurJeongSeoYoon)
			{
				if (CurJeongSeoYoon == 20)
					JeongSeoYoon[0] = true;
				else if (CurJeongSeoYoon == 40)
					JeongSeoYoon[1] = true;
				else if (CurJeongSeoYoon == 60)
					JeongSeoYoon[2] = true;
				else if (CurJeongSeoYoon == 80)
					JeongSeoYoon[3] = true;
				else if (CurJeongSeoYoon == 100)
					JeongSeoYoon[4] = true;
				CurJeongSeoYoon += 20;
			}
		}
	}
	public float LeeYerinCrush
	{
		get { return leeYerinCrush; }

		set
		{
			leeYerinCrush = value;
			if (leeYerinCrush >= CurLeeYerin)
			{
				if (CurLeeYerin == 20)
					LeeYerin[0] = true;
				else if (CurLeeYerin == 40)
					LeeYerin[1] = true;
				else if (CurLeeYerin == 60)
					LeeYerin[2] = true;
				else if (CurLeeYerin == 80)
					LeeYerin[3] = true;
				else if (CurLeeYerin == 100)
					LeeYerin[4] = true;
				CurLeeYerin += 20;
			}
		}
	}
	public float SongYeonHaCrush
	{
		get { return songYeonHaCrush; }

		set
		{
			songYeonHaCrush = value;
			if (songYeonHaCrush >= CurSongYeonHa)
			{
				if (CurSongYeonHa == 20)
					SongYeonHa[0] = true;
				else if (CurSongYeonHa == 40)
					SongYeonHa[1] = true;
				else if (CurSongYeonHa == 60)
					SongYeonHa[2] = true;
				else if (CurSongYeonHa == 80)
					SongYeonHa[3] = true;
				else if (CurSongYeonHa == 100)
					SongYeonHa[4] = true;
				CurSongYeonHa += 20;
			}
		}
	}
	public float SeongJunAhCrush
	{
		get { return seongJunAhCrush; }

		set
		{
			seongJunAhCrush = value;
			if (seongJunAhCrush >= CurSeongJunAh)
			{
				if (CurSeongJunAh == 20)
					SeongJunAh[0] = true;
				else if (CurSeongJunAh == 40)
					SeongJunAh[1] = true;
				else if (CurSeongJunAh == 60)
					SeongJunAh[2] = true;
				else if (CurSeongJunAh == 80)
					SeongJunAh[3] = true;
				else if (CurSeongJunAh == 100)
					SeongJunAh[4] = true;
				CurSeongJunAh += 20;
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