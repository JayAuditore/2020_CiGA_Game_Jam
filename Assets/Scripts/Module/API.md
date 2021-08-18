# BaseSingleton

不继承MonoBehaviour的单例脚本使用。



# BaseSingletonWithMono

继承MonoBehaviour的单例脚本使用。

# CenterEvent

作为一个单例管理模块，集各种事件于一体。接受无参与单参数的无返回值事件。

通过AddListener或AddListener<T>来添加无参数或者单参数的事件

通过RemoveListener或RemoveListener<T>来移除无参数或者单参数的事件

通过Raise或Raise<T>来调用无参数或者单参数的事件

```c#
CenterEvent.Instance.AddListener("MyEvent", myEvent);	//添加
CenterEvent.Instance.Raise("MyEvent");					//调用
```

# MonoEvent

使类虽然没有继承MonoBehaviour，但是仍可以通过往模块中添加事件，可实现Update，协程等功能

```c#
//在其他类中调用实例
MonoEvent.Instance.AddUpdateEvent(PrintHello);		//添加Update事件
MonoEvent.Instance.StartCoroutine(SayHello());		//添加协程
```

# ResourcesLoader

资源加载

```c#
//限定类型调用方法 二级路径也可以使用Cube直接读取
Resources.Load<GameObject>("Cube");
Resources.Load("Cube", typeof(GameObject));
```

# InputManager

输入管理

```c#
public class TestInput : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.StartListen(true);		//开启监听，同时若首次调用则创建单例
        CenterEvent.Instance.AddListener(KeyTypeManager.WKeyDown, GetWDown);
        CenterEvent.Instance.AddListener(KeyTypeManager.EKeyDown, Open);
    }
    public void Forward() { Debug.Log("向前走"); }
    public void Open() { Debug.Log("打开"); }
}
```

