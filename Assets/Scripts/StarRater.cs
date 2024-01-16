using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRater : MonoBehaviour
{
    public int nbStars;
    private System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        nbStars = 0;
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetStars(int newNbStars) {
      foreach (Transform child in transform) child.gameObject.SetActive(false);
      //transform.GetChild(nbStars).gameObject.SetActive(false);
      nbStars = newNbStars % 5;
      transform.GetChild(nbStars).gameObject.SetActive(true);
    }

    public void RandomRating() {
        Debug.Log("foo");
        this.SetStars(rand.Next());   
    }

    public void ColorRating(Cloth[] outfit){
        List<Cloth> coloredClothes = new List<Cloth>();

        foreach(Cloth cloth in outfit){
            if(cloth != null && !coloredClothes.Exists(c =>
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
            if(cloth != null && !patterns.Exists(pat => pat == cloth.pattern)){
                patterns.Add(cloth.pattern);
            }
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
            if(cloth != null && !panos.Exists(pano => pano == cloth.style)){
                panos.Add(cloth.style);
            }
        }


        if(panos.Exists(pano => pano == "basic")&&panos.Count >= 2){
                this.SetStars(4 - (panos.Count -2));
        }else if(panos.Count == 1){
            this.SetStars(4);
        }else{
            this.SetStars(4 - (panos.Count));
        }
    }

    public void VibeRating(Cloth[] outfit){
        int nbStars = 0;

        //Vibe set 1
        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("blouse") &&
            cloth.pattern == "flower" &&
            (cloth.red >= 223/256f && (cloth.green >= 0f && cloth.green <= 83/256f) && (cloth.blue >= 172/256f && cloth.blue <= 236/256f)))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("hat") &&
            cloth.pattern == "plain" &&
            (cloth.red <= 32/256f && cloth.green <= 32/256f  && cloth.blue <= 32/256f ))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("blazer") &&
            cloth.pattern == "check" &&
            (cloth.red >= 223/256f && cloth.green <= 32/256f  && cloth.blue <= 32/256f ))){
                nbStars +=1;
        }

        //Vibe set 2

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("cap") &&
            cloth.pattern == "plain" &&
            ((cloth.red >= 42/256f && cloth.red <= 106/256f) && (cloth.green >= 31/256f && cloth.green <= 95/256f)  && cloth.blue <= 41/256f ))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("sneaker") &&
            cloth.pattern == "plain" &&
            ((cloth.red >= 41/256f && cloth.red <= 103/256f) && (cloth.green >= 41/256f && cloth.green <= 103/256f)  && cloth.blue <= 41/256f ))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("jeans") &&
            cloth.pattern == "plain" &&
            ((cloth.red <= 60/256f) && (cloth.green <= 61/256f)  && cloth.blue <= 47/256f ))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("blouse") &&
            cloth.pattern == "check" &&
            (cloth.red >= 223/256f && cloth.green <= 32/256f  && cloth.blue <= 32/256f ))){
                nbStars +=1;
        }

        //Vibe set 3

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("pants") &&
            cloth.pattern == "plain" &&
            (cloth.red >= 223/256f && cloth.green >= 223/256f  && cloth.blue >= 223/256f ))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("blazer") &&
            cloth.pattern == "plain" &&
            (cloth.red >= 223/256f && cloth.green >= 223/256f  && cloth.blue >= 223/256f ))){
                nbStars +=1;
        }

        if(Array.Exists(outfit, cloth => cloth != null && cloth.sprite.Contains("turtleneck") &&
            cloth.pattern == "stripe" &&
            (cloth.red >= 223/256f && cloth.green >= 223/256f  && cloth.blue >= 223/256f ))){
                nbStars +=1;
        }


        this.SetStars(nbStars < 5 ? nbStars : 4);
    }
}
