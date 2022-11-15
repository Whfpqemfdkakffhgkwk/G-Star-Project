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
        //�ӽ� ������ ����� �̰� ��������
        #region �ӽ�
        saveManager.saveVariables.AllSecondMoney = 0;
        saveManager.saveVariables.AllTouchMonmey = 0;
        #endregion
        saveManager.Combine();
        StartCoroutine(saveManager.AutoSave());
    }
}

