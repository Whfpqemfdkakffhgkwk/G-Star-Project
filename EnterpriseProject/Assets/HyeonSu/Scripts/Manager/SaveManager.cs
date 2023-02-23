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

    private void Start()
    {
        LoadJson();
        saveVariables.ItemMultiply = 1f;
    }

    #region ������
    void LoadJson()
    {
        saveVariables = new SaveVariables();
        string path = Application.persistentDataPath + "/save.json";
        string jsonData = File.ReadAllText(path);
        saveVariables = JsonUtility.FromJson<SaveVariables>(jsonData);
    }
    void SaveJson()
    {
        string jsonData = JsonUtility.ToJson(saveVariables, true);
        File.WriteAllText(Application.persistentDataPath + "/save.json", jsonData);
        
    }

    public void Combine()
    {
        for (int i = 0; i < saveVariables.TouchType.Length; i++)
        {
            saveVariables.AllTouchMonmey +=
                    (ulong)(saveVariables.TouchType[i].UpgradeStep * 2.7f) * (ulong)(i + 1) *
                    10 * saveVariables.ItemMultiply; //�� 10�� ����Ÿ�� �ν���;
        }
        for (int i = 0; i < saveVariables.SecondType.Length; i++)
        {
            saveVariables.AllSecondMoney +=
                    (ulong)saveVariables.SecondType[i].UpgradeStep * 24 * (ulong)(i + 1) *
                    10; //�� 10�� ����Ÿ�� �ν���;
        }
    }
    public void AllGoodPlus(GoodsList[] list, int arrayNum)
    {
        if(list == saveVariables.TouchType)
        {
            saveVariables.AllTouchMonmey +=
                    (ulong)(list[arrayNum].UpgradeStep * 3) * (ulong)(arrayNum + 1) *
                    10 * saveVariables.ItemMultiply; //�� 10�� ����Ÿ�� �ν���;
        }
        else if(list == saveVariables.SecondType)
        {
            saveVariables.AllSecondMoney +=
                    (ulong)list[arrayNum].UpgradeStep * 10 * (ulong)(arrayNum + 1) *
                    10; //�� 10�� ����Ÿ�� �ν���;
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
