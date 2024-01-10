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
    public Sprite[] longsleeves;
    public Sprite[] pants;
    public Sprite[] jogging;
    public Sprite[] jeans;
    public Sprite[] skirt;
    public Sprite[] blazer;
    public Sprite[] coat;
    public Sprite[] sweat;
    public Sprite[] turtleneck;
    public Sprite[] sneaker;
    public Sprite[] shoe;
    public Sprite[] boots;
    public Sprite[] socks;
    public Sprite[] longsocks;
    public Sprite[] hat;
    public Sprite[] cap;
    public Sprite[] scarfs;


    public void changePattern(string pattern)
    {
       
        if(image.sprite.ToString().Contains("tshirt")){
            if(pattern.Equals("plain")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = tshirts[5] : image.sprite = tshirts[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = tshirts[6] : image.sprite = tshirts[1];
            }else if(pattern.Equals("dot")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = tshirts[7] : image.sprite = tshirts[2];
            }else if(pattern.Equals("check")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = tshirts[8] : image.sprite = tshirts[3];
            }else if(pattern.Equals("flower")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = tshirts[9] : image.sprite = tshirts[4];
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
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = blouses[5] : image.sprite = blouses[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = blouses[6] : image.sprite = blouses[1];
            }else if(pattern.Equals("dot")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = blouses[7] : image.sprite = blouses[2];
            }else if(pattern.Equals("check")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = blouses[8] : image.sprite = blouses[3];
            }else if(pattern.Equals("flower")){
                image.sprite = image.sprite.ToString().Contains("pocket") ? image.sprite = blouses[9] : image.sprite = blouses[4];
            }
        }

        if(image.sprite.ToString().Contains("longsleeve")){
            if(pattern.Equals("plain")){
                image.sprite = longsleeves[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = longsleeves[1];
            }else if(pattern.Equals("dot")){
                image.sprite = longsleeves[2];
            }else if(pattern.Equals("check")){
                image.sprite = longsleeves[3];
            }else if(pattern.Equals("flower")){
                image.sprite = longsleeves[4];
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

        if(image.sprite.ToString().Contains("jeans")){
            if(pattern.Equals("plain")){
                image.sprite = jeans[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = jeans[1];
            }else if(pattern.Equals("dot")){
                image.sprite = jeans[2];
            }else if(pattern.Equals("check")){
                image.sprite = jeans[3];
            }else if(pattern.Equals("flower")){
                image.sprite = jeans[4];
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
        if(image.sprite.ToString().Contains("sweat")){
            if(pattern.Equals("plain")){
                image.sprite = sweat[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = sweat[1];
            }else if(pattern.Equals("dot")){
                image.sprite = sweat[2];
            }else if(pattern.Equals("check")){
                image.sprite = sweat[3];
            }else if(pattern.Equals("flower")){
                image.sprite = sweat[4];
            }
        }
        if(image.sprite.ToString().Contains("turtleneck")){
            if(pattern.Equals("plain")){
                image.sprite = turtleneck[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = turtleneck[1];
            }else if(pattern.Equals("dot")){
                image.sprite = turtleneck[2];
            }else if(pattern.Equals("check")){
                image.sprite = turtleneck[3];
            }else if(pattern.Equals("flower")){
                image.sprite = turtleneck[4];
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
        if(image.sprite.ToString().Contains("shoe")){
            if(pattern.Equals("plain")){
                image.sprite = shoe[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = shoe[1];
            }else if(pattern.Equals("dot")){
                image.sprite = shoe[2];
            }else if(pattern.Equals("check")){
                image.sprite = shoe[3];
            }else if(pattern.Equals("flower")){
                image.sprite = shoe[4];
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
        if(image.sprite.ToString().Contains("longsock")){
            if(pattern.Equals("plain")){
                image.sprite = longsocks[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = longsocks[1];
            }else if(pattern.Equals("dot")){
                image.sprite = longsocks[2];
            }else if(pattern.Equals("check")){
                image.sprite = longsocks[3];
            }else if(pattern.Equals("flower")){
                image.sprite = longsocks[4];
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
        if(image.sprite.ToString().Contains("scarf")){
            if(pattern.Equals("plain")){
                image.sprite = scarfs[0];
            }else if(pattern.Equals("stripe")){
                image.sprite = scarfs[1];
            }else if(pattern.Equals("dot")){
                image.sprite = scarfs[2];
            }else if(pattern.Equals("check")){
                image.sprite = scarfs[3];
            }else if(pattern.Equals("flower")){
                image.sprite = scarfs[4];
            }
        }
    }

    
}
