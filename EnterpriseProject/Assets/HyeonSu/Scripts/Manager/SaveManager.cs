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
    //���� �ʿ�

    private void Start()
    {
        LoadJson();
    }

    #region ������
    void LoadJson()
    {
        saveVariables = new SaveVariables();
        string path = "Assets/Resources/save.json";
        string jsonData = File.ReadAllText(path);
        saveVariables = JsonUtility.FromJson<SaveVariables>(jsonData);
    }
    void SaveJson()
    {
        string path = "Assets/Resources/save.json";
        string jsonData = JsonUtility.ToJson(saveVariables, true);
        Debug.Log(jsonData);
        File.WriteAllText(path, jsonData);
        
    }

    public void Combine()
    {
        for (int i = 0; i < saveVariables.TouchType.Length; i++)
        {
            saveVariables.AllTouchMonmey +=
                    (ulong)(saveVariables.TouchType[i].UpgradeStep * 3) * (ulong)(i + 1) *
                    10 * saveVariables.ItemMultiply; //�� 10�� ����Ÿ�� �ν���;
        }
        for (int i = 0; i < saveVariables.SecondType.Length; i++)
        {
            saveVariables.AllSecondMoney +=
                    (ulong)saveVariables.SecondType[i].UpgradeStep * 10 * (ulong)(i + 1) *
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
