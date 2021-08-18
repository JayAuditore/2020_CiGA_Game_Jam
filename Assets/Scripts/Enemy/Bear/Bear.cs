using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Bear : EnenyBase
{
    [Header("技能（跳跃AOE）伤害和拍打伤害")]
    public float jumpDamage;
    public float fistDamage;
    public float jumpForceY, jumpForceX;

    



    private Collider2D collider;
    private Rigidbody2D rb;
    [Header("地面检测")]
    public Transform groundCheck;
    
   
    

    // public new  bool isStop;// 撞墙或人后停下（不填）
    public override void Init() //初始化
    {
        base.Init();
        ///---额外拥有或修正的状态
        RunToAttackState = new RunToAttackState_Bear();
        AttackState = new AttackState_Bear();
        SkillState=new SkillState_Bear();

        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        attackDamage = fistDamage;
        skillDamage = jumpDamage;
    }
   

    public override void AttackAction()//直拳fist攻击
    {
       // Debug.Log("distance:"+Vector2.Distance(transform.position, attackTarget.position));
        if (Vector2.Distance(transform.position, attackTarget.position) < attackRange)
        {
            if (Time.time > attackCDLeft)
            {
                TransitionToState(AttackState);
                attackCDLeft = Time.time + attackCD;
            }

        }

    }
    public override void SkillAttack()//跳跃Aoe攻击
    {
        
        if (Vector2.Distance(transform.position, attackTarget.position) < skillRange)
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
        
        Jump();
        
    }
    void Jump()
    {
        isGround = false;
       
        // collider.enabled = false;
        rb.AddForce(Vector2.up * jumpForceY, ForceMode2D.Impulse);
        rb.AddForce(Vector2.right * jumpForceX * faceTo, ForceMode2D.Impulse);

        //StartCoroutine(jumpForSeconds());
    }
    

  


}