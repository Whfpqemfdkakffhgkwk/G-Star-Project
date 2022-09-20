using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] Transform OnPos, OffPos;

    [SerializeField] private GameObject TouchWindow;
    
    public SaveVariables SaveVariables;

    public void MainClick()
    {
        //SaveVariables.gold += SaveVariables.totalTouchGold;
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
