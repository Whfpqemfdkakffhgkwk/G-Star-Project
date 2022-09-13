using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveVariables saveVariables;

    private void Awake()
    {
        LoadJson(); 
        StartCoroutine(AutoSave());
    }
    #region 저장기능
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
        yield return new WaitForSeconds(30);
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
    public int facilityUpgrade; //업그레이드 단계
    public ulong facilityUpgradePrice; //업그레이드 가격
    public ulong facilityUpgradePriceMagnification; //업그레이드 배율
    [Header("Room")]
    public int roomUpgrade; //업그레이드 단계
    public int roomUpgradePrice; //업그레이드 가격
    public ulong roomUpgradePriceMagnification; //업그레이드 배율
    [Header("Teacher")]
    public int TeacherUpgrade1;
    public int TeacherUpgrade2;
    public int TeacherUpgrade3; 
    public int TeacherUpgrade4; 
    public int TeacherUpgrade5; 
    public int TeacherUpgrade6;
}
