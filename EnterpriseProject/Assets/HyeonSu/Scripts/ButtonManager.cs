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
