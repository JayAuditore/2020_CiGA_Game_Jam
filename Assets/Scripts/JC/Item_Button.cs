using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_Button : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public int Item_ID;
    public GameObject UI;
    public Text name;
    public Text Des;
    [SerializeField] private Item thisItem;

    void OnEnable()
    {
        UI.SetActive(false);
    }

    private Item GetThisItem()
    {
        for(int i = 0; i < BackPack.Instance.item.Count; i++)
        {
            if(Item_ID == i)
            {
                thisItem = BackPack.Instance.item[i];
            }
        }
        return thisItem;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();
    }


    public void OnPointerExit(PointerEventData eventData)
    {       
        UI.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (thisItem != null)
        {
            UI.SetActive(true);
            UI.transform.position = eventData.position;
            name.text = thisItem.name;
            Des.text = thisItem.Des;

        }
    }
}
