using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "item_Story", fileName = "New Item")]
public class Item_Story : ScriptableObject
{
    public int type;
    public int type_story;
    public string name;
    public string Des;

    public Sprite sprite;
}
