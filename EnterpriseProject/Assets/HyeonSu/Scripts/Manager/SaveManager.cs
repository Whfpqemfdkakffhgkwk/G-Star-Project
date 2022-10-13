using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    private SaveVariables saveVariables;
    //수정 필요
    #region 저장기능
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
        //임시 저장기능 만들면 이거 지워야함
        #region 임시
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
