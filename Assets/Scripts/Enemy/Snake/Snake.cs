using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake :  EnenyBase
{
   
    public override void Init() //初始化
    {
        base.Init();
        ///---额外拥有的状态
        RunToAttackState = new RunToAttackState_snake();
        AttackState = new AttackState_snake();
    }


    public override void AnyState()
    {
        
    }

    public override void TouchAttack()
    {
        base.TouchAttack();
        PlayerBuff.Instance.AddBuff(Buff.Poison, 2, 1); //使得玩家中毒
    }


}
