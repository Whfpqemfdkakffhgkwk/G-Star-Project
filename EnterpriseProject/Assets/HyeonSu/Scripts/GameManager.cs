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
    #region ������
    void LoadJson()
    {
        string path = Path.Combine(Application.dataPath + "/SaveData.json");
        string jsonData = File.ReadAllText(path);
        saveVariables = JsonUtility.FromJson<SaveVariables>(jsonData);
    }
    void SaveJson()
    {
        string jsonData = JsonUtility.ToJson(saveVariables);
        string path = Path.Combine(Application.dataPath + "/SaveData.json");
        File.WriteAllText(path, jsonData);
    }
    public IEnumerator AutoSave()
    {
        SaveJson();
        yield return new WaitForSeconds(10);
        StartCoroutine(AutoSave());
    }
    #endregion  
}

[System.Serializable]
public class SaveVariables
{
    [Header("Money")]
    public ulong gold;
    [Header("Facility")]
    public int facilityUpgrade; //���׷��̵� �ܰ�
    public ulong facilityUpgradePrice; //���׷��̵� ����
    public ulong facilityUpgradePriceMagnification; //���׷��̵� ����
    [Header("Room")]
    public int roomUpgrade; //���׷��̵� �ܰ�
    public int roomUpgradePrice; //���׷��̵� ����
    public ulong roomUpgradePriceMagnification; //���׷��̵� ����
    //[Header("Teacher")]
    [Header("TotalUpgrade")]
    public ulong totalTouchGold;
}
