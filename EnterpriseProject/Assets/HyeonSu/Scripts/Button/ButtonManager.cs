using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using static SaveVariables;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Transform OnPos, OffPos;

    [SerializeField] private GameObject TouchWindow;
    [SerializeField] private GameObject[] TouchBtns;
    [SerializeField] private GameObject[] SecondBtns;

    public SaveVariables saveVariables;

    public void MainClick()
    {
        saveVariables.gold += saveVariables.AllTouchMonmey;
    }
    public IEnumerator MainSecond()
    {
        saveVariables.gold += saveVariables.AllSecondMoney;
        yield return new WaitForSeconds(1);
        StartCoroutine(MainSecond());
    }
    public void UpgradePressBtns()
    {
        bool typeCheck = false;
        GameObject ClickObj = EventSystem.current.currentSelectedGameObject;
        for (int i = 0; i < TouchBtns.Length; i++)
        {
            if (TouchBtns[i] == ClickObj)
            {
                typeCheck = true;
                UpgradeBtn(saveVariables.TouchType, i);
                break;
            }
        }
        if (typeCheck)
        {
            for (int i = 0; i < SecondBtns.Length; i++)
            {
                if (SecondBtns[i] == ClickObj)
                {
                    UpgradeBtn(saveVariables.SecondType, i);
                    break;
                }
            }
        }
    }
    void UpgradeBtn(GoodsList[] list, int arr)
    {
        if (saveVariables.gold >= (ulong)list[arr].UpgradeCost)
        {
            //강화 비용 깎기
            saveVariables.gold -= (ulong)list[arr].UpgradeCost;
            //강화 수치(n강)
            list[arr].UpgradeStep++;
            //강화 비용 늘리기
            list[arr].UpgradeCost += (ulong)(list[arr].UpgradeCost * ((ulong)list[arr].UpgradeStep));
            //강화 적용하기
            SaveManager.Instance.Combine();
        }
    }
    public void Facility()
    {
        OpenProduction(TouchWindow);
    }
    public void GoToDormitory()
    {

    }
    public void Exit()
    {
        CloseProduction(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject);
    }
    //창 열리는 연출
    void OpenProduction(GameObject Window)
    {
        Window.transform.DOLocalMove(OnPos.localPosition, 0.75f);
    }
    //창 닫히는 연출
    void CloseProduction(GameObject Window)
    {
        Window.transform.DOLocalMove(OffPos.localPosition, 0.75f);
    }
}
