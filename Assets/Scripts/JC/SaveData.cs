using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : BaseSingletonWithMono<SaveData>
{
    public Vector2 PlayerPos;



    public List<Item> items = new List<Item>();

    public int SceneNum;
}