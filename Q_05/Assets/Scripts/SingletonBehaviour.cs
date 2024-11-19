using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Intance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    protected void SingletonInit()
    {
        // 이미 인스턴스가 존재할 경우 신규 생성된 쪽을 제거
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }    

        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}
