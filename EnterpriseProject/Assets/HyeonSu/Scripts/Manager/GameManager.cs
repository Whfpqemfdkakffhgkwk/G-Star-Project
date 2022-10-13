using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>                           
{
    [SerializeField]
    private ButtonManager buttonManager;
    [SerializeField]
    private SaveManager saveManager;

    private void Awake()
    {
        saveManager.Combine();
        StartCoroutine(saveManager.AutoSave());
        StartCoroutine(buttonManager.MainSecond());
    }
}

