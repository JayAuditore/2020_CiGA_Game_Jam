using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseAttribute : MonoBehaviour
{
    public float hp;
    public float speed;
    public float attack;
    public float maxHP;
    public virtual void Add()
    {
        AddHP();
        AddSpeed();
        AddAttack();
        AddMaxHp();
    }
    public virtual void AddHP() { PlayerAttribute.Instance.AddHp(hp); }
    public virtual void AddSpeed() { PlayerAttribute.Instance.AddSpeed(speed); }
    public virtual void AddAttack() { PlayerAttribute.Instance.AddAttack(attack); }
    public virtual void AddMaxHp() { PlayerAttribute.Instance.AddMaxHp(maxHP); }
}

