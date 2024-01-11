using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRater : MonoBehaviour
{
    private int nbStars;
    private System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        nbStars = 0;
        rand = new System.Random();
        foreach (Transform child in transform) child.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetStars(int newNbStars) {
      transform.GetChild(nbStars).gameObject.SetActive(false);
      nbStars = newNbStars % 5;
      Debug.Log(nbStars);
      transform.GetChild(nbStars).gameObject.SetActive(true);
    }

    public void RandomRating() {
        Debug.Log("foo");
        this.SetStars(rand.Next());   
    }

    public void ColorRating(Cloth[] outfit){
        Debug.Log("Outfit longeur "+outfit.Length);
        List<Cloth> coloredClothes = new List<Cloth>();

        foreach(Cloth cloth in outfit){
            if(!coloredClothes.Exists(c => Math.Abs(c.red - cloth.red) <= 64/256 ||
            Math.Abs(c.green - cloth.green) <= 64/256 ||
            Math.Abs(c.blue - cloth.red) <= 64/256)){
                coloredClothes.Add(cloth);
                Debug.Log("Sprite de l'objet ajouté"+cloth.sprite);
            }
        }

        Debug.Log("Longueur de la liste couleurs différentes "+coloredClothes.Count);

        if(coloredClothes.Count > 3){
            this.SetStars(4 - coloredClothes.Count + 3);
        }else if(coloredClothes.Count <= 1){
            this.SetStars(3);
        }else{
            this.SetStars(4);
        }
    }


    public void PatternRating(Cloth[] outfit){
        string[] patterns = new string[0];

        foreach(Cloth cloth in outfit){
            if(Array.Exists(patterns, pat => pat == cloth.pattern)){
                patterns[patterns.Length]=cloth.pattern;
            }
        }

        if(Array.Exists(patterns,pat => pat == "plain")){
            this.SetStars(4 - (patterns.Length-2));
        }else{
            this.SetStars(4 - (patterns.Length-1));
        }
    }


    public void OriginalityRating(Cloth[] outfit){
        string[] panos = new string[0];

        foreach(Cloth cloth in outfit){
            if(Array.Exists(panos, pano => pano == cloth.style)){
                panos[panos.Length]=cloth.style;
            }
        }

        if(Array.Exists(panos,pano => pano == "basic")){
            this.SetStars(4 - (panos.Length-2));
        }else{
            this.SetStars(4 - (panos.Length-1));
        }
    }

    public void VibeRating(Cloth[] outfit){
        int nbStars = 0;
        if(Array.Exists(outfit, cloth => cloth.sprite.Contains("blouse") &&
            cloth.pattern == "flower" &&
            (cloth.red >= 223 && (cloth.green >= 19 && cloth.green <= 83) && (cloth.green >= 172 && cloth.green <= 236)))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth.sprite.Contains("hat") &&
            cloth.pattern == "plain" &&
            (cloth.red >= 223 && cloth.green >= 223  && cloth.green >= 223 ))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth.sprite.Contains("blazer") &&
            cloth.pattern == "check" &&
            (cloth.red >= 223 && cloth.green <= 32  && cloth.green <= 32 ))){
                nbStars +=1;
        }


        this.SetStars(nbStars);
    }
}
