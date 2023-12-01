using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChangeExtra : MonoBehaviour
{
    public string current = "t-shirt";
    public SpriteRenderer renderer;

    public Sprite pocketSprite;

    public void changeExtra(string extra)
    {


        if(extra.Equals("pocket")){
            renderer.sprite = pocketSprite;
        }
    }

    
}