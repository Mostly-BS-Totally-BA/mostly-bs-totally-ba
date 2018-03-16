using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected Singleton() { }
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();
            else if (instance != FindObjectOfType<T>())
                Destroy(FindObjectOfType<T>());

            DontDestroyOnLoad(FindObjectOfType<T>());

            return instance;
        }
    }

}

/*
public static GameManager Instance
{
    get
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
    }
}*/