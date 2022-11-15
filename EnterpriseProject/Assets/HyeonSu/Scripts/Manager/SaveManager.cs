using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static SaveVariables;

public class SaveManager : Singleton<SaveManager>
{
    public SaveVariables saveVariables;
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
        for (int i = 0; i < saveVariables.TouchType.Length; i++)
        {
            saveVariables.AllTouchMonmey +=
                    (ulong)(saveVariables.TouchType[i].UpgradeStep * 3) * (ulong)(i + 1) *
                    10; //이 10은 지스타용 부스터;
        }
        for (int i = 0; i < saveVariables.SecondType.Length; i++)
        {
            saveVariables.AllSecondMoney +=
                    (ulong)saveVariables.SecondType[i].UpgradeStep * 10 * (ulong)(i + 1) *
                    10; //이 10은 지스타용 부스터;
        }
    }
    public void AllGoodPlus(GoodsList[] list, int arrayNum)
    {
        if(list == saveVariables.TouchType)
        {
            saveVariables.AllTouchMonmey +=
                    (ulong)(list[arrayNum].UpgradeStep * 3) * (ulong)(arrayNum + 1) *
                    10; //이 10은 지스타용 부스터;
        }
        else if(list == saveVariables.SecondType)
        {
            saveVariables.AllSecondMoney +=
                    (ulong)list[arrayNum].UpgradeStep * 10 * (ulong)(arrayNum + 1) *
                    10; //이 10은 지스타용 부스터;
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
