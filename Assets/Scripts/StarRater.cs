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
        List<Cloth> coloredClothes = new List<Cloth>();

        foreach(Cloth cloth in outfit){
            if(!coloredClothes.Exists(c =>
            Math.Abs(c.red - cloth.red) <= 64/256f &&
            Math.Abs(c.green - cloth.green) <= 64/256f &&
            Math.Abs(c.blue - cloth.blue) <= 64/256f)){
                coloredClothes.Add(cloth);
            }
        }

        if(coloredClothes.Count == 3){
            this.SetStars(4);
        }else if(coloredClothes.Count <= 1){
            this.SetStars(1);
        }else if(coloredClothes.Count == 2){
            this.SetStars(4);
        }else{
            this.SetStars(coloredClothes.Count <= 6 ? 4 - coloredClothes.Count + 2 : 0);
        }
    }


    public void PatternRating(Cloth[] outfit){
        List<string> patterns = new List<string>();

        foreach(Cloth cloth in outfit){
            if(!patterns.Exists(pat => pat == cloth.pattern)){
                Debug.Log(cloth.sprite);
                patterns.Add(cloth.pattern);
            }
        }

        Debug.Log("Pattern Count "+patterns.Count);
        foreach(string s in patterns){
            Debug.Log(s);
        }

        if(patterns.Exists(pat => pat == "plain")){
            if(patterns.Count == 1){
                this.SetStars(4 - (patterns.Count));
            }else if(patterns.Count == 2){
                this.SetStars(4);
            }else{
                this.SetStars(4 - (patterns.Count));
            }
        }else{
            this.SetStars(4 - (patterns.Count));
        }
    }


    public void OriginalityRating(Cloth[] outfit){
        List<string> panos = new List<string>();

        foreach(Cloth cloth in outfit){
            if(!panos.Exists(pano => pano == cloth.style)){
                Debug.Log(cloth.sprite);
                panos.Add(cloth.style);
            }
        }


        if(panos.Exists(pano => pano == "basic")&&panos.Count >= 2){
                Debug.Log("OUI");
                Debug.Log(panos.Count);
                this.SetStars(4 - (panos.Count -2));
        }else if(panos.Count == 1){
            this.SetStars(4);
        }else{
            this.SetStars(4 - (panos.Count));
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
