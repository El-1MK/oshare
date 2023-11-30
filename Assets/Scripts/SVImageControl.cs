using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SVImageControl : MonoBehaviour
{
    [SerializeField]
    private Image pickerImage;

    private RawImage SVImage;

    private ColorPickerControl CC;

    private void Awake()
    {
        SVImage = GetComponent<RawImage>();
        CC = FindObjectOfType<ColorPickerControl>();
    }

}
