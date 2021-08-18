
using UnityEngine;

public class RunToAttackState_snake : EnemyBaseState//2-runToAttack，普通追人
{
    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 2;
    }

    public override void UpdateState(EnenyBase enemy)
    {
        if (!enemy.attackTarget)//如果不存在玩家
        {
            enemy.TransitionToState(enemy.IdleState);//进入Idle
        }

        enemy.MoveToTaget();
        if (Mathf.Abs(enemy.attackTarget.position.x - enemy.transform.position.x)< 5)
        {
            enemy.TransitionToState(enemy.AttackState);//进入AttackStates
        }
    }
}
public class AttackState_snake : EnemyBaseState//3-Attack,伸头追人
{
    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 3;
    }

    public override void UpdateState(EnenyBase enemy)
    {
       

        enemy.MoveToTaget();
        if (Mathf.Abs(enemy.attackTarget.position.x - enemy.transform.position.x) >10)
        {
            enemy.TransitionToState(enemy.RunToAttackState);//进入RunToAttackState
        }
    }
}