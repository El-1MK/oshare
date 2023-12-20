using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSelectedCloth : MonoBehaviour
{
    [SerializeField]
    private Sprite[] clothes = null;
    public SpriteRenderer renderer;

    private int index = 0;

    public int NBMAX_CLOTHES = 2;

    private void Start()
    {
        renderer.sprite = clothes[index];
    }

    public void nextCloth()
    {
        index++;
        if(index == NBMAX_CLOTHES){
            index = 0;
        }
            renderer.sprite = clothes[index];
    }

    public void previousCloth()
    {
        index--;
        if(index == -1){
            index = NBMAX_CLOTHES-1;
        }
            renderer.sprite = clothes[index];
    }
}
