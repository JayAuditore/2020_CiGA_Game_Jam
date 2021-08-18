using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackPack : BaseSingletonWithMono<BackPack>
{
    public GameObject backPack;
    public GameObject menu;

    public Slider slider;

    public Text life;
    public Text attack;
    public Text state;
    public Text Att;

    public List<Item> item = new List<Item>();
    public GameObject[] slots;

    private void Awake()
    {
        InputManager.Instance.StartListen(true);
        CenterEvent.Instance.AddListener(KeyTypeManager.TabKeyDown, DisPlayerBP);
        CenterEvent.Instance.AddListener(KeyTypeManager.EscKeyDown, DisPlayerM);

        CenterEvent.Instance.AddListener("AddBlood", BPAddBlood);
        CenterEvent.Instance.AddListener("AddAttack", BPAddAttack);
        CenterEvent.Instance.AddListener("AddBuff", BPAddBuff);
        DontDestroyOnLoad(gameObject.transform.parent.gameObject);
    }

    void Start()
    {
        DisPlayerItems();
        StateChage();
    }

    private void DisPlayerItems()
    {
        for (int i = 0; i < item.Count; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = item[i].sprite;
        }
        for (int i = item.Count; i < slots.Length; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
        }
        //StateChage(PlayerAttribute.Instance.playerAttribute.hp, PlayerAttribute.Instance.playerAttribute.attack, (isPoison ? "中毒" : "正常"));
    }
    private void BPAddBlood()
    {
        life.text = "生命值：" + PlayerAttribute.Instance.playerAttribute.hp;
    }
    private void BPAddAttack()
    {
        attack.text = "攻击力：" + PlayerAttribute.Instance.playerAttribute.attack;
    }
    private void BPAddBuff()
    {
        string isPoison = PlayerBuff.Instance.GetBuffs.Contains(Buff.Poison) ? "中毒" : "正常";
        state.text = $"状态: {isPoison}";
    }
    public void StateChage()
    {
        life.text = $"生命值：{PlayerAttribute.Instance.playerAttribute.hp}";
        attack.text = $"攻击力：{PlayerAttribute.Instance.playerAttribute.attack}";
        state.text = "状态: 正常";
    }

    public void StateChage(float lives, float attacks, string _state)
    {
        life.text = "生命值：" + lives;
        attack.text = "攻击力：" + attacks;
        state.text = "状态:" + _state;
    }



    public int Item_Story()
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].type == 1)
            {
                int id = item[i].type_story;
                item.Remove(item[i]);
                DisPlayerItems();
                return id;
            }
        }
        return 0;
    }

    public void AddItem(Item _Item)
    {
        item.Add(_Item);
        DisPlayerItems();
    }

    public void DisPlayerBP()
    {
        if (backPack.activeSelf == false && menu.activeSelf == false)
        {
            Time.timeScale = 0;
            backPack.SetActive(true);
        }
        else if (backPack.activeSelf == true)
        {
            Time.timeScale = 1;
            backPack.SetActive(false);
        }
    }

    public void DisPlayerM()
    {
        //if (SceneControl.Instance.Check() == 2)
        //{
            if (menu.activeSelf == false)
            {
                Time.timeScale = 0;
                backPack.SetActive(false);
                menu.SetActive(true);
            }
            else if (menu.activeSelf == true)
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
        //}
    }
}
