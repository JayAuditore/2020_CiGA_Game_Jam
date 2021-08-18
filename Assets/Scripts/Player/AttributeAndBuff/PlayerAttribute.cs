using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class PlayerAttribute : BaseSingletonWithMono<PlayerAttribute>
{
    [SerializeField] private BaseAttribute attribute;

    //玩家初始生命值等数据，用于重新开始时重置
    private BaseAttribute originData;
    public BaseAttribute playerAttribute => attribute;
    private void Start()
    {
        originData = attribute;
    }
    public void ResetAttribute()
    {
        attribute = originData;
        CenterEvent.Instance.Raise("AddBlood");
    }
    //主角自身的属性
    public void AddHp(float _hp)
    {
        //每次增减生命时检测部分道具是否能生效
        attribute.hp += Mathf.Clamp(_hp, -Mathf.Infinity, attribute.maxHP - attribute.hp);
        CenterEvent.Instance.Raise("AddBlood");
        if (attribute.hp <= 0)
        {
            if (PlayerBuff.Instance.CanRevive())
            {
                attribute.hp = attribute.maxHP;
                PlayerBuff.Instance.RemoveRevive();
            }
            else
                CenterEvent.Instance.Raise("PlayerDead");
        }
    }
    public void AddSpeed(float _speed)
    {
        PlayerMove.Instance.AddImproveSpeed(_speed);
        attribute.speed += _speed;
    }
    public void AddAttack(float _attack)
    {
        attribute.attack += _attack;
        CenterEvent.Instance.Raise("AddAttack");
    }
    public void AddMaxHp(float _maxHp)
    {
        attribute.maxHP += _maxHp;
    }
}