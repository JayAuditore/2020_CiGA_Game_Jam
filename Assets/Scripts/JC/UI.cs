using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : BaseSingletonWithMono<UI>
{
    public GameObject Blood;
    public List<GameObject> Bloods = new List<GameObject>();
    public GameObject BossBlood;
    public Slider slider;
    public Text name;

    public float BloodNum; 
    private void Awake()
    {
        CenterEvent.Instance.AddListener("AddBlood", AddBlood);
        AddBlood();
    }

    public void BloodCount(int MaxBlood, int LastBlood, string BossName, bool Display)
    {
        if (Display)
        {
            name.text = BossName;
            slider.value = LastBlood / MaxBlood;
            BossBlood.SetActive(true);         
        }

        if(!Display)
        {
            slider.value = 1;
            BossBlood.SetActive(false);            
        }
    }

    public void DisPlayerBlood()
    {
        Blood.SetActive(true);
    }

    public void AddBlood()
    {
        for (int i = 0; i < PlayerAttribute.Instance.playerAttribute.hp; i++)
        {
            Bloods[i].SetActive(true);
        }

        for (int i = (int)PlayerAttribute.Instance.playerAttribute.hp; i < 15; i++)
        {
            
            Bloods[i].SetActive(false);
        }
       
    }
}
