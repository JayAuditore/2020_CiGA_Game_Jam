using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : BaseAttribute
{
    static bool isEffected = false;
    [SerializeField] private float existTime = 10.0f;
    public override void AddAttack()
    {
        base.AddAttack();
        Invoke("Timeout", existTime);
    }
    void Timeout()
    {
        PlayerAttribute.Instance.AddAttack(-attack);
    }
}
