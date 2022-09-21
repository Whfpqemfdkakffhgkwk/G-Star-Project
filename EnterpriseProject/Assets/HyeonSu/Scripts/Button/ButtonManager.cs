using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] Transform OnPos, OffPos;

    [SerializeField] private GameObject TouchWindow;

    public SaveVariables saveVariables;

    public void MainClick()
    {
        saveVariables.gold += (ulong)saveVariables.upgradeType[0].UpgradeStep * (ulong)Mathf.Pow((ulong)saveVariables.upgradeType[0].UpgradeMagnification, 2);
        //SaveVariables.gold += SaveVariables.totalTouchGold;
    }
    public void UpgradeBtns()
    {
        //type은 1부터 step은 0부터 시작
        int type = EventSystem.current.currentSelectedGameObject.GetComponent<ButtonRelease>().type;
        int step = EventSystem.current.currentSelectedGameObject.GetComponent<ButtonRelease>().step;
        switch (type)
        {
            case 1:
                switch (step)
                {
                    case 0:
                        if (saveVariables.gold >= (ulong)saveVariables.upgradeType[step].UpgradeCost)
                        {
                            //강화 수치(n강)
                            saveVariables.upgradeType[step].UpgradeStep++;
                            //강화 비용 깎기
                            saveVariables.gold -= (ulong)saveVariables.upgradeType[step].UpgradeCost;
                            //강화 비용 배율 올리기
                            saveVariables.upgradeType[step].UpgradeCost *= (ulong)saveVariables.upgradeType[step].UpgradeMagnification;
                        }
                            break;
                }
                break;
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
