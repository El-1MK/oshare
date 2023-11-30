using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class ColorPickerRaw : MonoBehaviour
{
    public TextMeshProUGUI DebugText;
    public ColorEvent OnColorPreview;
    public ColorEvent OnColorSelect;

    RectTransform Rect;
    // Start is called before the first frame update
    Texture2D ColorTexture;
    void Start()
    {
        Rect = GetComponent<RectTransform>();
        ColorTexture = GetComponent<RawImage>().mainTexture as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        ColorTexture = GetComponent<RawImage>().mainTexture as Texture2D;
        if(RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition, Camera.main))
        {

        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, Camera.main, out delta);
        //Overlay specs

        string debug = "mousePosition"+Input.mousePosition;
        debug += "<br>delta=" + delta;

        float width = Rect.rect.width;
        float height = Rect.rect.height;
        delta+= new Vector2(width * .5f, height * .5f);
        debug += "<br>offsetdelta=" + delta;

        float x = Mathf.Clamp(delta.x / width,0f,1f);
        float y = Mathf.Clamp(delta.y / height,0f,1f);
        debug += "<br>x=" + x + " y =" + y;

        int texX = Mathf.RoundToInt(x * ColorTexture.width);
        int texY = Mathf.RoundToInt(y * ColorTexture.height);
        debug += "<br>texX=" + texX + " texY =" + texY;

        Color color = ColorTexture.GetPixel(texX,texY);

        DebugText.color = color;
        DebugText.text = debug;

        OnColorPreview?.Invoke(color);

        if(Input.GetMouseButtonDown(0))
        {
            OnColorSelect?.Invoke(color);
        }
        }
    }
}
