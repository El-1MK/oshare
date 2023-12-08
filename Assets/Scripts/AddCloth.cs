using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddCloth : MonoBehaviour, IDataPersistence
{
    private static int leftBorder = -113;
    private static int rightBorder = 113;
    private static int offsetTshirtHoriz = 55;
    private static int offsetTshirtVert = 70;
    public int tshirtCounter = 0;

    private List<Cloth> wardrobe = new List<Cloth>();

    public SpriteRenderer renderer;

    private GameObject imageAddedToScene;

    public GameObject parent;

    public List<Sprite> availableClothes;

    public void LoadData(GameData data)
    {
        this.wardrobe = data.wardrobe;
        this.tshirtCounter = data.wardrobe.Count;
        for(int i=0;i<data.wardrobe.Count;i++)
        {
            loadCloth( wardrobe[i].sprite,wardrobe[i].red,wardrobe[i].green,wardrobe[i].blue,wardrobe[i].albedo,i);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.wardrobe = this.wardrobe;
    }
    
    public void addCloth()
    {
        int nbRow = tshirtCounter/4;
        int nbTshirtRow = 0;
        if(tshirtCounter > 0) nbTshirtRow = (240/(55*tshirtCounter));
        float currentCursorVert = -42.5f - nbRow * offsetTshirtVert;

        float currentCursorHoriz = (tshirtCounter%4)*offsetTshirtHoriz;

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        newImage.sprite = renderer.sprite;
        newImage.rectTransform.sizeDelta = new Vector2(55,70);
        newImage.color = renderer.color;

        wardrobe.Add(new Cloth(renderer.sprite.ToString(),renderer.color.r,renderer.color.g,renderer.color.b,renderer.color.a));

        imageAddedToScene.transform.SetParent(parent.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
         newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz+22.5f,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


        if(tshirtCounter%4 == 0){
            RectTransform tshirtPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            tshirtPanelRect.sizeDelta = new Vector2(tshirtPanelRect.rect.width,tshirtPanelRect.rect.height + 75);
           // tshirtPanelRect.localPosition = new Vector3(tshirtPanelRect.anchoredPosition.x,tshirtPanelRect.anchoredPosition.y + 75,0 );
           RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
           wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 75);
            
        }
        tshirtCounter++;


    }

    public void loadCloth(string image,float red,float green,float blue,float albedo,int index)
    {
        Debug.Log("index tshirtCounter wardrobe.Count "+ index+" "+tshirtCounter+" "+wardrobe.Count);
        int nbRow = (tshirtCounter-(wardrobe.Count - index))/4;
        Debug.Log("index / nbRow"+ index +" "+nbRow);
        int nbTshirtRow = 0;
        if((tshirtCounter - (wardrobe.Count - index)) > 0 ) nbTshirtRow = (240/(55*(tshirtCounter - (wardrobe.Count - index))));
        Debug.Log("index / nbTshirtSurRow"+ index +" "+nbTshirtRow);
        float currentCursorVert = -42.5f - nbRow * offsetTshirtVert;

        float currentCursorHoriz = ((tshirtCounter - (wardrobe.Count - index))%4)*offsetTshirtHoriz;

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        if(image.Contains("drawing"))newImage.sprite = availableClothes[0];
        if(image.Contains("pocket"))newImage.sprite = availableClothes[3];
        if(image.Contains("stripes"))newImage.sprite = availableClothes[1];
        if(image.Contains("dots"))newImage.sprite = availableClothes[2];



        
        newImage.rectTransform.sizeDelta = new Vector2(55,70);
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(parent.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
         newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz+22.5f,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0.5f,0.5f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


        if(tshirtCounter%4 == 0){
            RectTransform tshirtPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            tshirtPanelRect.sizeDelta = new Vector2(tshirtPanelRect.rect.width,tshirtPanelRect.rect.height + 75);
           // tshirtPanelRect.localPosition = new Vector3(tshirtPanelRect.anchoredPosition.x,tshirtPanelRect.anchoredPosition.y + 75,0 );
           RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
           wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 75);
            
        }

    }
}
