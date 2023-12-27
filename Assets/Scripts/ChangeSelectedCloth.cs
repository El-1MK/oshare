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
            rect.sizeDelta = new Vector2(690,1525);
            image.transform.localPosition = new Vector3(-720f,770f,0f);
        }else if(image.sprite.ToString().Contains("tshirt") ||image.sprite.ToString().Contains("marcel")){
            rect.sizeDelta = new Vector2(1230,1342);
            image.transform.localPosition = new Vector3(-960f,260f,0f);
        }else if(image.sprite.ToString().Contains("blouse")){
            rect.sizeDelta = new Vector2(1226,1300);
            image.transform.localPosition = new Vector3(-960f,630f,0f);
        }else if(image.sprite.ToString().Contains("skirt")){
            rect.sizeDelta = new Vector2(690,600);
            image.transform.localPosition = new Vector3(-720f,280f,0f);
        }else if( image.sprite.ToString().Contains("blazer")){
            rect.sizeDelta = new Vector2(1020,1367);
            image.transform.localPosition = new Vector3(-880f,300f,0f);
        }else if( image.sprite.ToString().Contains("coat")){
            rect.sizeDelta = new Vector2(940,1220);
            image.transform.localPosition = new Vector3(-840f,490f,0f);
        }else if(image.sprite.ToString().Contains("boot") ||image.sprite.ToString().Contains("sneaker")||image.sprite.ToString().Contains("sock")){
            rect.sizeDelta = new Vector2(870,357);
            image.transform.localPosition = new Vector3(-805f,320f,0f);
        }else if(image.sprite.ToString().Contains("cap") ||image.sprite.ToString().Contains("hat")||image.sprite.ToString().Contains("necklace")||image.sprite.ToString().Contains("glasses")){
            rect.sizeDelta = new Vector2(630,341);
            image.transform.localPosition = new Vector3(-700f,322f,0f);
        }
    }
}
