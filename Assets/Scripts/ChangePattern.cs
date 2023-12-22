using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ChangePattern : MonoBehaviour
{
    public GameObject spriteToChange;
    public SpriteRenderer renderer;

    public Sprite[] tshirts;
    public Sprite[] marcels;
    public Sprite[] blouses;
    public Sprite[] pants;
    public Sprite[] jogging;
    public Sprite[] skirt;
    public Sprite[] blazer;
    public Sprite[] coat;
    public Sprite[] sneaker;
    public Sprite[] boots;
    public Sprite[] socks;
    public Sprite[] hat;
    public Sprite[] cap;


    public void changePattern(string pattern)
    {
        renderer = spriteToChange.GetComponent<SpriteRenderer>();
        if(renderer.sprite.ToString().Contains("tshirt")){
            if(pattern.Equals("plain")){
                renderer.sprite = tshirts[0];
            }else if(pattern.Equals("stripe")){
                renderer.sprite = tshirts[1];
            }else if(pattern.Equals("dot")){
                renderer.sprite = tshirts[2];
            }else if(pattern.Equals("check")){
                renderer.sprite = tshirts[3];
            }else if(pattern.Equals("flower")){
                renderer.sprite = tshirts[4];
            }
        }
        if(renderer.sprite.ToString().Contains("marcel")){
            if(pattern.Equals("plain")){
                renderer.sprite = marcels[0];
            }else if(pattern.Equals("stripe")){
                renderer.sprite = marcels[1];
            }else if(pattern.Equals("dot")){
                renderer.sprite = marcels[2];
            }else if(pattern.Equals("check")){
                renderer.sprite = marcels[3];
            }else if(pattern.Equals("flower")){
                renderer.sprite = marcels[4];
            }
        }
        if(renderer.sprite.ToString().Contains("blouse")){
            if(pattern.Equals("plain")){
                renderer.sprite = blouses[0];
            }else if(pattern.Equals("stripe")){
                renderer.sprite = blouses[1];
            }else if(pattern.Equals("dot")){
                renderer.sprite = blouses[2];
            }else if(pattern.Equals("check")){
                renderer.sprite = blouses[3];
            }else if(pattern.Equals("flower")){
                renderer.sprite = blouses[4];
            }
        }

        if(renderer.sprite.ToString().Contains("pants")){
            if(pattern.Equals("plain")){
                renderer.sprite = pants[0];
            }else if(pattern.Equals("stripe")){
                renderer.sprite = pants[1];
            }else if(pattern.Equals("dot")){
                renderer.sprite = pants[2];
            }else if(pattern.Equals("check")){
                renderer.sprite = pants[3];
            }else if(pattern.Equals("flower")){
                renderer.sprite = pants[4];
            }
        }

        if(renderer.sprite.ToString().Contains("jogging")){
            if(pattern.Equals("plain")){
                renderer.sprite = jogging[0];
            }else if(pattern.Equals("stripe")){
                renderer.sprite = jogging[1];
            }else if(pattern.Equals("dot")){
                renderer.sprite = jogging[2];
            }else if(pattern.Equals("check")){
                renderer.sprite = jogging[3];
            }else if(pattern.Equals("flower")){
                renderer.sprite = jogging[4];
            }
        }

        if(renderer.sprite.ToString().Contains("skirt")){
            if(pattern.Equals("plain")){
                renderer.sprite = skirt[0];
            }else if(pattern.Equals("stripe")){
                renderer.sprite = skirt[1];
            }else if(pattern.Equals("dot")){
                renderer.sprite = skirt[2];
            }else if(pattern.Equals("check")){
                renderer.sprite = skirt[3];
            }else if(pattern.Equals("flower")){
                renderer.sprite = skirt[4];
            }
        }
        if(renderer.sprite.ToString().Contains("blazer")){
            if(pattern.Equals("plain")){
                renderer.sprite = blazer[0];
            }else if(pattern.Equals("stripe")){
                renderer.sprite = blazer[1];
            }else if(pattern.Equals("dot")){
                renderer.sprite = blazer[2];
            }else if(pattern.Equals("check")){
                renderer.sprite = blazer[3];
            }else if(pattern.Equals("flower")){
                renderer.sprite = blazer[4];
            }
        }
        if(renderer.sprite.ToString().Contains("coat")){
            if(pattern.Equals("plain")){
                renderer.sprite = coat[0];
            }else if(pattern.Equals("stripe")){
                renderer.sprite = coat[1];
            }else if(pattern.Equals("dot")){
                renderer.sprite = coat[2];
            }else if(pattern.Equals("check")){
                renderer.sprite = coat[3];
            }else if(pattern.Equals("flower")){
                renderer.sprite = coat[4];
            }
        }
    }

    
}
