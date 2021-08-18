using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : EnenyBase
{
    [Header("索敌距离")]
    public float followRange;
    public override void Init() //初始化
    {
        base.Init();
        ///---额外拥有的状态
        RunToAttackState = new RunToAttackState_bee();
        IdleState=new IdleState_bee();
        //AttackState = new AttackState_snake();
        // SkillState = new SkillState();

    }


    public override void AnyState()
    {

    }
    public override void MoveToTaget()
    {
        if (attackTarget)
        {
            if (Vector3.Distance(transform.position, attackTarget.position) > followRange)
            {
                attackTarget = null;
            }
        }

        if (!attackTarget)
        {
            transform.position =  Vector3.MoveTowards(transform.position, targetPoint.position, petrolSpeed * Time.deltaTime);

        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, attackTarget.position, petrolSpeed * Time.deltaTime);
        }
        FilpDirection();
    }
    public override void TouchAttack()
    {
        base.TouchAttack();
        PlayerBuff.Instance.AddBuff(Buff.Poison, 2, 1); //使得玩家中毒

    }
    public override void AttackAction()
    {

    }

    public override void SkillAttack()
    {

    }
}
