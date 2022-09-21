using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Roll : MonoBehaviour
{
	//1 == 1, 2 == 2, 3 == 3, 4 == 4, 5 == 5, 6 == 6, 7 == 7, 8 == 8, 9 == 9
	[HideInInspector] public int[] List0 = new int[8];
	[HideInInspector] public int[] List1 = new int[100];
	[HideInInspector] public int[] List2 = new int[100];
	[HideInInspector] public int[] List3 = new int[100];

	[SerializeField] private TextMeshProUGUI Result;

	void Start()
	{
		List0 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

		List1 = new int[] { 1, 2, 5, 8, 9 };

		List2 = new int[] { 1, 3, 5, 7, 9 };

		List3 = new int[] { 2, 3, 4, 5, 6 };
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Debug.Log(Rolling("Tag1"));
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			Debug.Log(Rolling("Tag2"));
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			Debug.Log(Rolling("Tag3"));
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			Debug.Log(Rolling());
		}
		if (Input.GetKeyDown(KeyCode.T))
		{
			Debug.Log(Rolling("Tag1", "Tag2"));
		}
	}

	int Rolling(string Tag1 = null, string Tag2 = null, string Tag3 = null)
	{
		List<int> TempList = new List<int>();
		int TempNum;
		if (Tag1 == null)
		{
			TempList.AddRange(List0);
		}
		if (Tag1 == "Tag1" || Tag2 == "Tag1" || Tag3 == "Tag1")
		{
			TempList.AddRange(List1);
		}
		if (Tag1 == "Tag2" || Tag2 == "Tag2" || Tag3 == "Tag2")
		{
			TempList.AddRange(List2);
		}
		if (Tag1 == "Tag3" || Tag2 == "Tag3" || Tag3 == "Tag3")
		{
			TempList.AddRange(List3);
		}
		while (true)
		{
			TempNum = Random.Range(1, List0.Length + 1);
			//Debug.Log(TempNum);
			if (TempList.Contains(TempNum))
			{
				break;
			}
		}
		Result.text = TempNum.ToString();
		return TempNum;
	}
}
