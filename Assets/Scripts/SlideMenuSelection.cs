using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMenuSelection : MonoBehaviour
{
  private int currentItem;

  public void ChangeItem(int _change)
  {
    int nbItems = transform.childCount;
    transform.GetChild(currentItem).gameObject.SetActive(false);
    currentItem += _change;
    Debug.Log(currentItem);
    currentItem = (currentItem%nbItems + nbItems)%nbItems;
    Debug.Log(currentItem);
    transform.GetChild(currentItem).gameObject.SetActive(true);
  }
}
