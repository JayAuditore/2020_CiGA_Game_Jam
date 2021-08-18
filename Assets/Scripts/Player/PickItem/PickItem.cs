using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class PickItem : MonoBehaviour
{   
    [SerializeField] private Item item;
    private BaseAttribute attribute;
    private SpriteRenderer sprite;
    private BoxCollider2D collider2d;
    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<BoxCollider2D>();
        attribute = GetComponent<BaseAttribute>();

        collider2d.isTrigger = true;
        sprite.sprite = item.sprite;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("pengzhuang");
        //检测到玩家碰撞
        if (other.gameObject.layer==LayerMask.NameToLayer("Player"))
        {
            //产生效果
            item.attribute.Add();
            //Buff效果
            if (item.buff != Buff.Null)
                PlayerBuff.Instance.AddBuff(item.buff);
            //添加进背包
            BackPack.Instance.AddItem(item);
            //隐藏or销毁？
            gameObject.SetActive(false);
        }
    }
}
