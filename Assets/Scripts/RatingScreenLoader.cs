using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingScreenLoader : MonoBehaviour
{
    Vector3 [] scalings = new Vector3 [] {
        new Vector3(0.35f, 0.35f, 0f),
        new Vector3(1.7f, 1.6f, 0f),
        new Vector3(0.4f, 0.4f, 0f),
        new Vector3(0.4f, 0.4f, 0f),
        new Vector3(1.5f, 1.5f, 0f),
        new Vector3(1.5f, 1.2f, 0f),
        new Vector3(0.4f, 0.4f, 0f),
    };

    public List<SlideMenuSelection> selectors;
    public AddCloth addcloth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        for (int i = 0; i < 7; i++)
        {
            Debug.Log(scalings[i]);
            SlideMenuSelection selector = selectors[i];
            selector.Reset();
            selector.CenterChildren(this.scalings[i]);
        }
    }
    
    public Cloth[] GetOutfit()
    {
        Cloth[] outfit = new Cloth[7];
        string[] categories = new string[] {
            "accessory",
            "top",
            "sock",
            "headgear",
            "outerwear",
            "legwear",
            "shoe"
        };
        for (int i = 0; i < 7; i++)
        {
            outfit[i] = addcloth.wardrobe.FindAll(c=>c.category == categories[i])[selectors[i].GetIndex()];
        }
        return outfit;
    }
    
}
