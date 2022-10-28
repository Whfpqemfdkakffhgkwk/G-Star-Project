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
        saveManager.Combine();
        StartCoroutine(saveManager.AutoSave());
    }
}

