using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ChangePattern : MonoBehaviour
{
    public string current = "t-shirt";
    public GameObject spriteToChange;
    public SpriteRenderer renderer;

    public Sprite plainSprite;
    public Sprite horizStripSprite;
    public Sprite dotsSprite;

    public void changePattern(string pattern)
    {
        renderer = spriteToChange.GetComponent<SpriteRenderer>();

        if(pattern.Equals("horiz-stripes")){
            renderer.sprite = horizStripSprite;
        }else if(pattern.Equals("plain")){
            renderer.sprite = plainSprite;
        }else if(pattern.Equals("dots")){
            renderer.sprite = dotsSprite;
        }
    }

    
}
