using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//参考サイト http://tsubakit1.hateblo.jp/entry/20121106/1352213362
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }

            return instance;
        }

    }

    protected void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (this == Instance) { return true; }
        Destroy(this);
        return false;
    }
}
