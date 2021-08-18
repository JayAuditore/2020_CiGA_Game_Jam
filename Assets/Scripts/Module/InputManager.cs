using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTypeManager
{
    public static readonly string WKeyDown = "WKeyDown";
    public static readonly string AKeyDown = "AKeyDown";
    public static readonly string DKeyDown = "DKeyDown";
    public static readonly string SKeyDown = "SKeyDown";
    public static readonly string RKeyDown = "RKeyDown";
    public static readonly string EKeyDown = "EKeyDown";
    public static readonly string TabKeyDown = "TabKeyDown";
    public static readonly string EscKeyDown = "EscKeyDown";
    public static readonly string LeftMouseDown = "LeftMouseDown";
}
public class InputManager : BaseSingleton<InputManager>
{
    private bool isListen = false;
    //构造析构时增加删除监听对象
    public InputManager()
    { 
        MonoEvent.Instance.AddUpdateEvent(InputUpdate); 
    }
    
    ~InputManager() { MonoEvent.Instance.RemoveUpdateEvent(InputUpdate); }
    //需要使用时开启监听
    public void StartListen(bool _isListen) { isListen = _isListen; }
    public void InputUpdate()
    {
        if (!isListen)
            return;
        if (Input.GetKeyDown(KeyCode.S))
            CenterEvent.Instance.Raise(KeyTypeManager.SKeyDown);
        if (Input.GetKeyDown(KeyCode.E))
            CenterEvent.Instance.Raise(KeyTypeManager.EKeyDown);
        if (Input.GetKeyDown(KeyCode.Tab))
            CenterEvent.Instance.Raise(KeyTypeManager.TabKeyDown);
        if (Input.GetKeyDown(KeyCode.Escape))
            CenterEvent.Instance.Raise(KeyTypeManager.EscKeyDown);
        if (Input.GetMouseButtonDown(0))
            CenterEvent.Instance.Raise(KeyTypeManager.LeftMouseDown);
    }
}
