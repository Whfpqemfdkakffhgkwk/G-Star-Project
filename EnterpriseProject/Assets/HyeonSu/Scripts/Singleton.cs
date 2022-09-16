using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                {
                    GameObject gameObject = new GameObject(typeof(T).Name);
                    instance = gameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}
