using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer1, timer2, time3;
    Transform parentGameObject, grandPaTransform;
    void Start()
    {
        parentGameObject = transform.parent;
        grandPaTransform = parentGameObject.parent;
        timer1 = timer2 = time3 = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer1 == -1)
        {
            timer1 = Time.time;
        }
        


    }

    //public void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (timer1 + 1 - Time.time < 0.1f)//1秒后
    //    {
    //        if (collision.CompareTag("Player") && gameObject.name == "touchHitPoint" &&
    //            !grandPaTransform.GetComponent<EnenyBase>().anim.GetCurrentAnimatorStateInfo(0).IsName("attack") &&
    //            !grandPaTransform.GetComponent<EnenyBase>().anim.GetCurrentAnimatorStateInfo(0).IsName("skill"))
    //        {
    //            grandPaTransform.GetComponent<EnenyBase>().TouchAttack();

    //            Debug.Log("touch Attack"); //在.TouchAttack();补充伤害玩家代码

    //            timer1 = -1;
    //        }

    //        ///临时方案解决bugk
    //        else if (collision.CompareTag("Player") && gameObject.name == "touchHitPoint" &&( grandPaTransform.name == "Snake_body"||grandPaTransform.name == "wolf_body"|| grandPaTransform.name == "Bee_body"))//
    //        {
    //            grandPaTransform.GetComponent<EnenyBase>().TouchAttack();
    //            Debug.Log("Snake touch Attack"); //在.TouchAttack();补充伤害玩家代码
    //            timer1 = -1;
    //        }

    //        else if (collision.CompareTag("Player") && gameObject.name == "attackHitPoint")
    //        {
    //            PlayerDamage.Instance.TakeDamage(grandPaTransform.GetComponent<EnenyBase>().attackDamage);


    //            Debug.Log("attack Attack");
    //            //在此补充代码让玩家扣血
    //            timer1 = -1;
    //        }
    //        else if (collision.CompareTag("Player") && gameObject.name == "skillHitPoint")
    //        {
    //            PlayerDamage.Instance.TakeDamage(grandPaTransform.GetComponent<EnenyBase>().skillDamage);

    //            Debug.Log("skill Attack");
    //            //在此补充代码让玩家扣血
    //            timer1 = -1;
    //        }

    //    }
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.name == "touchHitPoint" && !grandPaTransform.GetComponent<EnenyBase>().anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && !grandPaTransform.GetComponent<EnenyBase>().anim.GetCurrentAnimatorStateInfo(0).IsName("skill"))
        {
            grandPaTransform.GetComponent<EnenyBase>().TouchAttack();

            Debug.Log("touch Attack");//在.TouchAttack();补充伤害玩家代码

        }
        ///临时方案解决bug
        else if (collision.CompareTag("Player") && gameObject.name == "touchHitPoint" && grandPaTransform.name == "Snake_body")
        {
            grandPaTransform.GetComponent<EnenyBase>().TouchAttack();
            Debug.Log("Snake touch Attack");//在.TouchAttack();补充伤害玩家代码

        }

        else if (collision.CompareTag("Player") && gameObject.name == "attackHitPoint")
        {
            PlayerDamage.Instance.TakeDamage(grandPaTransform.GetComponent<EnenyBase>().attackDamage);


            Debug.Log("attack Attack");
            //在此补充代码让玩家扣血
        }
        else if (collision.CompareTag("Player") && gameObject.name == "skillHitPoint")
        {
            PlayerDamage.Instance.TakeDamage(grandPaTransform.GetComponent<EnenyBase>().skillDamage);

            Debug.Log("skill Attack");
            //在此补充代码让玩家扣血

        }

    }

}
