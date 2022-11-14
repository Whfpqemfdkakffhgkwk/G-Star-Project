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
			//float XLoc = CharacterObj.GetComponent<RectTransform>().anchoredPosition.x;
			float XLoc = CharacterObj.transform.localPosition.x;
			//float YLoc = CharacterObj.GetComponent<RectTransform>().anchoredPosition.y;
			float YLoc = CharacterObj.transform.localPosition.y;
			Temp = Random.Range(15, 31);
			if (Random.Range(0, 2) == 0)
			{
				LR = -1;
				GetComponent<SpriteRenderer>().flipX = true;
			}
			else
			{
				LR = 1;
				GetComponent<SpriteRenderer>().flipX = false;
			}
			if (CharacterObj.transform.localPosition.x <= -700)
			{
				LR = 1;
				GetComponent<SpriteRenderer>().flipX = false;
			}
			else if (CharacterObj.transform.localPosition.x >= 700)
			{
				LR = -1;
				GetComponent<SpriteRenderer>().flipX = true;
			}
			GetComponent<Animator>().SetTrigger("Walk");
			for (int i = 0; i < Temp; i++)
			{
				CharacterObj.transform.localPosition = new Vector3(XLoc + i * 10 * LR, YLoc, -1);
				yield return new WaitForSeconds(0.02f);
			}
			GetComponent<Animator>().SetTrigger("Idle");
			yield return new WaitForSeconds(2f);
		}
	}
}
