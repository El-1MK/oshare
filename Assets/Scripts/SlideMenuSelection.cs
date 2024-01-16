using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMenuSelection : MonoBehaviour
{
    private int currentItem;
    public int nbItems;

    void Start()
    {
        this.Reset();
    }

    public void ChangeItem(int _change)
    {
        nbItems = transform.childCount;
        transform.GetChild(currentItem).gameObject.SetActive(false);
        currentItem += _change;
        currentItem = (currentItem%nbItems + nbItems)%nbItems;
        transform.GetChild(currentItem).gameObject.SetActive(true);
    }

    public void Reset()
    {
        foreach (Transform child in transform) child.gameObject.SetActive(false);
        if (transform.childCount > 0) transform.GetChild(0).gameObject.SetActive(true);
        nbItems = transform.childCount;

    }

    public void CenterChildren(Vector3 scaling)
    {
        foreach (Transform child in transform)
        {
            RectTransform rect = child.GetComponent<RectTransform>();
            Image image = child.GetComponent<Image>();

            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            if(image.sprite.ToString().Contains("longsock")){
                rect.localScale = new Vector3(1.1f, 1.1f, 0f);
            }else if(image.sprite.ToString().Contains("scarf")){
                rect.localScale = new Vector3(0.8f, 0.8f, 0f);
            }else{
                rect.localScale = scaling;
            }
            child.localPosition = new Vector3(0.0f, 0.0f, 0f);
            image.preserveAspect = true;
        }

        RectTransform innerHolder = transform.GetComponent<RectTransform>();
        innerHolder.offsetMin = new Vector2(0, 0);
        innerHolder.offsetMax = new Vector2(0, 10);
        //innerHolder.offsetMax = new Vector2(innerHolder.offsetMax.x, 10);
    }

    public int GetIndex() {return currentItem;}
}


