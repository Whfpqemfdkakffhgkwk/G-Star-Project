using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Scrollbar scrollbar; //스크롤바의 위치를 바탕으로 현재 페이지 검사
    [SerializeField] float swipeSpeed = 0.2f; // 페이지가 스와이프 되는 시간
    [SerializeField] float swipeDistance = 50.0f; //움직여야하는 최소거리
    [SerializeField] private ButtonManager buttonManager;

    [Tooltip("각 페이지의 위치 값")] private float[] scrollPageValues;
    [Tooltip("각 페이지 사이의 거리")] private float valueDistance = 0;
    [Tooltip("현재 페이지")] private int currentPage = 0;
    [Tooltip("최대 페이지")] private int maxPage = 0;
    [Tooltip("터치 시작 위치")] private float startTouchX;
    [Tooltip("터치 종료 위치")] private float endTouchX, endTouchY;
    [Tooltip("현재 Swipe가 되고 있는지 체크")] private bool isSwipeMode = false;

    [Tooltip("현재 페이지 sprite들"), SerializeField] private Sprite[] MapSprs;
    [SerializeField] private Image MapImg;
    [SerializeField] private Text MapText;

    private void Awake()
    {
        //페이지 개수
        scrollPageValues = new float[5];
        //스크롤 되는 페이지 사이의 거리
        valueDistance = 1f / 4f;
        //스크롤 되는 페이지의 각 value 위치 설정
        for (int i = 0; i < scrollPageValues.Length; i++)
        {
            scrollPageValues[i] = valueDistance * i;
            Debug.Log(scrollPageValues[i]);
        }
        maxPage = 5;
    }
    private void Start()
    {
        //처음 페이지 설정
        SetScrollBarValue(2);
        UIonthePage(currentPage);
    }
    private void Update()
    {
        if (startTouchX != 0)
            UpdateInput();
    }
    public void SetScrollBarValue(int index)
    {
        currentPage = index;
        scrollbar.value = scrollPageValues[index];
    }
    void UpdateInput()
    {
        if (isSwipeMode == true) return;

        if (Input.GetMouseButtonUp(0))
        {
            endTouchX = Input.mousePosition.x;
            endTouchY = Input.mousePosition.y;

            UpdateSwipe();
        }
    }
    void UpdateSwipe()
    {
        //너무 작은 거리를 움직였을 때는 Swipe X
        if (Mathf.Abs(startTouchX - endTouchX) < swipeDistance)
        {
            //스와이프가 아니고
            //밑에서 터치가 끝난게 아니면 터치 돈벌기
            if (endTouchY > 1200)
                buttonManager.MainClick();

            //원래 페이지로 스와이프해서 돌아간다
            StartCoroutine(OnSwipeOneStep(currentPage));
            startTouchX = 0;
            return;
        }
        //스와이프 방향
        bool isLeft = startTouchX < endTouchX ? true : false;

        //이동 방향이 왼쪽일때
        if (isLeft)
        {
            //현재 페이지가 왼쪽 끝이면 종료
            if (currentPage == 0) return;
            //왼쪽으로 이동을 위해 현재 페이지를 1 감소
            currentPage--;
        }
        else
        {
            //현재 페이지가 오른쪽 끝이면 종료
            if (currentPage == maxPage - 1) return;
            //오른쪽으로 이동을 위해 현재 페이지를 1 증가
            currentPage++;
        }

        StartCoroutine(OnSwipeOneStep(currentPage));
    }
    IEnumerator OnSwipeOneStep(int index)
    {
        float start = scrollbar.value;
        float current = 0;
        float percent = 0;

        isSwipeMode = true;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / swipeSpeed;

            scrollbar.value = Mathf.Lerp(start, scrollPageValues[index], percent);
            yield return null;
        }
        isSwipeMode = false;
        UIonthePage(currentPage);
    }

    void UIonthePage(int cur)
    {
        MapImg.sprite = MapSprs[cur];
        switch (cur)
        {
            case 0:
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 144.7f);
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 72.6f);
                MapText.text = "헬스장";
                break;
            case 1:
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 164.5f);
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 88.848f);
                MapText.text = "도서실";
                break;
            case 2:
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 170.9f);
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 99.8f);
                MapText.text = "침실";
                break;
            case 3:
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                MapText.text = "컴퓨터실";
                break;
            case 4:
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 45.1f);
                MapImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 116.8f);
                MapText.text = "노래방";
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSwipeMode == true) return;

        startTouchX = Input.mousePosition.x;
    }
}
