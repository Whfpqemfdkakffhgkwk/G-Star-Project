using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainClickButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ButtonManager buttonManager;
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonManager.MainClick();
    }
}
