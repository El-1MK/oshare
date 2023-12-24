using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMenuSelection : MonoBehaviour
{
    private int currentItem;
    // private GameObject prefab;
    // private List<Cloth> wardrobe = new List<Cloth>();
    //
    // void Start()
    // {
    //     this.wardrobe = data.wardrobe;
    //     this.tshirtCounter = data.wardrobe.Count;
    //     for(int i=0; i<data.wardrobe.Count; i++)
    //     {
    //         //loadCloth( wardrobe[i].sprite,wardrobe[i].red,wardrobe[i].green,wardrobe[i].blue,wardrobe[i].albedo,i);
    //         imageAddedToScene = Instantiate(prefab, this);
    //         Image newImage = imageAddedToScene.AddComponent<Image>();
    //         if(image.Contains("drawing"))newImage.sprite = availableClothes[0];
    //         if(image.Contains("pocket"))newImage.sprite = availableClothes[3];
    //         if(image.Contains("stripes"))newImage.sprite = availableClothes[1];
    //         if(image.Contains("dots"))newImage.sprite = availableClothes[2];
    //     }
    // }

    public void ChangeItem(int _change)
    {
        int nbItems = transform.childCount;
        transform.GetChild(currentItem).gameObject.SetActive(false);
        currentItem += _change;
        currentItem = (currentItem%nbItems + nbItems)%nbItems;
        transform.GetChild(currentItem).gameObject.SetActive(true);
    }
}


