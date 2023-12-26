using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class ChangePattern : MonoBehaviour
{
    public Image image;

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
        if(image.sprite.ToString().Contains("tshirt")){
            if(pattern.Equals("plain")){
                image.sprite = tshirts[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = tshirts[1];
            }else if(pattern.Equals("dot")){
                image.sprite = tshirts[2];
            }else if(pattern.Equals("check")){
                image.sprite = tshirts[3];
            }else if(pattern.Equals("flower")){
                image.sprite = tshirts[4];
            }
        }
        if(image.sprite.ToString().Contains("marcel")){
            if(pattern.Equals("plain")){
                image.sprite = marcels[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = marcels[1];
            }else if(pattern.Equals("dot")){
                image.sprite = marcels[2];
            }else if(pattern.Equals("check")){
                image.sprite = marcels[3];
            }else if(pattern.Equals("flower")){
                image.sprite = marcels[4];
            }
        }
        if(image.sprite.ToString().Contains("blouse")){
            if(pattern.Equals("plain")){
                image.sprite = blouses[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = blouses[1];
            }else if(pattern.Equals("dot")){
                image.sprite = blouses[2];
            }else if(pattern.Equals("check")){
                image.sprite = blouses[3];
            }else if(pattern.Equals("flower")){
                image.sprite = blouses[4];
            }
        }

        if(image.sprite.ToString().Contains("pants")){
            if(pattern.Equals("plain")){
                image.sprite = pants[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = pants[1];
            }else if(pattern.Equals("dot")){
                image.sprite = pants[2];
            }else if(pattern.Equals("check")){
                image.sprite = pants[3];
            }else if(pattern.Equals("flower")){
                image.sprite = pants[4];
            }
        }

        if(image.sprite.ToString().Contains("jogging")){
            if(pattern.Equals("plain")){
                image.sprite = jogging[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = jogging[1];
            }else if(pattern.Equals("dot")){
                image.sprite = jogging[2];
            }else if(pattern.Equals("check")){
                image.sprite = jogging[3];
            }else if(pattern.Equals("flower")){
                image.sprite = jogging[4];
            }
        }

        if(image.sprite.ToString().Contains("skirt")){
            if(pattern.Equals("plain")){
                image.sprite = skirt[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = skirt[1];
            }else if(pattern.Equals("dot")){
                image.sprite = skirt[2];
            }else if(pattern.Equals("check")){
                image.sprite = skirt[3];
            }else if(pattern.Equals("flower")){
                image.sprite = skirt[4];
            }
        }
        if(image.sprite.ToString().Contains("blazer")){
            if(pattern.Equals("plain")){
                image.sprite = blazer[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = blazer[1];
            }else if(pattern.Equals("dot")){
                image.sprite = blazer[2];
            }else if(pattern.Equals("check")){
                image.sprite = blazer[3];
            }else if(pattern.Equals("flower")){
                image.sprite = blazer[4];
            }
        }
        if(image.sprite.ToString().Contains("coat")){
            if(pattern.Equals("plain")){
                image.sprite = coat[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = coat[1];
            }else if(pattern.Equals("dot")){
                image.sprite = coat[2];
            }else if(pattern.Equals("check")){
                image.sprite = coat[3];
            }else if(pattern.Equals("flower")){
                image.sprite = coat[4];
            }
        }
        if(image.sprite.ToString().Contains("sneaker")){
            if(pattern.Equals("plain")){
                image.sprite = sneaker[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = sneaker[1];
            }else if(pattern.Equals("dot")){
                image.sprite = sneaker[2];
            }else if(pattern.Equals("check")){
                image.sprite = sneaker[3];
            }else if(pattern.Equals("flower")){
                image.sprite = sneaker[4];
            }
        }
        if(image.sprite.ToString().Contains("sock")){
            if(pattern.Equals("plain")){
                image.sprite = socks[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = socks[1];
            }else if(pattern.Equals("dot")){
                image.sprite = socks[2];
            }else if(pattern.Equals("check")){
                image.sprite = socks[3];
            }else if(pattern.Equals("flower")){
                image.sprite = socks[4];
            }
        }
        if(image.sprite.ToString().Contains("hat")){
            if(pattern.Equals("plain")){
                image.sprite = hat[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = hat[1];
            }else if(pattern.Equals("dot")){
                image.sprite = hat[2];
            }else if(pattern.Equals("check")){
                image.sprite = hat[3];
            }else if(pattern.Equals("flower")){
                image.sprite = hat[4];
            }
        }
        if(image.sprite.ToString().Contains("cap")){
            if(pattern.Equals("plain")){
                image.sprite = cap[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = cap[1];
            }else if(pattern.Equals("dot")){
                image.sprite = cap[2];
            }else if(pattern.Equals("check")){
                image.sprite = cap[3];
            }else if(pattern.Equals("flower")){
                image.sprite = cap[4];
            }
        }
        if(image.sprite.ToString().Contains("boot")){
            if(pattern.Equals("plain")){
                image.sprite = boots[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = boots[1];
            }else if(pattern.Equals("dot")){
                image.sprite = boots[2];
            }else if(pattern.Equals("check")){
                image.sprite = boots[3];
            }else if(pattern.Equals("flower")){
                image.sprite = boots[4];
            }
        }
    }

    
}
