using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState_bee : EnemyBaseState//0-idle
{
    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 0;
        enemy.SwitchPoint();
    }

    public override void UpdateState(EnenyBase enemy)
    {
        if (enemy.attackTarget)//如果存在玩家
        {
            enemy.TransitionToState(enemy.RunToAttackState);//进入RunToAttack
        }

    }
}
public class RunToAttackState_bee: EnemyBaseState//2-runToAttack
{
    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 2;
    }

    public override void UpdateState(EnenyBase enemy)
    {
        if (!enemy.attackTarget)//如果不存在玩家//——————————————————————待修改，改为超出一定距离
        {
            enemy.TransitionToState(enemy.IdleState);//进入Idle
        }

        enemy.MoveToTaget();
        //if (Mathf.Abs(enemy.attackTarget.position.x - enemy.transform.position.x) < 5)
        //{
        //    enemy.TransitionToState(enemy.AttackState);//进入AttackStates
        //}
    }
}
