using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    public List<Tuple<string,float,float,float,float>> wardrobe;

    //When there's no data to load (empty wardrobe)
    public GameData()
    {
        this.wardrobe = new List<Tuple<string, float, float, float, float>>();
    }
}
