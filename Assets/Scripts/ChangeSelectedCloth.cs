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
        if(image.sprite.ToString().Contains("pants") ||image.sprite.ToString().Contains("jogging")){
            rect.sizeDelta = new Vector2(66,155);
            image.transform.localPosition = new Vector3(-46f,44f,0f);
        }else if(image.sprite.ToString().Contains("tshirt") ||image.sprite.ToString().Contains("marcel")){
            rect.sizeDelta = new Vector2(130,155);
            image.transform.localPosition = new Vector3(-46f,16f,0f);
        }else if(image.sprite.ToString().Contains("blouse")){
            rect.sizeDelta = new Vector2(130,155);
            image.transform.localPosition = new Vector3(-46f,44f,0f);
        }else if(image.sprite.ToString().Contains("skirt")){
            rect.sizeDelta = new Vector2(66,77);
            image.transform.localPosition = new Vector3(-46f,22f,0f);
        }else if( image.sprite.ToString().Contains("blazer")){
            rect.sizeDelta = new Vector2(107,160);
            image.transform.localPosition = new Vector3(-48f,16f,0f);
        }else if( image.sprite.ToString().Contains("coat")){
            rect.sizeDelta = new Vector2(107,160);
            image.transform.localPosition = new Vector3(-48f,47f,0f);
        }else if(image.sprite.ToString().Contains("boot") ||image.sprite.ToString().Contains("sneaker")||image.sprite.ToString().Contains("sock")){
            rect.sizeDelta = new Vector2(107,45);
            image.transform.localPosition = new Vector3(-46f,16f,0f);
        }else if(image.sprite.ToString().Contains("cap") ||image.sprite.ToString().Contains("hat")||image.sprite.ToString().Contains("necklace")||image.sprite.ToString().Contains("glasses")){
            rect.sizeDelta = new Vector2(107,67);
            image.transform.localPosition = new Vector3(-46f,27f,0f);
        }
    }
}
