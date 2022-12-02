using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Scrollbar scrollbar; //��ũ�ѹ��� ��ġ�� �������� ���� ������ �˻�
    [SerializeField] float swipeSpeed = 0.2f; // �������� �������� �Ǵ� �ð�
    [SerializeField] float swipeDistance = 50.0f; //���������ϴ� �ּҰŸ�
    [SerializeField] private ButtonManager buttonManager;

    [Tooltip("�� �������� ��ġ ��")]private float[] scrollPageValues;
    [Tooltip("�� ������ ������ �Ÿ�")]private float valueDistance = 0;
    [Tooltip("���� ������")]private int currentPage = 0;
    [Tooltip("�ִ� ������")]private int maxPage = 0;
    [Tooltip("��ġ ���� ��ġ")]private float startTouchX;
    [Tooltip("��ġ ���� ��ġ")]private float endTouchX;
    [Tooltip("���� Swipe�� �ǰ� �ִ��� üũ")]private bool isSwipeMode = false;

    private void Awake()
    {
        //������ ����
        scrollPageValues = new float[5];
        //��ũ�� �Ǵ� ������ ������ �Ÿ�
        valueDistance = 1f / 4f;
        //��ũ�� �Ǵ� �������� �� value ��ġ ����
        for (int i = 0; i < scrollPageValues.Length; i++)
        {
            scrollPageValues[i] = valueDistance * i;
            Debug.Log(scrollPageValues[i]);
        }
        maxPage = 5;
    }
    private void Start()
    {
        //ó�� ������ ����
        SetScrollBarValue(2);
    }
    private void Update()
    {
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

            UpdateSwipe();
        }
    }
    void UpdateSwipe()
    {
        //�ʹ� ���� �Ÿ��� �������� ���� Swipe X
        if(Mathf.Abs(startTouchX-endTouchX) < swipeDistance)
        {
            //���������� �ƴϴ� ��ġ ������
            buttonManager.MainClick();

            //���� �������� ���������ؼ� ���ư���
            StartCoroutine(OnSwipeOneStep(currentPage));
            return;
        }
        //�������� ����
        bool isLeft = startTouchX < endTouchX ? true : false;

        //�̵� ������ �����϶�
        if(isLeft)
        {
            //���� �������� ���� ���̸� ����
            if (currentPage == 0) return;
            //�������� �̵��� ���� ���� �������� 1 ����
            currentPage--;
        }
        else
        {
            //���� �������� ������ ���̸� ����
            if(currentPage == maxPage - 1) return;
            //���������� �̵��� ���� ���� �������� 1 ����
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSwipeMode == true) return;

        startTouchX = Input.mousePosition.x;
    }
}
