using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance = null;

    protected virtual void Awake()
    {
        T t;
        t = FindObjectOfType(typeof(T)) as T;
        if (null == Instance)
        {
            Instance = t;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
