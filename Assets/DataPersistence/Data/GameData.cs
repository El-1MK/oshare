using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    public List<Cloth> wardrobe;

    //When there's no data to load (empty wardrobe)
    public GameData()
    {
        this.wardrobe = new List<Cloth>();
    }
}

[System.Serializable]
public class Cloth
{
    public string sprite;
    public float red;
    public float green;
    public float blue;
    public float albedo;

    public Cloth(string sprite, float r, float g, float b, float a)
    {
        this.sprite = sprite;
        red = r;
        green = g;
        blue = b;
        albedo = a;
    }
}
