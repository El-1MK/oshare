using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

public class AddCloth : MonoBehaviour, IDataPersistence
{

    private static int offsettopHoriz = 550;
    private static int offsettopVert = 600;
    private static int offsetlegwearHoriz = 330;
    private static int offsetlegwearVert = 750;
    private static int offsetouterwearHoriz = 425;
    private static int offsetouterwearVert = 650;
    private static int offsetshoesHoriz = 540;
    private static int offsetshoesVert = 420;
    private static int offsetsocksHoriz = 540;
    private static int offsetsocksVert = 550;
    private static int offsetheadgearHoriz = 540;
    private static int offsetheadgearVert = 420;
    private static int offsetaccessoriesHoriz = 540;
    private static int offsetaccessoriesVert = 650;


    public int topCounter = 0;
    public int legwearCounter = 0;
    public int outerwearCounter = 0;
    public int shoesCounter = 0;
    public int socksCounter = 0;
    public int headgearCounter = 0;

    public int accessoriesCounter = 0;



    public List<Cloth> wardrobe = new List<Cloth>();

    public Image imageCurrent;

    private GameObject imageAddedToScene;

    public GameObject topFloor;
    public GameObject legwearFloor;
    public GameObject outerwearFloor;
    public GameObject headgearFloor;
    public GameObject accessoriesFloor;
    public GameObject shoesFloor;
    public GameObject socksFloor;
    public GameObject extraPanel;
    public GameObject extraText;
    private float topHeight;
    private float legwearHeight;
    private float outerwearHeight;
    private float shoesHeight;
    private float socksHeight;
    private float headgearHeight;
    private float accessoriesHeight;

    public List<Sprite> availableTshirts;
    public List<Sprite> availableMarcels;
    public List<Sprite> availableBlouses;
    public List<Sprite> availableLongsleeves;
    public List <Sprite> availablePants;
    public List <Sprite> availableJogging;
    public List <Sprite> availableJeans;
    public List <Sprite> availableSkirt;
    public List <Sprite> availableBlazer;
    public List <Sprite> availableCoat;
    public List <Sprite> availableSweat;
    public List <Sprite> availableTurtleneck;
    public List <Sprite> availableBaskets;
    public List <Sprite> availableBoots;
    public List <Sprite> availableShoes;
    public List <Sprite> availableSocks;
    public List <Sprite> availableLongsocks;
    public List <Sprite> availableCap;
    public List <Sprite> availableScarf;
    public List <Sprite> availableHat;
    public List <Sprite> availableAccessories;

    

    public TMPro.TextMeshProUGUI text;

    public List <string> categories = new List<string>(){"top","legwear","shoes","socks","accessories", "headgear","outerwear"};

    public string currentPattern = "plain";

    public void LoadData(GameData data )
    {
        text.text = "Tops";
        this.wardrobe = data.wardrobe;
        this.topCounter = data.wardrobe.Where(c=>c.category == "top").Count();
        this.legwearCounter = data.wardrobe.Where(c=>c.category == "legwear").Count();
        this.outerwearCounter = data.wardrobe.Where(c=>c.category == "outerwear").Count();
        this.shoesCounter = data.wardrobe.Where(c=>c.category == "shoe").Count();
        this.socksCounter = data.wardrobe.Where(c=>c.category == "sock").Count();
        this.headgearCounter = data.wardrobe.Where(c=>c.category == "headgear").Count();
        this.accessoriesCounter = data.wardrobe.Where(c=>c.category == "accessory").Count();
        List<Cloth> tops = data.wardrobe.FindAll(c=>c.category == "top");
        List<Cloth> legwear = data.wardrobe.FindAll(c=>c.category == "legwear");
        List<Cloth> outerwear = data.wardrobe.FindAll(c=>c.category == "outerwear");
        List<Cloth> shoes = data.wardrobe.FindAll(c=>c.category == "shoe");
        List<Cloth> socks = data.wardrobe.FindAll(c=>c.category == "sock");
        List<Cloth> headgear = data.wardrobe.FindAll(c=>c.category == "headgear");
        List<Cloth> accessories = data.wardrobe.FindAll(c=>c.category == "accessory");
        for(int i=0;i<legwear.Count;i++)
        {
            loadCloth( legwear[i].sprite,legwear[i].red,legwear[i].green,legwear[i].blue,legwear[i].albedo,legwear[i].category,legwear[i].pattern,legwear[i].style,i);
        }
        for(int i=0;i<tops.Count;i++)
        {
            loadCloth( tops[i].sprite,tops[i].red,tops[i].green,tops[i].blue,tops[i].albedo,tops[i].category,tops[i].pattern,tops[i].style,i,tops[i].extra);
        }
        for(int i=0;i<outerwear.Count;i++)
        {
            loadCloth( outerwear[i].sprite,outerwear[i].red,outerwear[i].green,outerwear[i].blue,outerwear[i].albedo,outerwear[i].category,outerwear[i].pattern,outerwear[i].style,i);
        }
        for(int i=0;i<shoes.Count;i++)
        {
            loadCloth( shoes[i].sprite,shoes[i].red,shoes[i].green,shoes[i].blue,shoes[i].albedo,shoes[i].category,shoes[i].pattern,shoes[i].style,i);
        }
        for(int i=0;i<socks.Count;i++)
        {
            loadCloth( socks[i].sprite,socks[i].red,socks[i].green,socks[i].blue,socks[i].albedo,socks[i].category,socks[i].pattern,socks[i].style,i);
        }
        for(int i=0;i<headgear.Count;i++)
        {
            loadCloth( headgear[i].sprite,headgear[i].red,headgear[i].green,headgear[i].blue,headgear[i].albedo,headgear[i].category,headgear[i].pattern,headgear[i].style,i);
        }
        for(int i=0;i<accessories.Count;i++)
        {
            loadCloth( accessories[i].sprite,accessories[i].red,accessories[i].green,accessories[i].blue,accessories[i].albedo,accessories[i].category,accessories[i].pattern,accessories[i].style,i);
        }
    }

