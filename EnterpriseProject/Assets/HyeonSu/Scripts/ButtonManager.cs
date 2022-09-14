using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class ButtonManager : MonoBehaviour
{
    Vector2 OnPos = new Vector2(0, 0), OffPos = new Vector2(0, -3000);

    [SerializeField] private GameObject TouchWindow;
    
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
        Window.transform.DOLocalMove(OnPos, 0.75f);
    }
    //â ������ ����
    void CloseProduction(GameObject Window)
    {
        Window.transform.DOLocalMove(OffPos, 0.75f);
    }
}
