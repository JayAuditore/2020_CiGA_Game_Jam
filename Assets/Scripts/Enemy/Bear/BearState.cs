using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToAttackState_Bear : EnemyBaseState//2-runToAttack
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

        if (enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("runToAttack"))
        {
            enemy.MoveToTaget();
        }
       
        if (Mathf.Abs(enemy.attackTarget.position.x - enemy.transform.position.x) < enemy.attackRange&& !enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("skill"))
        {
            enemy.AttackAction();
        }
        if (Mathf.Abs(enemy.attackTarget.position.x - enemy.transform.position.x) < enemy.skillRange && !enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            enemy.SkillAttack();
        }
    }
}

public class AttackState_Bear : EnemyBaseState//3-Attack,直拳fist攻击
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


public class SkillState_Bear : EnemyBaseState//4-skill
{
    bool bool_1;
    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 4;
        bool_1 = false;
    }

    public override void UpdateState(EnenyBase enemy)
    {
        if (enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("skill"))
        {
            
            if (!bool_1)
            {
                enemy.SpecialMove();
                bool_1 = true;
            }
           

            if (enemy.isGround)
            {

                enemy.TransitionToState(enemy.RunToAttackState);
                enemy.isStop = false;
            }

        }
    }
}