    public void SaveData(ref GameData data)
    {
        data.wardrobe = this.wardrobe;
    }
    
    public void addCloth()
    {
        if(imageCurrent.sprite.ToString().Contains("tshirt") || imageCurrent.sprite.ToString().Contains("marcel") || imageCurrent.sprite.ToString().Contains("blouse")|| imageCurrent.sprite.ToString().Contains("longsleeve")){
        int nbRow = topCounter/3;

        float currentCursorVert = -nbRow * offsettopVert;

        float currentCursorHoriz = 63.5f +(topCounter%3)*(offsettopHoriz+63.5f);

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        newImage.sprite = imageCurrent.sprite;

        if(imageCurrent.sprite.ToString().Contains("longsleeve")){
            newImage.rectTransform.sizeDelta = new Vector2(500,600);
        }else{
            newImage.rectTransform.sizeDelta = new Vector2(550,600);
        }
        newImage.color = imageCurrent.color;
        if(imageCurrent.sprite.ToString().Contains("pocket")){
            wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"top",currentPattern,"basic","pocket"));
        }else{
            if(imageCurrent.sprite.ToString().Contains("marcel")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"top",currentPattern,"sporty"));
            }else if(imageCurrent.sprite.ToString().Contains("blouse")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"top",currentPattern,"formal"));
            }else if(imageCurrent.sprite.ToString().Contains("longsleeve")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"top",currentPattern,"basic"));
            }else if(imageCurrent.sprite.ToString().Contains("tshirt")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"top",currentPattern,"basic"));
            }
        }

        imageAddedToScene.transform.SetParent(topFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
         newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0f,1f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


        if(topCounter%3 == 0){
            RectTransform topPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            topPanelRect.sizeDelta = new Vector2(topPanelRect.rect.width,topPanelRect.rect.height + 700);
           // topPanelRect.localPosition = new Vector3(topPanelRect.anchoredPosition.x,topPanelRect.anchoredPosition.y + 75,0 );
           RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
           wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 700);
           topHeight += 700;
            
        }
        topCounter++;
        }else if(imageCurrent.sprite.ToString().Contains("pants") || imageCurrent.sprite.ToString().Contains("jogging") || imageCurrent.sprite.ToString().Contains("skirt")|| imageCurrent.sprite.ToString().Contains("jeans")){
            int nbRow = legwearCounter/3;

            float currentCursorVert = -50f - nbRow * offsetlegwearVert;

            float currentCursorHoriz = 233f + (legwearCounter%3)*(offsetlegwearHoriz+233f);

            imageAddedToScene = new GameObject();
            Image newImage = imageAddedToScene.AddComponent<Image>();
            newImage.sprite = imageCurrent.sprite;
            if(imageCurrent.sprite.ToString().Contains("pants") ||imageCurrent.sprite.ToString().Contains("jogging")|| imageCurrent.sprite.ToString().Contains("jeans") ){
            newImage.rectTransform.sizeDelta = new Vector2(330,700);
            }else{
                newImage.rectTransform.sizeDelta = new Vector2(330,270);
            }
            newImage.color = imageCurrent.color;
            if(imageCurrent.sprite.ToString().Contains("pants")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"legwear",currentPattern,"formal"));
            }else if(imageCurrent.sprite.ToString().Contains("jogging")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"legwear",currentPattern,"sporty"));
            }else if(imageCurrent.sprite.ToString().Contains("jeans")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"legwear",currentPattern,"casual"));
            }else if(imageCurrent.sprite.ToString().Contains("skirt")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"legwear",currentPattern,"basic"));
            }

            imageAddedToScene.transform.SetParent(legwearFloor.transform);
            newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
            newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
            newImage.rectTransform.anchorMin = new Vector2(0,1);
            newImage.rectTransform.anchorMax = new Vector2(0,1);
            newImage.rectTransform.pivot = new Vector2(0f,1f);
            if(imageCurrent.sprite.ToString().Contains("pants") ||imageCurrent.sprite.ToString().Contains("jogging") || imageCurrent.sprite.ToString().Contains("jeans")){
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);
            }else{
                newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert-150f,0);
            }


            if(legwearCounter%3 == 0){
                RectTransform legwearPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
                legwearPanelRect.sizeDelta = new Vector2(legwearPanelRect.rect.width,legwearPanelRect.rect.height + 650);
               // topPanelRect.localPosition = new Vector3(topPanelRect.anchoredPosition.x,topPanelRect.anchoredPositon.y + 75,0 );
               RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
               wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 650);
                legwearHeight+=650;
            }
            legwearCounter++;
        }else if(imageCurrent.sprite.ToString().Contains("blazer") || imageCurrent.sprite.ToString().Contains("coat")|| imageCurrent.sprite.ToString().Contains("sweat") ||imageCurrent.sprite.ToString().Contains("turtleneck")){
            int nbRow = outerwearCounter/3;
        
            float currentCursorVert = -20f - nbRow * offsetouterwearVert;

            float currentCursorHoriz = 161.25f + (outerwearCounter%3)*(offsetouterwearHoriz+161.25f);

            imageAddedToScene = new GameObject();
            Image newImage = imageAddedToScene.AddComponent<Image>();
            newImage.sprite = imageCurrent.sprite;
            newImage.rectTransform.sizeDelta = new Vector2(425,600);
            newImage.color = imageCurrent.color;

            if(imageCurrent.sprite.ToString().Contains("blazer")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"outerwear",currentPattern,"formal"));
            }else if(imageCurrent.sprite.ToString().Contains("coat")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"outerwear",currentPattern,"basic"));
            }else if(imageCurrent.sprite.ToString().Contains("sweat")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"outerwear",currentPattern,"casual"));
            }else if(imageCurrent.sprite.ToString().Contains("turtleneck")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"outerwear",currentPattern,"formal"));
            }
            imageAddedToScene.transform.SetParent(outerwearFloor.transform);
            newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
            newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
            newImage.rectTransform.anchorMin = new Vector2(0,1);
            newImage.rectTransform.anchorMax = new Vector2(0,1);
            newImage.rectTransform.pivot = new Vector2(0f,1f);
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


            if(outerwearCounter%3 == 0){
                RectTransform outerwearPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
                outerwearPanelRect.sizeDelta = new Vector2(outerwearPanelRect.rect.width,outerwearPanelRect.rect.height + 650);
               RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
               wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 650);
                outerwearHeight+=650;
            }
            outerwearCounter++;


    }else if(imageCurrent.sprite.ToString().Contains("sneaker") || imageCurrent.sprite.ToString().Contains("boot") || imageCurrent.sprite.ToString().Contains("shoe")){
            int nbRow = shoesCounter/3;
        
            float currentCursorVert = -160f - nbRow * offsetshoesVert;

            float currentCursorHoriz = 75f + (shoesCounter%3)*(offsetshoesHoriz+75f);

            imageAddedToScene = new GameObject();
            Image newImage = imageAddedToScene.AddComponent<Image>();
            newImage.sprite = imageCurrent.sprite;
            newImage.rectTransform.sizeDelta = new Vector2(540,260);
            newImage.color = imageCurrent.color;

            if(imageCurrent.sprite.ToString().Contains("sneaker")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"shoe",currentPattern,"sporty"));
            }else if(imageCurrent.sprite.ToString().Contains("boot")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"shoe",currentPattern,"basic"));
            }else if(imageCurrent.sprite.ToString().Contains("shoe")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"shoe",currentPattern,"formal"));
            }
            imageAddedToScene.transform.SetParent(shoesFloor.transform);
            newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
            newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
            newImage.rectTransform.anchorMin = new Vector2(0,1);
            newImage.rectTransform.anchorMax = new Vector2(0,1);
            newImage.rectTransform.pivot = new Vector2(0f,1f);
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


            if(shoesCounter%3 == 0){
                RectTransform shoesPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
                shoesPanelRect.sizeDelta = new Vector2(shoesPanelRect.rect.width,shoesPanelRect.rect.height + 450);
               RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
               wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 450);
                shoesHeight+=450;
            }
            shoesCounter++;


    }else if(imageCurrent.sprite.ToString().Contains("sock")){
            int nbRow = socksCounter/3;
        
            float currentCursorVert = -160f - nbRow * offsetsocksVert;

            float currentCursorHoriz = 75f + (socksCounter%3)*(offsetsocksHoriz+75f);

            imageAddedToScene = new GameObject();
            Image newImage = imageAddedToScene.AddComponent<Image>();
            newImage.sprite = imageCurrent.sprite;

            if(imageCurrent.sprite.ToString().Contains("longsock")){
                newImage.rectTransform.sizeDelta = new Vector2(540,500);
            }else{
                newImage.rectTransform.sizeDelta = new Vector2(540,260);
            }
            newImage.color = imageCurrent.color;

            if(imageCurrent.sprite.ToString().Contains("longsock")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"sock",currentPattern,"basic"));
            }else if(imageCurrent.sprite.ToString().Contains("sock")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"sock",currentPattern,"basic"));
            }
            imageAddedToScene.transform.SetParent(socksFloor.transform);
            newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
            newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
            newImage.rectTransform.anchorMin = new Vector2(0,1);
            newImage.rectTransform.anchorMax = new Vector2(0,1);
            newImage.rectTransform.pivot = new Vector2(0f,1f);
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


            if(socksCounter%3 == 0){
                RectTransform socksPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
                socksPanelRect.sizeDelta = new Vector2(socksPanelRect.rect.width,socksPanelRect.rect.height + 550);
               RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
               wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 550);
                socksHeight+=550;
            }
            socksCounter++;


    }else if(imageCurrent.sprite.ToString().Contains("cap") || imageCurrent.sprite.ToString().Contains("hat")){
            int nbRow = headgearCounter/3;

            float currentCursorVert = -160f - nbRow * offsetheadgearVert;

            float currentCursorHoriz = 75f + (headgearCounter%3)*(offsetheadgearHoriz+75f);

            imageAddedToScene = new GameObject();
            Image newImage = imageAddedToScene.AddComponent<Image>();
            newImage.sprite = imageCurrent.sprite;
            newImage.rectTransform.sizeDelta = new Vector2(540,260);
            newImage.color = imageCurrent.color;

            if(imageCurrent.sprite.ToString().Contains("cap")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"headgear",currentPattern,"sporty"));
            }else if(imageCurrent.sprite.ToString().Contains("hat")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"headgear",currentPattern,"casual"));
            }
            imageAddedToScene.transform.SetParent(headgearFloor.transform);
            newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
            newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
            newImage.rectTransform.anchorMin = new Vector2(0,1);
            newImage.rectTransform.anchorMax = new Vector2(0,1);
            newImage.rectTransform.pivot = new Vector2(0f,1f);
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


            if(headgearCounter%3 == 0){
                RectTransform headgearPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
                headgearPanelRect.sizeDelta = new Vector2(headgearPanelRect.rect.width,headgearPanelRect.rect.height + 450);
               RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
               wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 450);
                headgearHeight+=450;
            }
            headgearCounter++;


    }else if(imageCurrent.sprite.ToString().Contains("glasses") || imageCurrent.sprite.ToString().Contains("necklace") || imageCurrent.sprite.ToString().Contains("scarf")){
            int nbRow = accessoriesCounter/3;

            float currentCursorVert = -160f - nbRow * offsetaccessoriesVert;

            float currentCursorHoriz = 75f + (accessoriesCounter%3)*(offsetaccessoriesHoriz+75f);

            imageAddedToScene = new GameObject();
            Image newImage = imageAddedToScene.AddComponent<Image>();
            newImage.sprite = imageCurrent.sprite;
            if(imageCurrent.sprite.ToString().Contains("glasses") ){
            newImage.rectTransform.sizeDelta = new Vector2(540,260);
            }else if(imageCurrent.sprite.ToString().Contains("necklace") ){
                newImage.rectTransform.sizeDelta = new Vector2(540,260);
            }else{
                newImage.rectTransform.sizeDelta = new Vector2(540,600);
            }
            newImage.color = imageCurrent.color;

            if(imageCurrent.sprite.ToString().Contains("glasses")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"accessory","plain","basic"));
            }else if(imageCurrent.sprite.ToString().Contains("necklace")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"accessory","plain","basic"));
            }else if(imageCurrent.sprite.ToString().Contains("scarf")){
                wardrobe.Add(new Cloth(imageCurrent.sprite.ToString(),imageCurrent.color.r,imageCurrent.color.g,imageCurrent.color.b,imageCurrent.color.a,"accessory",currentPattern,"basic"));
            }
            imageAddedToScene.transform.SetParent(accessoriesFloor.transform);
            newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
            newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
            newImage.rectTransform.anchorMin = new Vector2(0,1);
            newImage.rectTransform.anchorMax = new Vector2(0,1);
            newImage.rectTransform.pivot = new Vector2(0f,1f);
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


            if(accessoriesCounter%3 == 0){
                RectTransform accessoriesPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
                accessoriesPanelRect.sizeDelta = new Vector2(accessoriesPanelRect.rect.width,accessoriesPanelRect.rect.height + 650);
               RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
               wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 650);
                accessoriesHeight+=650;
            }
            accessoriesCounter++;
    }
    }

    public void loadCloth(string image,float red,float green,float blue,float albedo,string category,string pattern,string style, int index,string extra = null)
    {
        if(category == "top"){
        int nbRow = (topCounter-(topCounter - index))/3;

        float currentCursorVert = -nbRow * offsettopVert;

        float currentCursorHoriz = 63.5f + ((topCounter - (topCounter - index))%3)*(offsettopHoriz+63.5f);

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        if(image.Contains("tshirt")){
        if(pattern == "plain"){newImage.sprite = (extra == "pocket") ? availableTshirts[5] : availableTshirts[0];}
        if(pattern == "check"){newImage.sprite = (extra == "pocket") ? availableTshirts[6] : availableTshirts[1];}
        if(pattern == "stripe"){newImage.sprite = (extra == "pocket") ? availableTshirts[7] : availableTshirts[2];}
        if(pattern == "dot"){newImage.sprite = (extra == "pocket") ? availableTshirts[8] : availableTshirts[3];}
        if(pattern == "flower"){newImage.sprite = (extra == "pocket") ? availableTshirts[9] : availableTshirts[4];}
        }else if(image.Contains("marcel")){
        if(pattern == "plain")newImage.sprite = availableMarcels[0];
        if(pattern == "stripe")newImage.sprite = availableMarcels[1];
        if(pattern == "dot")newImage.sprite = availableMarcels[2];
        if(pattern == "check")newImage.sprite = availableMarcels[3];
        if(pattern == "flower")newImage.sprite = availableMarcels[4];
        }else if(image.Contains("blouse")){
        if(pattern == "plain"){newImage.sprite = (extra == "pocket") ? availableBlouses[5] : availableBlouses[0];}
        if(pattern == "stripe"){newImage.sprite = (extra == "pocket") ? availableBlouses[6] : availableBlouses[1];}
        if(pattern == "dot"){newImage.sprite = (extra == "pocket") ? availableBlouses[7] : availableBlouses[2];}
        if(pattern == "check"){newImage.sprite = (extra == "pocket") ? availableBlouses[8] : availableBlouses[3];}
        if(pattern == "flower"){newImage.sprite = (extra == "pocket") ? availableBlouses[9] : availableBlouses[4];}
        }else if(image.Contains("longsleeve")){
        if(pattern == "plain")newImage.sprite = availableLongsleeves[0];
        if(pattern == "stripe")newImage.sprite = availableLongsleeves[1];
        if(pattern == "dot")newImage.sprite = availableLongsleeves[2];
        if(pattern == "check")newImage.sprite = availableLongsleeves[3];
        if(pattern == "flower")newImage.sprite = availableLongsleeves[4];
        }




        if(image.Contains("longsleeve")){
            newImage.rectTransform.sizeDelta = new Vector2(500,600);
        }else{
            newImage.rectTransform.sizeDelta = new Vector2(550,600);
        }
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(topFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
         newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0f,1f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);


         if(index > 0 && index%3==0){
            RectTransform topPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            topPanelRect.sizeDelta = new Vector2(topPanelRect.rect.width,topPanelRect.rect.height + 700);
           // topPanelRect.localPosition = new Vector3(topPanelRect.anchoredPosition.x,topPanelRect.anchoredPosition.y + 75,0 );
           RectTransform wardrobePanelRect = imageAddedToScene.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
           wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,wardrobePanelRect.rect.height + 700);
           topHeight = wardrobePanelRect.rect.height;
            
        }
        }else if(category == "legwear"){
        int nbRow = (legwearCounter-(legwearCounter - index))/3;
        int nblegwearRow = 0;
        if((legwearCounter - (legwearCounter - index)) > 0 ) nblegwearRow = (240/(54*(legwearCounter - (legwearCounter - index))));
        float currentCursorVert = -50f - nbRow * offsetlegwearVert;

        float currentCursorHoriz = 233f + ((legwearCounter - (legwearCounter - index))%3)*(offsetlegwearHoriz+233f);

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
         if(image.Contains("pants")){
        if(pattern == "plain")newImage.sprite = availablePants[0];
        if(pattern == "stripe")newImage.sprite = availablePants[1];
        if(pattern == "dot")newImage.sprite = availablePants[2];
        if(pattern == "check")newImage.sprite = availablePants[3];
        if(pattern == "flower")newImage.sprite = availablePants[4];
        }else if(image.Contains("jogging")){
        if(pattern == "plain")newImage.sprite = availableJogging[0];
        if(pattern == "stripe")newImage.sprite = availableJogging[1];
        if(pattern == "dot")newImage.sprite = availableJogging[2];
        if(pattern == "check")newImage.sprite = availableJogging[3];
        if(pattern == "flower")newImage.sprite = availableJogging[4];
        }else if(image.Contains("jeans")){
        if(pattern == "plain")newImage.sprite = availableJeans[0];
        if(pattern == "stripe")newImage.sprite = availableJeans[1];
        if(pattern == "dot")newImage.sprite = availableJeans[2];
        if(pattern == "check")newImage.sprite = availableJeans[3];
        if(pattern == "flower")newImage.sprite = availableJeans[4];
        }else if(image.Contains("skirt")){
        if(pattern == "plain")newImage.sprite = availableSkirt[0];
        if(pattern == "stripe")newImage.sprite = availableSkirt[1];
        if(pattern == "dot")newImage.sprite = availableSkirt[2];
        if(pattern == "check")newImage.sprite = availableSkirt[3];
        if(pattern == "flower")newImage.sprite = availableSkirt[4];
        }



        
        if(image.Contains("pants") ||image.Contains("jogging")||image.Contains("jeans") ){
            newImage.rectTransform.sizeDelta = new Vector2(330,700);
            }else{
                newImage.rectTransform.sizeDelta = new Vector2(330,270);
            }
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(legwearFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
        newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0f,1f);
        if(image.Contains("pants") ||image.Contains("jogging")||image.Contains("jeans") ){
            newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);
            }else{
                newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert-150f,0);
            }

        
        if(index > 0 && index%3==0){

            RectTransform legwearPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            legwearPanelRect.sizeDelta = new Vector2(legwearPanelRect.rect.width,legwearPanelRect.rect.height + 650);
            legwearHeight = legwearPanelRect.rect.height;            
        }
    }else if(category == "outerwear"){
        int nbRow = (outerwearCounter-(outerwearCounter - index))/3;
        int nbouterwearRow = 0;
        if((outerwearCounter - (outerwearCounter - index)) > 0 ) nbouterwearRow = (240/(54*(outerwearCounter - (outerwearCounter - index))));
        float currentCursorVert = -20f - nbRow * offsetouterwearVert;

        float currentCursorHoriz = 161.25f + ((outerwearCounter - (outerwearCounter - index))%3)*(offsetouterwearHoriz+161.25f);

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
         if(image.Contains("blazer")){
        if(pattern == "plain")newImage.sprite = availableBlazer[0];
        if(pattern == "stripe")newImage.sprite = availableBlazer[1];
        if(pattern == "dot")newImage.sprite = availableBlazer[2];
        if(pattern == "check")newImage.sprite = availableBlazer[3];
        if(pattern == "flower")newImage.sprite = availableBlazer[4];
        }else if(image.Contains("coat")){
        if(pattern == "plain")newImage.sprite = availableCoat[0];
        if(pattern == "stripe")newImage.sprite = availableCoat[1];
        if(pattern == "dot")newImage.sprite = availableCoat[2];
        if(pattern == "check")newImage.sprite = availableCoat[3];
        if(pattern == "flower")newImage.sprite = availableCoat[4];
        }else if(image.Contains("sweat")){
        if(pattern == "plain")newImage.sprite = availableSweat[0];
        if(pattern == "stripe")newImage.sprite = availableSweat[1];
        if(pattern == "dot")newImage.sprite = availableSweat[2];
        if(pattern == "check")newImage.sprite = availableSweat[3];
        if(pattern == "flower")newImage.sprite = availableSweat[4];
        }else if(image.Contains("turtleneck")){
        if(pattern == "plain")newImage.sprite = availableTurtleneck[0];
        if(pattern == "stripe")newImage.sprite = availableTurtleneck[1];
        if(pattern == "dot")newImage.sprite = availableTurtleneck[2];
        if(pattern == "check")newImage.sprite = availableTurtleneck[3];
        if(pattern == "flower")newImage.sprite = availableTurtleneck[4];
        }


        
        newImage.rectTransform.sizeDelta = new Vector2(425,600);
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(outerwearFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
        newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0f,1f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);

        
        if(index > 0 && index%3==0){

            RectTransform outerwearPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            outerwearPanelRect.sizeDelta = new Vector2(outerwearPanelRect.rect.width,outerwearPanelRect.rect.height + 550);
            outerwearHeight = outerwearPanelRect.rect.height;            
        }
    }else if(category == "shoe"){
        int nbRow = (shoesCounter-(shoesCounter - index))/3;
        
        float currentCursorVert = -160f - nbRow * offsetshoesVert;

        float currentCursorHoriz = 75f + ((shoesCounter - (shoesCounter - index))%3)*(offsetshoesHoriz+75f);

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
         if(image.Contains("sneaker")){
        if(pattern == "plain")newImage.sprite = availableBaskets[0];
        if(pattern == "stripe")newImage.sprite = availableBaskets[1];
        if(pattern == "dot")newImage.sprite = availableBaskets[2];
        if(pattern == "check")newImage.sprite = availableBaskets[3];
        if(pattern == "flower")newImage.sprite = availableBaskets[4];
        }else if(image.Contains("boot")){
        if(pattern == "plain")newImage.sprite = availableBoots[0];
        if(pattern == "stripe")newImage.sprite = availableBoots[1];
        if(pattern == "dot")newImage.sprite = availableBoots[2];
        if(pattern == "check")newImage.sprite = availableBoots[3];
        if(pattern == "flower")newImage.sprite = availableBoots[4];
        }else if(image.Contains("shoe")){
        if(pattern == "plain")newImage.sprite = availableShoes[0];
        if(pattern == "stripe")newImage.sprite = availableShoes[1];
        if(pattern == "dot")newImage.sprite = availableShoes[2];
        if(pattern == "check")newImage.sprite = availableShoes[3];
        if(pattern == "flower")newImage.sprite = availableShoes[4];
        }


        
        newImage.rectTransform.sizeDelta = new Vector2(540,260);
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(shoesFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
        newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0f,1f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);

        
        if(index > 0 && index%3==0){

            RectTransform shoesPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            shoesPanelRect.sizeDelta = new Vector2(shoesPanelRect.rect.width,shoesPanelRect.rect.height + 550);
            shoesHeight = shoesPanelRect.rect.height;            
        }
    }else if(category == "sock"){
        int nbRow = (socksCounter-(socksCounter - index))/3;
       
        float currentCursorVert = -160f - nbRow * offsetsocksVert;

        float currentCursorHoriz = 75f + ((socksCounter - (socksCounter - index))%3)*(offsetsocksHoriz+75f);

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
        if(image.Contains("longsock")){
        if(pattern == "plain")newImage.sprite = availableLongsocks[0];
        if(pattern == "stripe")newImage.sprite = availableLongsocks[1];
        if(pattern == "dot")newImage.sprite = availableLongsocks[2];
        if(pattern == "check")newImage.sprite = availableLongsocks[3];
        if(pattern == "flower")newImage.sprite = availableLongsocks[4];
        }else if(image.Contains("sock")){
        if(pattern == "plain")newImage.sprite = availableSocks[0];
        if(pattern == "stripe")newImage.sprite = availableSocks[1];
        if(pattern == "dot")newImage.sprite = availableSocks[2];
        if(pattern == "check")newImage.sprite = availableSocks[3];
        if(pattern == "flower")newImage.sprite = availableSocks[4];
        }

        
        if(image.Contains("longsock")){
                newImage.rectTransform.sizeDelta = new Vector2(540,500);
            }else{
                newImage.rectTransform.sizeDelta = new Vector2(540,260);
            }
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(socksFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
        newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0f,1f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);

        
        if(index > 0 && index%3==0){

            RectTransform socksPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            socksPanelRect.sizeDelta = new Vector2(socksPanelRect.rect.width,socksPanelRect.rect.height + 450);
            socksHeight = socksPanelRect.rect.height;            
        }
    }else if(category == "headgear"){
        int nbRow = (headgearCounter-(headgearCounter - index))/3;
        int nbheadgearRow = 0;
        if((headgearCounter - (headgearCounter - index)) > 0 ) nbheadgearRow = (240/(71*(headgearCounter - (headgearCounter - index))));
        float currentCursorVert = -160f - nbRow * offsetheadgearVert;

        float currentCursorHoriz = 75f + ((headgearCounter - (headgearCounter - index))%3)*(offsetheadgearHoriz+75f);

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
         if(image.Contains("cap")){
        if(pattern == "plain")newImage.sprite = availableCap[0];
        if(pattern == "stripe")newImage.sprite = availableCap[1];
        if(pattern == "dot")newImage.sprite = availableCap[2];
        if(pattern == "check")newImage.sprite = availableCap[3];
        if(pattern == "flower")newImage.sprite = availableCap[4];
        }else if(image.Contains("hat")){
        if(pattern == "plain")newImage.sprite = availableHat[0];
        if(pattern == "stripe")newImage.sprite = availableHat[1];
        if(pattern == "dot")newImage.sprite = availableHat[2];
        if(pattern == "check")newImage.sprite = availableHat[3];
        if(pattern == "flower")newImage.sprite = availableHat[4];
        }


        
        newImage.rectTransform.sizeDelta = new Vector2(540,260);
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(headgearFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
        newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0f,1f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);

        
        if(index > 0 && index%3==0){

            RectTransform headgearPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            headgearPanelRect.sizeDelta = new Vector2(headgearPanelRect.rect.width,headgearPanelRect.rect.height + 450);
            headgearHeight = headgearPanelRect.rect.height;            
        }
    }else if(category == "accessory"){
        int nbRow = (accessoriesCounter-(accessoriesCounter - index))/3;
        int nbaccessoriesRow = 0;
        if((accessoriesCounter - (accessoriesCounter - index)) > 0 ) nbaccessoriesRow = (240/(71*(accessoriesCounter - (accessoriesCounter - index))));
        float currentCursorVert = -160f - nbRow * offsetaccessoriesVert;

        float currentCursorHoriz = 75f + ((accessoriesCounter - (accessoriesCounter - index))%3)*(offsetaccessoriesHoriz+75f);

        imageAddedToScene = new GameObject();
        Image newImage = imageAddedToScene.AddComponent<Image>();
         if(image.Contains("glasses")){newImage.sprite = availableAccessories[0];newImage.rectTransform.sizeDelta = new Vector2(540,260);
        }else if(image.Contains("necklace")){newImage.sprite = availableAccessories[1];newImage.rectTransform.sizeDelta = new Vector2(540,260);
        }

        if(image.Contains("scarf")){
        if(pattern == "plain")newImage.sprite = availableScarf[0];
        if(pattern == "stripe")newImage.sprite = availableScarf[1];
        if(pattern == "dot")newImage.sprite = availableScarf[2];
        if(pattern == "check")newImage.sprite = availableScarf[3];
        if(pattern == "flower")newImage.sprite = availableScarf[4];
        newImage.rectTransform.sizeDelta = new Vector2(540,600);
        }


        
        
        newImage.color = new Color(red,green,blue,albedo);


        imageAddedToScene.transform.SetParent(accessoriesFloor.transform);
        newImage.rectTransform.localScale = new Vector3(1f,1f,1f);
        newImage.rectTransform.localPosition = new Vector3(currentCursorHoriz,currentCursorVert,0);
        newImage.rectTransform.anchorMin = new Vector2(0,1);
        newImage.rectTransform.anchorMax = new Vector2(0,1);
        newImage.rectTransform.pivot = new Vector2(0f,1f);
        newImage.rectTransform.localPosition = new Vector3(newImage.rectTransform.localPosition.x,currentCursorVert,0);

        
        if(index > 0 && index%3==0){

            RectTransform accessoriesPanelRect = imageAddedToScene.transform.parent.gameObject.GetComponent<RectTransform>();
            accessoriesPanelRect.sizeDelta = new Vector2(accessoriesPanelRect.rect.width,accessoriesPanelRect.rect.height + 650);
            accessoriesHeight = accessoriesPanelRect.rect.height;            
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
        extraPanel.SetActive(false);
        extraText.SetActive(false);
        string category = "";
        if(imageCurrent.sprite.ToString().Contains("blouse") || 
        imageCurrent.sprite.ToString().Contains("marcel") ||
        imageCurrent.sprite.ToString().Contains("tshirt") ||
        imageCurrent.sprite.ToString().Contains("longsleeve")
        ){
        text.text="Tops";
        topFloor.SetActive(true);
        RectTransform wardrobePanelRect = topFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,topHeight);
        if(imageCurrent.sprite.ToString().Contains("tshirt")
        || imageCurrent.sprite.ToString().Contains("blouse")){extraPanel.SetActive(true);extraText.SetActive(true);}
        }else if(imageCurrent.sprite.ToString().Contains("skirt") ||
        imageCurrent.sprite.ToString().Contains("pants") ||
        imageCurrent.sprite.ToString().Contains("jogging") ||
        imageCurrent.sprite.ToString().Contains("jeans")){
        text.text="Legwear";
        legwearFloor.SetActive(true);
        RectTransform wardrobePanelRect = legwearFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,legwearHeight+800);
        }else if(imageCurrent.sprite.ToString().Contains("blazer") ||
        imageCurrent.sprite.ToString().Contains("coat") ||
        imageCurrent.sprite.ToString().Contains("sweat") ||
        imageCurrent.sprite.ToString().Contains("turtleneck")){
        text.text="Outerwear";
        outerwearFloor.SetActive(true);
        RectTransform wardrobePanelRect = outerwearFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,outerwearHeight+600);
        }else if(imageCurrent.sprite.ToString().Contains("boot") ||
        imageCurrent.sprite.ToString().Contains("sneaker") ||
        imageCurrent.sprite.ToString().Contains("shoe")){
        text.text="Shoes";
        shoesFloor.SetActive(true);
        RectTransform wardrobePanelRect = shoesFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,shoesHeight);
        }else if(imageCurrent.sprite.ToString().Contains("sock") || imageCurrent.sprite.ToString().Contains("longsock")){
        text.text="Socks";
        socksFloor.SetActive(true);
        RectTransform wardrobePanelRect = socksFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,socksHeight+650);
        }else if(imageCurrent.sprite.ToString().Contains("necklace") ||
        imageCurrent.sprite.ToString().Contains("glasses")||
        imageCurrent.sprite.ToString().Contains("scarf") ){
        text.text="Accessories";
        accessoriesFloor.SetActive(true);
        RectTransform wardrobePanelRect = accessoriesFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,accessoriesHeight+900);
        }else if(imageCurrent.sprite.ToString().Contains("cap") ||
        imageCurrent.sprite.ToString().Contains("hat")){
        text.text="Headgear";
        headgearFloor.SetActive(true);
        RectTransform wardrobePanelRect = headgearFloor.transform.parent.gameObject.GetComponent<RectTransform>();
        wardrobePanelRect.sizeDelta = new Vector2(wardrobePanelRect.rect.width,headgearHeight+500);
        }
    }

    public void changePattern(string patt){
        this.currentPattern = patt;
    }
}
