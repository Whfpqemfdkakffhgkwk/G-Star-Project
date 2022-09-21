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
        //type�� 1���� step�� 0���� ����
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
                            //��ȭ ��ġ(n��)
                            saveVariables.upgradeType[step].UpgradeStep++;
                            //��ȭ ��� ���
                            saveVariables.gold -= (ulong)saveVariables.upgradeType[step].UpgradeCost;
                            //��ȭ ��� ���� �ø���
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
    //â ������ ����
    void OpenProduction(GameObject Window)
    {
        Window.transform.DOLocalMove(OnPos.localPosition, 0.75f);
    }
    //â ������ ����
    void CloseProduction(GameObject Window)
    {
        Window.transform.DOLocalMove(OffPos.localPosition, 0.75f);
    }
}
