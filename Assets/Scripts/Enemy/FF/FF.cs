using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FF : EnenyBase
{
    [Header("技能（跳跃【无伤害】）和直拳伤害")]
    
    public float fistDamage;
    public float jumpForce;

   

   

    private Rigidbody2D rb;
    [Header("地面检测")]
    public Transform groundCheck;
   // [Header("调试")]
    public bool isJump;
  

    // public new  bool isStop;// 撞墙或人后停下（不填）
    public override void Init() //初始化
    {
        base.Init();
        ///---额外拥有或修正的状态
        RunToAttackState = new RunToAttackState_FF();
        AttackState = new AttackState_FF();
        

        rb = GetComponent<Rigidbody2D>();

        attackDamage = fistDamage;
      

    }
 

    public override void AttackAction()//直拳fist攻击
    {
        if (Vector2.Distance(transform.position, attackTarget.position) < attackRange)
        {
            if (Time.time > attackCDLeft)
            {
                TransitionToState(AttackState);
                attackCDLeft = Time.time + attackCD;
            }

        }
        
    }

 

    public override void SpecialMove()
    {
        MoveToTaget();
       
        if (PlayerMove.Instance.OnJump&& isGround)//————————————————————————————————————————————//需要修改，如果玩家起跳且自身不在空中，则ff也起跳
        {
            Jump();
            isGround = false;
        }


    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        rb.gravityScale = 3f;
    }
  
  
}
