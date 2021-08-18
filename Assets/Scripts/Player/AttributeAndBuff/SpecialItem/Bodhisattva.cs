using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodhisattva : BaseAttribute
{
    static bool isEffected = false;
    [SerializeField] private float lowHp = 5.0f;
    public override void AddAttack()
    {
        MonoEvent.Instance.AddUpdateEvent(CanAddAttack);
    }
    void CanAddAttack()
    {
        
        var pa = PlayerAttribute.Instance.playerAttribute;
        if (pa.hp <= lowHp && !isEffected)
        {
            //满血且道具还未生效
            //道具恢复增益效果
            PlayerAttribute.Instance.AddAttack(attack);
            isEffected = true;
        }
        else if (pa.hp > lowHp && isEffected)
        {
            //残血情况
            //道具的增益效果变为0
            PlayerAttribute.Instance.AddAttack(-attack);
            isEffected = false;
        }
    }
}
