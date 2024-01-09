using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class RaterScript : MonoBehaviour
{

    public Cloth[] outfit;
    
    public int ColorRating(){
        Cloth[] coloredClothes = new Cloth[0];

        foreach(Cloth cloth in outfit){
            if(Array.Exists(coloredClothes,  c => Math.Abs(c.red - cloth.red) <= 64 ||
            Math.Abs(c.green - cloth.green) <= 64 ||
            Math.Abs(c.blue - cloth.red) <= 64)){
                coloredClothes[coloredClothes.Length] = cloth;
            }
        }

        if(coloredClothes.Length > 3){
            return 4 - coloredClothes.Length + 3;
        }else if(coloredClothes.Length <= 1){
            return 3;
        }else{
            return 4;
        }
    }


    public int PatternRating(){
        string[] patterns = new string[0];

        foreach(Cloth cloth in outfit){
            if(Array.Exists(patterns, pat => pat == cloth.pattern)){
                patterns[patterns.Length]=cloth.pattern;
            }
        }

        if(Array.Exists(patterns,pat => pat == "plain")){
            return 4 - (patterns.Length-2);
        }else{
            return 4 - (patterns.Length-1);
        }
    }


    public int OriginalityRating(){
        float coef = 1.0f;
        bool isFlowered = false;
        bool isDotted = false;
        bool isChecked = false;
        bool isStripped = false;

        foreach(Cloth cloth in outfit){
            if(cloth.sprite.Contains("necklace") ||cloth.sprite.Contains("cap") || cloth.sprite.Contains("blouse")
            || cloth.sprite.Contains("scarf") || cloth.sprite.Contains("marcel") || cloth.sprite.Contains("longsock")
            || cloth.sprite.Contains("jogging") )
            coef += 0.2f;
            if(cloth.sprite.Contains("tshirt") ||cloth.sprite.Contains("coat") || cloth.sprite.Contains("pants")
            || cloth.sprite.Contains("longsleeve") )
            coef -= 0.1f;
            if((cloth.pattern == "flower" && !isFlowered) || (cloth.pattern == "dot" && !isDotted)){
            coef +=0.3f;
            }
            if((cloth.pattern == "check" && !isChecked) || (cloth.pattern == "stripe" && !isStripped)){
            coef +=0.1f;
            }
            if((cloth.red >= 223 && cloth.green >= 223 && cloth.blue >= 32) ||
                (cloth.red >= 223 && (cloth.green >= 19 && cloth.green <= 83) && (cloth.green >= 172 && cloth.green <= 236))  ||
                (cloth.red <= 32 && cloth.green >= 223 && cloth.blue <= 32)){
            coef +=0.3f;
            }
            if((cloth.red >= 223 && cloth.green >= 223 && cloth.blue >= 32) ||
                (cloth.red >= 223 && (cloth.green >= 19 && cloth.green <= 83) && (cloth.green >= 172 && cloth.green <= 236))  ||
                (cloth.red <= 32 && cloth.green >= 223 && cloth.blue <= 32)){
            coef +=0.3f;
            }

            float mean = (cloth.red + cloth.green + cloth.blue)/3;
            if((cloth.red < (mean + 50) ||cloth.red > (mean - 50))||
            (cloth.blue < (mean + 50) ||cloth.blue > (mean - 50))||
            (cloth.green < (mean + 50) ||cloth.green > (mean - 50)) ){
                coef -= 0.2f;
            }

        }

        return (int)Math.Floor(2.5f * coef);
    }

    public int VibeRating(){
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


        return nbStars;
    }


}


