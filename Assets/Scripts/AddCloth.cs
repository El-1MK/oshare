using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

public class AddCloth : MonoBehaviour, IDataPersistence
{

    private static int leftBorder = -113;
    private static int rightBorder = 113;
    private static int offsettopHoriz = 55;
    private static int offsettopVert = 70;
    private static int offsetlegwearHoriz = 54;
    private static int offsetlegwearVert = 70;
    public int topCounter = 0;
    public int legwearCounter = 0;

    private List<Cloth> wardrobe = new List<Cloth>();

    public SpriteRenderer renderer;

    private GameObject imageAddedToScene;

    public GameObject topFloor;
    public GameObject legwearFloor;
    public GameObject outerwearFloor;
    public GameObject headgearFloor;
    public GameObject accessoriesFloor;
    public GameObject shoesFloor;
    public GameObject socksFloor;
    private float topHeight;
    private float legwearHeight;

    public List<Sprite> availableClothes;
    public List <Sprite> availablelegwear;

    public TMPro.TextMeshProUGUI text;

    public List <string> categories = new List<string>(){"top","legwear","shoes","socks","accessories", "headgear","outerwear"};

    public string currentPattern = "plain";

    public void LoadData(GameData data )
    {
        text.text = "Tops";
        this.wardrobe = data.wardrobe;
        this.topCounter = data.wardrobe.Where(c=>c.category == "top").Count();
        this.legwearCounter = data.wardrobe.Where(c=>c.category == "legwear").Count();
        List<Cloth> tops = data.wardrobe.FindAll(c => c.sprite.Contains("tshirt"));
        List<Cloth> legwear = data.wardrobe.FindAll(c => c.sprite.Contains("pants"));
        for(int i=0;i<legwear.Count;i++)
        {
            loadCloth( legwear[i].sprite,legwear[i].red,legwear[i].green,legwear[i].blue,legwear[i].albedo,legwear[i].category,legwear[i].pattern,i);
        }
        for(int i=0;i<tops.Count;i++)
        {
            loadCloth( tops[i].sprite,tops[i].red,tops[i].green,tops[i].blue,tops[i].albedo,tops[i].category,tops[i].pattern,i);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.wardrobe = this.wardrobe;
    }
    
    public void addCloth()
    {
        if(renderer.sprite.ToString().Contains("tshirt")){
        int nbRow = topCounter/4;
        int nbtopRow = 0;
        if(topCounter > 0) nbtopRow = (240/(55*topCounter));
        float currentCursorVert = -42.5f - nbRow * offsettopVert;

        float currentCursorHoriz = 22.5f +(topCounter%4)*offsettopHoriz;

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        newImage.sprite = renderer.sprite;
        newImage.rectTransform.sizeDelta = new Vector2(55,70);
        newImage.color = renderer.color;

        wardrobe.Add(new Cloth(renderer.sprite.ToString(),renderer.color.r,renderer.color.g,renderer.color.b,renderer.color.a,"top",currentPattern));

        imageAddedToScene.transform.SetParent(topFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
         newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


        if(topCounter%4 == 0){
            RectTransform topPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            topPanelRect.sizeDelta = new Vector2(topPanelRect.rect.width,topPanelRect.rect.height + 70);
           // topPanelRect.localPosition = new Vector3(topPanelRect.anchoredPosition.x,topPanelRect.anchoredPosition.y + 75,0 );
           RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
           wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 70);
           topHeight += 70;
            
        }
        topCounter++;
        }else if(renderer.sprite.ToString().Contains("pants")){
            int nbRow = legwearCounter/4;
            int nblegwearRow = 0;
            if(legwearCounter > 0) nblegwearRow = (240/(55*legwearCounter));
            float currentCursorVert = -35 - nbRow * offsetlegwearVert;

            float currentCursorHoriz = 22 + (legwearCounter%4)*offsetlegwearHoriz;

            imageAddedToScene = new GameObject();
            Image newImage = imageAddedToScene.AddComponent<Image>();
            newImage.sprite = renderer.sprite;
            newImage.rectTransform.sizeDelta = new Vector2(54,70);
            newImage.color = renderer.color;

            wardrobe.Add(new Cloth(renderer.sprite.ToString(),renderer.color.r,renderer.color.g,renderer.color.b,renderer.color.a,"legwear",currentPattern));

            imageAddedToScene.transform.SetParent(legwearFloor.transform);
            newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
            newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
            newImage.rectTransform.anchorMin = new Vector2(0,1);
            newImage.rectTransform.anchorMax = new Vector2(0,1);
            newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


            if(legwearCounter%4 == 0){
                RectTransform legwearPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
                legwearPanelRect.sizeDelta = new Vector2(legwearPanelRect.rect.width,legwearPanelRect.rect.height + 70);
               // topPanelRect.localPosition = new Vector3(topPanelRect.anchoredPosition.x,topPanelRect.anchoredPosition.y + 75,0 );
               RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
               wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 70);
                legwearHeight+=70;
            }
            legwearCounter++;
        }


    }

