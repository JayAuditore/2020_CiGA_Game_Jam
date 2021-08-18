using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResourcesLoader : BaseSingleton<ResourcesLoader>
{
    private Hashtable resCache;
    public ResourcesLoader()
    {
        resCache = new Hashtable();
    }
    public T Load<T>(string objectPath, bool isCache = false) where T : UnityEngine.Object
    {
        T res = null;
        if (resCache.ContainsKey(objectPath))
            res = resCache[objectPath] as T; 
        else
        {
            res = Resources.Load<T>(objectPath);
            if (isCache)
                resCache.Add(objectPath, res);
        }
        if (res is GameObject)
            return GameObject.Instantiate(res);
        else
            return res;
    }
    public void LoadAsync<T>(string objectPath, UnityAction<T> callBack) where T : UnityEngine.Object
    {
        MonoEvent.Instance.StartCoroutine(IEload<T>(objectPath, callBack));
    }
    private IEnumerator IEload<T>(string Path, UnityAction<T> callBack) where T : UnityEngine.Object
    {
        ResourceRequest res = Resources.LoadAsync<T>(Path);
        yield return null;
        //资源动态加载完毕之后调用回调
        if (res.asset is GameObject)
            callBack(GameObject.Instantiate(res.asset) as T);
        else
            callBack(res.asset as T);
    }
}

