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
    private static int offsetTshirtHoriz = 55;
    private static int offsetTshirtVert = 70;
    private static int offsetPantsHoriz = 54;
    private static int offsetPantsVert = 70;
    public int tshirtCounter = 0;
    public int pantsCounter = 0;

    private List<Cloth> wardrobe = new List<Cloth>();

    public SpriteRenderer renderer;

    private GameObject imageAddedToScene;

    public GameObject tshirtFloor;
    public GameObject pantsFloor;
    private float tshirtHeight;
    private float pantsHeight;

    public List<Sprite> availableClothes;
    public List <Sprite> availablePants;

    public TMPro.TextMeshProUGUI text;

    public void LoadData(GameData data )
    {
        text.text = "Tshirts";
        this.wardrobe = data.wardrobe;
        this.tshirtCounter = data.wardrobe.Where(c=>c.sprite.Contains("T-shirt")).Count();
        this.pantsCounter = data.wardrobe.Where(c=>c.sprite.Contains("Pants")).Count();
        List<Cloth> tshirts = data.wardrobe.FindAll(c => c.sprite.Contains("T-shirt"));
        List<Cloth> pants = data.wardrobe.FindAll(c => c.sprite.Contains("Pants"));
        for(int i=0;i<pants.Count;i++)
        {
            loadCloth( pants[i].sprite,pants[i].red,pants[i].green,pants[i].blue,pants[i].albedo,i);
        }
        for(int i=0;i<tshirts.Count;i++)
        {
            loadCloth( tshirts[i].sprite,tshirts[i].red,tshirts[i].green,tshirts[i].blue,tshirts[i].albedo,i);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.wardrobe = this.wardrobe;
    }
    
    public void addCloth()
    {
        if(renderer.sprite.ToString().Contains("T-shirt")){
        int nbRow = tshirtCounter/4;
        int nbTshirtRow = 0;
        if(tshirtCounter > 0) nbTshirtRow = (240/(55*tshirtCounter));
        float currentCursorVert = -42.5f - nbRow * offsetTshirtVert;

        float currentCursorHoriz = 22.5f +(tshirtCounter%4)*offsetTshirtHoriz;

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        newImage.sprite = renderer.sprite;
        newImage.rectTransform.sizeDelta = new Vector2(55,70);
        newImage.color = renderer.color;

        wardrobe.Add(new Cloth(renderer.sprite.ToString(),renderer.color.r,renderer.color.g,renderer.color.b,renderer.color.a));

        imageAddedToScene.transform.SetParent(tshirtFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
         newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


        if(tshirtCounter%4 == 0){
            RectTransform tshirtPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            tshirtPanelRect.sizeDelta = new Vector2(tshirtPanelRect.rect.width,tshirtPanelRect.rect.height + 70);
           // tshirtPanelRect.localPosition = new Vector3(tshirtPanelRect.anchoredPosition.x,tshirtPanelRect.anchoredPosition.y + 75,0 );
           RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
           wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 70);
           tshirtHeight += 70;
            
        }
        tshirtCounter++;
        }else if(renderer.sprite.ToString().Contains("Pants")){
            int nbRow = pantsCounter/4;
            int nbPantsRow = 0;
            if(pantsCounter > 0) nbPantsRow = (240/(55*pantsCounter));
            float currentCursorVert = -35 - nbRow * offsetPantsVert;

            float currentCursorHoriz = 22 + (pantsCounter%4)*offsetPantsHoriz;

            imageAddedToScene = new GameObject();
            Image newImage = imageAddedToScene.AddComponent<Image>();
            newImage.sprite = renderer.sprite;
            newImage.rectTransform.sizeDelta = new Vector2(54,70);
            newImage.color = renderer.color;

            wardrobe.Add(new Cloth(renderer.sprite.ToString(),renderer.color.r,renderer.color.g,renderer.color.b,renderer.color.a));

            imageAddedToScene.transform.SetParent(pantsFloor.transform);
            newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
            newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
            newImage.rectTransform.anchorMin = new Vector2(0,1);
            newImage.rectTransform.anchorMax = new Vector2(0,1);
            newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


            if(pantsCounter%4 == 0){
                RectTransform pantsPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
                pantsPanelRect.sizeDelta = new Vector2(pantsPanelRect.rect.width,pantsPanelRect.rect.height + 70);
               // tshirtPanelRect.localPosition = new Vector3(tshirtPanelRect.anchoredPosition.x,tshirtPanelRect.anchoredPosition.y + 75,0 );
               RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
               wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 70);
                pantsHeight+=70;
            }
            pantsCounter++;
        }


    }

    public void loadCloth(string image,float red,float green,float blue,float albedo,int index)
    {
        if(image.Contains("T-shirt")){
        int nbRow = (tshirtCounter-(tshirtCounter - index))/4;
        int nbTshirtRow = 0;
        if((tshirtCounter - (tshirtCounter - index)) > 0 ) nbTshirtRow = (240/(55*(tshirtCounter - (tshirtCounter - index))));
        float currentCursorVert = -42.5f - nbRow * offsetTshirtVert;

        float currentCursorHoriz = 22.5f + ((tshirtCounter - (tshirtCounter - index))%4)*offsetTshirtHoriz;

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        if(image.Contains("drawing"))newImage.sprite = availableClothes[0];
        if(image.Contains("pocket"))newImage.sprite = availableClothes[3];
        if(image.Contains("stripes"))newImage.sprite = availableClothes[1];
        if(image.Contains("dots"))newImage.sprite = availableClothes[2];



        
        newImage.rectTransform.sizeDelta = new Vector2(55,70);
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(tshirtFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
         newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


         if(index > 0 && index%4==0){
            RectTransform tshirtPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            tshirtPanelRect.sizeDelta = new Vector2(tshirtPanelRect.rect.width,tshirtPanelRect.rect.height + 70);
           // tshirtPanelRect.localPosition = new Vector3(tshirtPanelRect.anchoredPosition.x,tshirtPanelRect.anchoredPosition.y + 75,0 );
           RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
           wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 70);
           tshirtHeight = tshirtPanelRect.rect.height;
            
        }
        }else if(image.Contains("Pants")){
        int nbRow = (pantsCounter-(pantsCounter - index))/4;
        int nbPantsRow = 0;
        if((pantsCounter - (pantsCounter - index)) > 0 ) nbPantsRow = (240/(54*(pantsCounter - (pantsCounter - index))));
        float currentCursorVert = -35 - nbRow * offsetPantsVert;

        float currentCursorHoriz = 22 + ((pantsCounter - (pantsCounter - index))%4)*offsetPantsHoriz;

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        if(image.Contains("dots")){newImage.sprite = availablePants[0];}
        else{newImage.sprite = availablePants[0];}



        
        newImage.rectTransform.sizeDelta = new Vector2(54,70);
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(pantsFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
        newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);

        
        if(index > 0 && index%4==0){

            RectTransform pantsPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            pantsPanelRect.sizeDelta = new Vector2(pantsPanelRect.rect.width,pantsPanelRect.rect.height + 70);
            pantsHeight = pantsPanelRect.rect.height;            
        }
    }

    }

    public void switchCloth(){
        pantsFloor.SetActive(false);
        tshirtFloor.SetActive(false);
        if(renderer.sprite.ToString().Contains("T-shirt")){
        text.text="Tshirts";
        tshirtFloor.SetActive(true);
        RectTransform wardrobePanelRect = tshirtFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,tshirtHeight);
        }else if(renderer.sprite.ToString().Contains("Pants")){
        text.text="Pants";
        pantsFloor.SetActive(true);
        RectTransform wardrobePanelRect = pantsFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,pantsHeight+20);
        }
    }
}
