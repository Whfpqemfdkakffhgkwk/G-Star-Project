using UnityEngine;


[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class SaveVariables : ScriptableObject
{
	[Header("재화")]
	public double AllTouchMonmey;
	public double AllSecondMoney;
	public double gold;
	public double diamond;
	[Header("퀘스트")]
	[Tooltip("퀘스트 - 터치업그레이드")] public int[] QU_Touch;
	[Tooltip("퀘스트 - 초당업그레이드")] public int[] QU_Second;
	[Tooltip("퀘스트 - 획득골드")] public int QU_Gold;
	[Tooltip("퀘스트 - 클릭횟수")] public int QU_Click;
	[Tooltip("퀘스트 - 플레이타임")] public int QU_PlayTime;
	[Tooltip("퀘스트 - 뽑은횟수")] public int QU_Draw;

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
	[Header("호감도 퀘스트 단계")] //하트 말풍선 클릭시 호감도 오르면 될듯
	private float leeTaeyeonCrush;
	private float jeongSeoYoonCrush;
	private float leeYerinCrush;
	private float songYeonHaCrush;
	private float seongJunAhCrush;
	[Header("캐릭터 잠금")]
	[Tooltip("캐릭터 뽑았는지 확인하는 bool값")] public bool isLeeTaeyeon;
	[Tooltip("캐릭터 뽑았는지 확인하는 bool값")] public bool isJeongSeoYoon;
	[Tooltip("캐릭터 뽑았는지 확인하는 bool값")] public bool isLeeYerin;
	[Tooltip("캐릭터 뽑았는지 확인하는 bool값")] public bool isSongYeonHa;
	[Tooltip("캐릭터 뽑았는지 확인하는 bool값")] public bool isSeongJunAh;

	[Tooltip("호감대화 했던 단계")] public float MaxLeeTaeyeon, MaxJeongSeoYoon, MaxLeeYerin, MaxSongYeonHa, MaxSeongJunAh;

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