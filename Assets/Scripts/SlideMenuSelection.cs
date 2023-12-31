﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMenuSelection : MonoBehaviour
{
    private int currentItem;

    void Start()
    {
        this.Reset();
    }

    public void ChangeItem(int _change)
    {
        int nbItems = transform.childCount;
        transform.GetChild(currentItem).gameObject.SetActive(false);
        currentItem += _change;
        currentItem = (currentItem%nbItems + nbItems)%nbItems;
        transform.GetChild(currentItem).gameObject.SetActive(true);
    }

    public void Reset()
    {
        foreach (Transform child in transform) child.gameObject.SetActive(false);
        if (transform.childCount > 0) transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("Selector reset with " + transform.childCount.ToString() + " children");
    }

    public void CenterChildren()
    {
        foreach (Transform child in transform)
        {
            RectTransform rect = child.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            child.localPosition = new Vector3(0, 0, 0);
        }
    }
}


