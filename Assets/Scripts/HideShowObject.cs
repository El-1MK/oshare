using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowObject : MonoBehaviour
{
    public GameObject toHide;

    public void hide(){
        toHide.SetActive(false);
    }

    public void show(){
        toHide.SetActive(true);
    }
}
