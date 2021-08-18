using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToAttackState_FF : EnemyBaseState//2-runToAttack
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

        enemy.SpecialMove();

        if (Mathf.Abs(enemy.attackTarget.position.x - enemy.transform.position.x) < enemy.attackRange)
        {
            enemy.AttackAction();
        }
        
    }
}

public class AttackState_FF : EnemyBaseState//3-Attack,直拳   攻击
{

    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 3;
    }

    public override void UpdateState(EnenyBase enemy)
    {

        if (enemy.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {

            enemy.TransitionToState(enemy.RunToAttackState);
        }
    }
}


    