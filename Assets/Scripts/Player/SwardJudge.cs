using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public class SwardJudge : MonoBehaviour
{
    private CapsuleCollider2D collider2d;

    private void Start()
    {
        collider2d = GetComponent<CapsuleCollider2D>();
        collider2d.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.layer.Equals(LayerMask.NameToLayer("Monster")))
            return;
        Debug.Log("Attack");
        other.gameObject.TryGetComponent<EnenyBase>(out EnenyBase monster);
        monster?.GetDamage(PlayerAttribute.Instance.playerAttribute.attack);
    }
}
