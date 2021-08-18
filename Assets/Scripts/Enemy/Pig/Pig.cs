using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : EnenyBase
{
    [Header("dash和獠牙伤害")]
    public float dashDamage;
    public float toothDamage;

    public float dashSpeed;
   
   // public new  bool isStop;// 撞墙或人后停下（不填）
    public override void Init() //初始化
    {
        base.Init();
        ///---额外拥有或修正的状态
        RunToAttackState = new RunToAttackState_Pig();
        AttackState = new AttackState_Pig();
        SkillState = new SkillState_Pig();

        attackDamage = dashDamage;
        skillDamage = toothDamage;
    }
  
    public override void AttackAction()//獠牙攻击
    {
        if (Vector2.Distance(transform.position, attackTarget.position) < attackRange)
        {
            if (Time.time > attackCDLeft)
            {
                TransitionToState(AttackState);
                attackCDLeft = Time.time + attackCD;
            }

        }
        //toothDamage
    }

    public override void SkillAttack()//冲刺
    {
        //dashDamage
       // Debug.Log("Distance:"+Vector2.Distance(transform.position, attackTarget.position));
        if (Vector2.Distance(transform.position, attackTarget.position) <skillRange)
        {
            if (Time.time > skillCDLeft)
            {
                TransitionToState(SkillState);
                skillCDLeft = Time.time + skillCD;

            }

        }
       
    }

    public override void SpecialMove()
    {
        Dash();
    }
     void Dash()
    {
        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, attackTarget.position.x, dashSpeed * Time.deltaTime), transform.position.y);
    }
}
