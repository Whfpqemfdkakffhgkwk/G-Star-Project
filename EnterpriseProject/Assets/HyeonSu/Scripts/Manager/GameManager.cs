using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>                           
{
    [SerializeField]
    private SaveManager saveManager;

    void Start()
    {
        //임시 저장기능 만들면 이거 지워야함
        #region 임시
        saveManager.saveVariables.AllSecondMoney = 0;
        saveManager.saveVariables.AllTouchMonmey = 0;
        #endregion
        saveManager.Combine();
        StartCoroutine(saveManager.AutoSave());
    }
}

