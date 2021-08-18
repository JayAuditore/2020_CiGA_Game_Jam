using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBall : BaseAttribute
{
    static bool isEffected = false;
    public override void AddAttack()
    {
        MonoEvent.Instance.AddUpdateEvent(CanAddAttack);
    }
    void CanAddAttack()
    {
        
        var pa = PlayerAttribute.Instance.playerAttribute;
        if (pa.hp == pa.maxHP && !isEffected)
        {
            //满血且道具还未生效
            //道具恢复增益效果
            PlayerAttribute.Instance.AddAttack(attack);
            isEffected = true;
        }
        else if (pa.hp < pa.maxHP && isEffected)
        {
            //残血情况
            //道具的增益效果变为0
            PlayerAttribute.Instance.AddAttack(-attack);
            isEffected = false;
        }
    }
}
