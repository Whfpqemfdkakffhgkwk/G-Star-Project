using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static SaveVariables;

public class SaveManager : Singleton<SaveManager>
{
    public SaveVariables saveVariables;
    string path;

    private void Start()
    {
        path = Application.persistentDataPath + "/save.json";
        print(path);
        LoadJson();
        saveVariables.ItemMultiply = 1f;
    }

    #region 저장기능
    void LoadJson()
    {
        if (!File.Exists(path)) { ResetFile(); return; }
        saveVariables = new SaveVariables();
        var jsonData = File.ReadAllText(path);
        saveVariables = JsonUtility.FromJson<SaveVariables>(jsonData);
    }
    void SaveJson()
    {
        var jsonData = JsonUtility.ToJson(saveVariables, true);
        File.WriteAllText(path, jsonData);
        
    }
    void ResetFile()
    {
        var a = Resources.Load<TextAsset>("save");
        saveVariables = JsonUtility.FromJson<SaveVariables>(a.ToString());

        SaveJson();
        LoadJson();
    }
    //public void Combine()
    //{
    //    for (int i = 0; i < saveVariables.TouchType.Length; i++)
    //    {
    //        saveVariables.AllTouchMonmey +=
    //                (ulong)(saveVariables.TouchType[i].UpgradeStep * 2.7f) * (ulong)(i + 1) *
    //                10 * saveVariables.ItemMultiply; //이 10은 지스타용 부스터;
    //    }
    //    for (int i = 0; i < saveVariables.SecondType.Length; i++)
    //    {
    //        saveVariables.AllSecondMoney +=
    //                (ulong)saveVariables.SecondType[i].UpgradeStep * 24 * (ulong)(i + 1) *
    //                10; //이 10은 지스타용 부스터;
    //    }
    //}
    //public void AllGoodPlus(GoodsList[] list, int arrayNum)
    //{
    //    if(list == saveVariables.TouchType)
    //    {
    //        saveVariables.AllTouchMonmey +=
    //                (ulong)(list[arrayNum].UpgradeStep * 3) * (ulong)(arrayNum + 1) *
    //                10 * saveVariables.ItemMultiply; //이 10은 지스타용 부스터;
    //    }
    //    else if(list == saveVariables.SecondType)
    //    {
    //        saveVariables.AllSecondMoney +=
    //                (ulong)list[arrayNum].UpgradeStep * 10 * (ulong)(arrayNum + 1) *
    //                10; //이 10은 지스타용 부스터;
    //    }
    //}
    public IEnumerator AutoSave()
    {
        SaveJson();
        yield return new WaitForSeconds(1);
        StartCoroutine(AutoSave());
    }
    #endregion
}
