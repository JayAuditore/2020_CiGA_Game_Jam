using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseSingletonWithMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            //可能已经挂载到场景中，先查找
            if (instance == null)
                instance = FindObjectOfType<T>();
            //查找不到，则自行创建一个
            if (instance == null)
            {
                GameObject obj = new GameObject(typeof(T).ToString());
                instance = obj.AddComponent<T>();
            }
            return instance;
        }
    }
}
