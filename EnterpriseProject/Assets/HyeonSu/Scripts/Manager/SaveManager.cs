using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private SaveVariables saveVariables;
    //���� �ʿ�
    #region ������
    void LoadJson()
    {
        string path = Path.Combine(Application.dataPath + "/SaveData.json");
        string jsonData = File.ReadAllText(path);
        saveVariables.TouchType = JsonUtility.FromJson<SaveVariables.GoodsList[]>(jsonData);
    }
    void SaveJson()
    {
        string jsonData = "";
        for (int i = 0; i < saveVariables.TouchType.Length; i++)
        {
            jsonData += JsonUtility.ToJson(saveVariables.TouchType[i]);
        }
        string path = Path.Combine(Application.dataPath + "/SaveData.json");
        File.WriteAllText(path, jsonData);
    }

    public void Combine()
    {
        //�ӽ� ������ ����� �̰� ��������
        #region �ӽ�
        saveVariables.AllSecondMoney = 0;
        saveVariables.AllTouchMonmey = 0;
        #endregion
        for (int i = 0; i < saveVariables.TouchType.Length; i++)
        {
            saveVariables.AllTouchMonmey +=
                    (ulong)(saveVariables.TouchType[i].UpgradeCost * ((ulong)saveVariables.TouchType[i].UpgradeStep / 10.0f));
        }
        for (int i = 0; i < saveVariables.SecondType.Length; i++)
        {
            saveVariables.AllSecondMoney +=
                    (ulong)(saveVariables.SecondType[i].UpgradeCost * ((ulong)saveVariables.SecondType[i].UpgradeStep / 10.0f));
        }
    }
    public IEnumerator AutoSave()
    {
        SaveJson();
        yield return new WaitForSeconds(1);
        StartCoroutine(AutoSave());
    }
    #endregion
}
