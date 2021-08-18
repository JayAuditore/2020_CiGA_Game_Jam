using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToAttackState_Pig : EnemyBaseState//2-runToAttack
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
      
        if (Mathf.Abs(enemy.attackTarget.position.x - enemy.transform.position.x) < enemy.attackRange)
        {
            enemy.AttackAction();
        }
        if (Mathf.Abs(enemy.attackTarget.position.x - enemy.transform.position.x) < enemy.skillRange && enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("runToAttack"))
        {
            enemy.SkillAttack();
        }
    }
}

public class AttackState_Pig : EnemyBaseState//3-Attack,獠牙攻击
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


public class SkillState_Pig : EnemyBaseState//4-skill
{
    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 4;
        
    }

    public override void UpdateState(EnenyBase enemy)
    {
        if (enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("skill"))
        {
            enemy.SpecialMove();
            
            if (enemy.isStop)
            {
              
                enemy.TransitionToState(enemy.RunToAttackState);
                enemy.isStop = false;
            }
              
        }
    }
}