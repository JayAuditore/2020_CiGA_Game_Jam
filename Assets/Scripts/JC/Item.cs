using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "item", fileName = "New Item")]
public class Item : ScriptableObject
{
    public int type;
    public int type_story;//1234
    public string name;
    public string Des;

    public Sprite sprite;
    
    public BaseAttribute attribute;
    public Buff buff;
}
