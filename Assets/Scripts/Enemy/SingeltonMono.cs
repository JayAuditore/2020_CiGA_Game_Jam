using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingeltonMono<T> : MonoBehaviour where T : new()
{
    // Start is called before the first frame update
    private static T instance;

    public T GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null)
        {
            instance=new T();
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
}