    public void loadCloth(string image,float red,float green,float blue,float albedo,string category,string pattern, int index)
    {
        if(category == "top"){
        int nbRow = (topCounter-(topCounter - index))/4;
        int nbtopRow = 0;
        if((topCounter - (topCounter - index)) > 0 ) nbtopRow = (240/(55*(topCounter - (topCounter - index))));
        float currentCursorVert = -42.5f - nbRow * offsettopVert;

        float currentCursorHoriz = 22.5f + ((topCounter - (topCounter - index))%4)*offsettopHoriz;

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        if(pattern == "plain")newImage.sprite = availableClothes[0];
        if(pattern == "tiles")newImage.sprite = availableClothes[3];
        if(pattern == "stripes")newImage.sprite = availableClothes[1];
        if(pattern == "dots")newImage.sprite = availableClothes[2];
        if(pattern == "flowers")newImage.sprite = availableClothes[0];



        
        newImage.rectTransform.sizeDelta = new Vector2(55,70);
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(topFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
         newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


         if(index > 0 && index%4==0){
            RectTransform topPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            topPanelRect.sizeDelta = new Vector2(topPanelRect.rect.width,topPanelRect.rect.height + 70);
           // topPanelRect.localPosition = new Vector3(topPanelRect.anchoredPosition.x,topPanelRect.anchoredPosition.y + 75,0 );
           RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
           wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 70);
           topHeight = topPanelRect.rect.height;
            
        }
        }else if(category == "legwear"){
        int nbRow = (legwearCounter-(legwearCounter - index))/4;
        int nblegwearRow = 0;
        if((legwearCounter - (legwearCounter - index)) > 0 ) nblegwearRow = (240/(54*(legwearCounter - (legwearCounter - index))));
        float currentCursorVert = -35 - nbRow * offsetlegwearVert;

        float currentCursorHoriz = 22 + ((legwearCounter - (legwearCounter - index))%4)*offsetlegwearHoriz;

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        if(image.Contains("dots")){newImage.sprite = availablelegwear[0];}
        else{newImage.sprite = availablelegwear[0];}



        
        newImage.rectTransform.sizeDelta = new Vector2(54,70);
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(legwearFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
        newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);

        
        if(index > 0 && index%4==0){

            RectTransform legwearPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            legwearPanelRect.sizeDelta = new Vector2(legwearPanelRect.rect.width,legwearPanelRect.rect.height + 70);
            legwearHeight = legwearPanelRect.rect.height;            
        }
    }

    }

    public void switchCloth(){
        legwearFloor.SetActive(false);
        topFloor.SetActive(false);
        headgearFloor.SetActive(false);
        accessoriesFloor.SetActive(false);
        socksFloor.SetActive(false);
        shoesFloor.SetActive(false);
        outerwearFloor.SetActive(false);
        string category = "";
        if(renderer.sprite.ToString().Contains("blouse") || 
        renderer.sprite.ToString().Contains("marcel") ||
        renderer.sprite.ToString().Contains("tshirt")
        ){
        text.text="Tops";
        topFloor.SetActive(true);
        RectTransform wardrobePanelRect = topFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,topHeight);
        }else if(renderer.sprite.ToString().Contains("skirt") ||
        renderer.sprite.ToString().Contains("pants") ||
        renderer.sprite.ToString().Contains("jogging")){
        text.text="Legwear";
        legwearFloor.SetActive(true);
        RectTransform wardrobePanelRect = legwearFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,legwearHeight+20);
        }else if(renderer.sprite.ToString().Contains("blazer") ||
        renderer.sprite.ToString().Contains("coat") ){
        text.text="Outerwear";
        outerwearFloor.SetActive(true);
        RectTransform wardrobePanelRect = outerwearFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,legwearHeight+20);
        }else if(renderer.sprite.ToString().Contains("boot") ||
        renderer.sprite.ToString().Contains("sneaker")){
        text.text="Shoes";
        shoesFloor.SetActive(true);
        RectTransform wardrobePanelRect = shoesFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,legwearHeight+20);
        }else if(renderer.sprite.ToString().Contains("socks")){
        text.text="Socks";
        socksFloor.SetActive(true);
        RectTransform wardrobePanelRect = socksFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,legwearHeight+20);
        }else if(renderer.sprite.ToString().Contains("necklace") ||
        renderer.sprite.ToString().Contains("glasses") ){
        text.text="Accessories";
        accessoriesFloor.SetActive(true);
        RectTransform wardrobePanelRect = accessoriesFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,legwearHeight+20);
        }else if(renderer.sprite.ToString().Contains("cap") ||
        renderer.sprite.ToString().Contains("hat")){
        text.text="Headgear";
        headgearFloor.SetActive(true);
        RectTransform wardrobePanelRect = headgearFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,legwearHeight+20);
        }
    }

    public void changePattern(string patt){
        this.currentPattern = patt;
    }
}
