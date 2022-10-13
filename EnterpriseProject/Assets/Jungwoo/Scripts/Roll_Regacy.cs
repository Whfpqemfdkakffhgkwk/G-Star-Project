using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Roll_Regacy : MonoBehaviour
{
	//1 == 1, 2 == 2, 3 == 3, 4 == 4, 5 == 5, 6 == 6, 7 == 7, 8 == 8, 9 == 9
	//배열 생성
	[HideInInspector] public int[] List0 = new int[100];
	[HideInInspector] public int[] List1 = new int[100];
	[HideInInspector] public int[] List2 = new int[100];
	[HideInInspector] public int[] List3 = new int[100];

	//화면에 띄울 임시 TMP
	[SerializeField] private TextMeshProUGUI Result;

	void Start()
	{
		//태그별 리스트에 해당 태그를 가진 목록 추가
		List0 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

		List1 = new int[] { 1, 2, 5, 8, 9 };

		List2 = new int[] { 1, 3, 5, 7, 9 };

		List3 = new int[] { 2, 3, 4, 5, 6 };
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Result.text = Rolling("Tag1").ToString();
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			Result.text = Rolling("Tag2").ToString();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			Result.text = Rolling("Tag3").ToString();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Result.text = Rolling().ToString();
		}
		if (Input.GetKeyDown(KeyCode.T))
		{
			Result.text = Rolling("Tag1", "Tag2").ToString();
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			Result.text = Rolling("Tag1", "Tag2", "Tag3").ToString();
		}
	}

	int Rolling(string Tag1 = null, string Tag2 = null, string Tag3 = null)
	{
		List<int> TempList = new List<int>();
		List<int> TempList1 = new List<int>();
		int TempNum;
		TempList.AddRange(List0);
		if (Tag1 == "Tag1" || Tag2 == "Tag1" || Tag3 == "Tag1")
		{
			foreach (int i in List1)
			{
				if (TempList.Contains(i))
				{
					TempList1.Add(i);
				}
			}
			TempList = TempList1.ConvertAll(s => s);
			TempList1.Clear();
		}
		if (Tag1 == "Tag2" || Tag2 == "Tag2" || Tag3 == "Tag2")
		{
			foreach (int i in List2)
			{
				if (TempList.Contains(i))
				{
					TempList1.Add(i);
				}
			}
			TempList = TempList1.ConvertAll(s => s);
			TempList1.Clear();
		}
		if (Tag1 == "Tag3" || Tag2 == "Tag3" || Tag3 == "Tag3")
		{
			foreach (int i in List3)
			{
				if (TempList.Contains(i))
				{
					TempList1.Add(i);
				}
			}
			TempList = TempList1.ConvertAll(s => s);
			TempList1.Clear();
		}
		while (true)
		{
			TempNum = Random.Range(1, List0.Length + 1);
			//Debug.Log(List0.Length + "/" + TempNum);
			if (TempList.Contains(TempNum))
			{
				break;
			}
		}
		return TempNum;
	}
}
