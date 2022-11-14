using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public GameObject InformationPannel;
	public GameObject CharacterObj;
	void Start()
	{
		StartCoroutine(MoveCharacter());
	}

	void Update()
	{

	}

	public void ClickInformation()
	{

	}

	IEnumerator MoveCharacter()
	{
		int Temp = 0;
		int LR = 0;
		while (true)
		{
			float XLoc = CharacterObj.GetComponent<RectTransform>().anchoredPosition.x;
			float YLoc = CharacterObj.GetComponent<RectTransform>().anchoredPosition.y;
			Temp = Random.Range(0, 12);
			if (Random.Range(0, 2) == 0)
			{
				LR = -1;
			}
			else
			{
				LR = 1;
			}
			for (int i = 0; i < Temp; i++)
			{
				CharacterObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(XLoc + i * 15 * LR, YLoc, 0);
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(2f);
		}
	}
}
