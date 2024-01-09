using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ChangeSelectedCloth : MonoBehaviour
{
    [SerializeField]
    private Sprite[] clothes = null;
    public Image image;
    public AddCloth adder;

    private int index = 0;

    public int NBMAX_CLOTHES = 6;

    private void Start()
    {
        image.sprite = clothes[index];
        adaptFrame();
    }

    public void nextCloth()
    {
        index++;
        if(index == NBMAX_CLOTHES){
            index = 0;
        }
            image.sprite = clothes[index];
            adaptFrame();
    }

    public void previousCloth()
    {
        index--;
        if(index == -1){
            index = NBMAX_CLOTHES-1;
        }
            image.sprite = clothes[index];
            adaptFrame();
    }

    public void adaptFrame()
    {
        RectTransform rect = image.GetComponent<RectTransform>();
        if(image.sprite.ToString().Contains("pants") ||image.sprite.ToString().Contains("jogging")||image.sprite.ToString().Contains("jeans")){
            rect.sizeDelta = new Vector2(690,1525);
            image.transform.localPosition = new Vector3(-720f,870f,0f);
        }else if(image.sprite.ToString().Contains("tshirt") ||image.sprite.ToString().Contains("marcel")){
            rect.sizeDelta = new Vector2(1230,1342);
            image.transform.localPosition = new Vector3(-960f,560f,0f);
        }else if(image.sprite.ToString().Contains("blouse")){
            rect.sizeDelta = new Vector2(1226,1300);
            image.transform.localPosition = new Vector3(-960f,830f,0f);
        }else if(image.sprite.ToString().Contains("longsleeve") || image.sprite.ToString().Contains("turtleneck")){
            rect.sizeDelta = new Vector2(1000,1300);
            image.transform.localPosition = new Vector3(-860f,830f,0f);
        }else if(image.sprite.ToString().Contains("skirt") ||image.sprite.ToString().Contains("scarf")){
            rect.sizeDelta = new Vector2(690,600);
            image.transform.localPosition = new Vector3(-720f,680f,0f);
        }else if( image.sprite.ToString().Contains("blazer") || image.sprite.ToString().Contains("sweat")){
            rect.sizeDelta = new Vector2(1020,1367);
            image.transform.localPosition = new Vector3(-880f,700f,0f);
        }else if( image.sprite.ToString().Contains("coat")){
            rect.sizeDelta = new Vector2(940,1220);
            image.transform.localPosition = new Vector3(-840f,890f,0f);
            
        }else if(image.sprite.ToString().Contains("longsock")){
            rect.sizeDelta = new Vector2(630,800);
            image.transform.localPosition = new Vector3(-700f,722f,0f);
        }
        else if(image.sprite.ToString().Contains("boot") ||image.sprite.ToString().Contains("sneaker")||image.sprite.ToString().Contains("sock")||image.sprite.ToString().Contains("shoe")){
            rect.sizeDelta = new Vector2(870,357);
            image.transform.localPosition = new Vector3(-805f,720f,0f);
        }else if(image.sprite.ToString().Contains("cap") ||image.sprite.ToString().Contains("hat")||image.sprite.ToString().Contains("necklace")||image.sprite.ToString().Contains("glasses")){
            rect.sizeDelta = new Vector2(630,341);
            image.transform.localPosition = new Vector3(-700f,722f,0f);
        }
    }

    public void setCloth(int ind){
        image.sprite = clothes[ind];
        index = ind;
        adaptFrame();
        adder.switchCloth();
    }
}
