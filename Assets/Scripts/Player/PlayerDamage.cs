using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : BaseSingletonWithMono<PlayerDamage>
{

    private Animator animator;
    [SerializeField] private SwardJudge swardJudge;

    private Coroutine attackIE;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        CenterEvent.Instance.AddListener("PlayerDead", PlayerDead);
        CenterEvent.Instance.AddListener("PlayerReborn", PlayerReborn);

        InputManager.Instance.StartListen(true);
        CenterEvent.Instance.AddListener(KeyTypeManager.LeftMouseDown, Attack);
    }
    private void OnDestroy() 
    {
        CenterEvent.Instance.RemoveListener("PlayerDead", PlayerDead);
        CenterEvent.Instance.RemoveListener("PlayerReborn", PlayerReborn);
    }
    private void Attack()
    {
        //播放动画
        if (attackIE == null)
            attackIE = StartCoroutine(AttackAnimation());
            
    }
    private IEnumerator AttackAnimation()
    {
        animator.SetBool("Attack", true);
        swardJudge.gameObject.SetActive(true);
        while (true)
        {
            yield return null;
            var info = animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("AttackLayer"));
            if (info.IsName("mc_attack") && info.normalizedTime > 0.6f)
            {
                animator.SetBool("Attack", false);
                swardJudge.gameObject.SetActive(false);
                break;
            }
        }
        attackIE = null;
    }
    public void TakeDamage(float damage)
    {
        float calDamage = PlayerBuff.Instance.DamageCaculate(damage);
        //扣血，数值为负
        PlayerAttribute.Instance.AddHp(-calDamage);
    }
    public void PlayerDead()
    {
        Debug.Log("玩家死亡");
        CG.Instance.CgBool();
    }

    public void PlayerReborn()
    {
        Debug.Log("玩家重新开始");
        //重设玩家属性值
        PlayerAttribute.Instance.ResetAttribute();
        PlayerBuff.Instance.ResetBuff();
    }
}
