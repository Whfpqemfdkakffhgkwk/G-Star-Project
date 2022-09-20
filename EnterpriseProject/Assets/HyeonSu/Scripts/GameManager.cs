using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>                           
{
    public SaveVariables saveVariables;

    private void Awake()
    {
        LoadJson(); 
        StartCoroutine(AutoSave());
    }
    //수정 필요
    #region 저장기능
    void LoadJson()
    {
        string path = Path.Combine(Application.dataPath + "/SaveData.json");
        string jsonData = File.ReadAllText(path);
        saveVariables.upgradeType = JsonUtility.FromJson<SaveVariables.UpgradeType[]>(jsonData);
    }
    void SaveJson()
    {
        string jsonData = "";
        for (int i = 0; i < saveVariables.upgradeType.Length; i++)
        {
            jsonData += JsonUtility.ToJson(saveVariables.upgradeType[i]);
        }
        string path = Path.Combine(Application.dataPath + "/SaveData.json");
        File.WriteAllText(path, jsonData);
    }
    public IEnumerator AutoSave()
    {
        SaveJson();
        yield return new WaitForSeconds(1);
        StartCoroutine(AutoSave());
    }
    #endregion
}

