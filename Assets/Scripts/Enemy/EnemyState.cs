

using UnityEngine;

public interface IBaseState
{
     void EnterState(EnenyBase gameobject);
     void UpdateState(EnenyBase gameobject);
}
//________________敌人共有的状态_____________________
public abstract class EnemyBaseState :IBaseState//敌人的抽象状态
{

    public abstract void EnterState(EnenyBase enemy);
    

    public abstract void UpdateState(EnenyBase enemy);
}

//敌人的具体的状态
public class IdleState : EnemyBaseState//0-idle
{
    public  override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 0;
        enemy.SwitchPoint();
    }

    public override void UpdateState(EnenyBase enemy)
    {
        if (enemy.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
           
            enemy.TransitionToState(enemy.PatrolState);
        }

    }
}
public class PatrolState : EnemyBaseState//1-petrol
{
    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 1;
    }

    public override void UpdateState(EnenyBase enemy)
    {
        enemy.MoveToTaget();//2.移动到目标点
        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x) < 0.01f) //对于巡逻状态，当到达目标点时
        {


            enemy.TransitionToState(enemy.IdleState);//进入idle
        }

        if (enemy.attackTarget)//如果存在玩家
        {
            enemy.TransitionToState(enemy.RunToAttackState);//进入RunToAttack
        }
    }

}


public class RunToAttackState : EnemyBaseState//2-runToAttack
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

    }
}


public class AttackState : EnemyBaseState//3-Attack
{

    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 3;
    }

    public override void UpdateState(EnenyBase enemy)
    {

    }
}


public class SkillState : EnemyBaseState//4-skill
{
    public override void EnterState(EnenyBase enemy)
    {
        enemy.state_num = 4;
    }

    public override void UpdateState(EnenyBase enemy)
    {

    }
}


