using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Buff
{
    Null, Poison, HalfPoison, QuarterDamage, Revive
}
public class PlayerBuff : BaseSingletonWithMono<PlayerBuff>
{
    // Start is called before the first frame update
    [SerializeField] private List<Buff> buffs = new List<Buff>();
    public List<Buff> GetBuffs => buffs;
    public float DamageCaculate(float damage)
    {
        foreach (Buff buff in buffs)
        {
            // 中毒伤害减半buff
            if (buff == Buff.HalfPoison)
                return damage / 2;
            else if (buff == Buff.QuarterDamage)
                return (Random.Range(0.0f, 1.0f) < 0.25f ? 0 : damage);
        }
        return damage;
    }
    public bool CanRevive()
    {
        foreach (Buff buff in buffs)
        {
            if (buff == Buff.Revive)
                return true;
        }
        return false;
    }
    public void AddBuff(Buff buff)
    {
        buffs.Add(buff);
        CenterEvent.Instance.Raise("AddBuff");
    }
    public void AddBuff(Buff buff, int lastTime, float damagePerSecond)
    {
        if (buff == Buff.Poison)
            BePosion(lastTime, damagePerSecond);
        //添加中毒特效
        CenterEvent.Instance.Raise("AddBuff");
    }
    public void RemoveRevive()
    {
        buffs.Remove(Buff.Revive);
    }
    public void ResetBuff()
    {
        buffs.Clear();
    }
    private void BePosion(int lastTime, float damagePerSecond)
    {
        buffs.Add(Buff.Poison);
        StartCoroutine(TakePoison(lastTime, damagePerSecond));
    }
    private IEnumerator TakePoison(int lastTime, float damagePerSecond)
    {
        for (int i = 0; i < lastTime; i++)
        {
            PlayerDamage.Instance.TakeDamage(damagePerSecond);
            yield return new WaitForSeconds(1);
        }
        buffs.Remove(Buff.Poison);
        CenterEvent.Instance.Raise("AddBuff");
    }
}
