using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MonoEvent : BaseSingletonWithMono<MonoEvent>
{
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    private UnityAction UpdateEvent;
    private void Update()
    {
        if (UpdateEvent == null)
        {
            return;
        }
        UpdateEvent.Invoke();
    }
    public void AddUpdateEvent(UnityAction _action) { UpdateEvent += _action; }
    public void RemoveUpdateEvent(UnityAction _action) { UpdateEvent -= _action; }
}
