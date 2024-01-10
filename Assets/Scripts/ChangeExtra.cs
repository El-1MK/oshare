using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ChangeExtra : MonoBehaviour
{

    public Image image;

    public Sprite[] tshirts_pocket;
    public Sprite[] blouses_pocket;
    public Sprite[] tshirts;
    public Sprite[] blouses;

    public void changeExtra(string extra)
    {

         RectTransform rect = image.GetComponent<RectTransform>();
        if(extra.Equals("pocket")){
            if(image.sprite.ToString().Contains("tshirt_plain")){
                image.sprite = tshirts_pocket[0];
            }else if(image.sprite.ToString().Contains("tshirt_stripe")){
                image.sprite = tshirts_pocket[1];
            }else if(image.sprite.ToString().Contains("tshirt_dot")){
                image.sprite = tshirts_pocket[2];
            }else if(image.sprite.ToString().Contains("tshirt_check")){
                image.sprite = tshirts_pocket[3];
            }else if(image.sprite.ToString().Contains("tshirt_flower")){
                image.sprite = tshirts_pocket[4];
            }else if(image.sprite.ToString().Contains("blouse_plain")){
                image.sprite = blouses_pocket[0];
            }else if(image.sprite.ToString().Contains("blouse_stripe")){
                image.sprite = blouses_pocket[1];
            }else if(image.sprite.ToString().Contains("blouse_dot")){
                image.sprite = blouses_pocket[2];
            }else if(image.sprite.ToString().Contains("blouse_check")){
                image.sprite = blouses_pocket[3];
            }else if(image.sprite.ToString().Contains("blouse_flower")){
                image.sprite = blouses_pocket[4];
            }

            if(image.sprite.ToString().Contains("tshirt")){
                rect.sizeDelta = new Vector2(1120,1342);
            image.transform.localPosition = new Vector3(-900f,580f,0f);
            }

            if(image.sprite.ToString().Contains("blouse")){
                rect.sizeDelta = new Vector2(1200,1300);
            image.transform.localPosition = new Vector3(-940f,840f,0f);;
            }
            
        }else{
            if(image.sprite.ToString().Contains("tshirt")){
                rect.sizeDelta = new Vector2(1230,1342);
            image.transform.localPosition = new Vector3(-960f,560f,0f);
            }

            if(image.sprite.ToString().Contains("blouse")){
                rect.sizeDelta = new Vector2(1226,1300);
            image.transform.localPosition = new Vector3(-960f,830f,0f);
            }

            if(image.sprite.ToString().Contains("tshirt_plain")){
                image.sprite = tshirts[0];
            }else if(image.sprite.ToString().Contains("tshirt_stripe")){
                image.sprite = tshirts[1];
            }else if(image.sprite.ToString().Contains("tshirt_dot")){
                image.sprite = tshirts[2];
            }else if(image.sprite.ToString().Contains("tshirt_check")){
                image.sprite = tshirts[3];
            }else if(image.sprite.ToString().Contains("tshirt_flower")){
                image.sprite = tshirts[4];
            }else if(image.sprite.ToString().Contains("blouse_plain")){
                image.sprite = blouses[0];
            }else if(image.sprite.ToString().Contains("blouse_stripe")){
                image.sprite = blouses[1];
            }else if(image.sprite.ToString().Contains("blouse_dot")){
                image.sprite = blouses[2];
            }else if(image.sprite.ToString().Contains("blouse_check")){
                image.sprite = blouses[3];
            }else if(image.sprite.ToString().Contains("blouse_flower")){
                image.sprite = blouses[4];
            }
        }
    }

    
}