using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMenuSelection : MonoBehaviour
{
  private int currentItem;

  private void SelectItem(int _index)
  {
    for (int i = 0; i < transform.childCount; i++)
    {
      transform.GetChild(i).gameObject.SetActive(i == _index);
    }
  }

  public void ChangeItem(int _change)
  {
    currentItem += _change;
    SelectItem(currentItem);
  }
}
