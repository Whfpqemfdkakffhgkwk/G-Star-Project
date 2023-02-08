using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class WebtoonManager : MonoBehaviour
{
    Scrollbar VerticalBar;

    public GameObject[] Webtoons; 

    [SerializeField]
    private RectTransform Content;

    [SerializeField]
    private Button FinishBtn; 

    private void Start()
    {
        VerticalBar = GetComponent<ScrollRect>().verticalScrollbar;
        FinishBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            FinishBtn.gameObject.SetActive(false);
            for (int i = 0; i < Webtoons.Length; i++)
            {
                Webtoons[i].SetActive(false);
            }
            VerticalBar.value = 1;
        });
    }

    private void OnEnable()
    {
        for (int i = 0; i < Webtoons.Length; i++)
        {
            if(Webtoons[i].activeSelf == true)
            {
                Content.sizeDelta = new Vector2(1440, 
                    Webtoons[i].GetComponent<RectTransform>().rect.height);

                return;
            }
        }
    }

    private void Update()
    {
        CheckReadAll();
    }

    void CheckReadAll()
    {
        if (VerticalBar.value != 0)
            return;

        FinishBtn.gameObject.SetActive(true);
    }

    
}
