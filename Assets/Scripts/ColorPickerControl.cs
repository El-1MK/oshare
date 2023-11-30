using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ColorPickerControl : MonoBehaviour
{
    public float currentHue, currentSat, currentVal;

    [SerializeField]
    private RawImage hueImage,satValImage,outputImage;

    public Slider hueSlider;

    private Texture2D hueTexture, svTexture, outputTexture;

    [SerializeField]
    MeshRenderer changeThisColour;

    private void Start(){
        CreateHueImage();
        CreateSVImage();
        hueSlider.onValueChanged.AddListener (delegate {UpdateSVImage ();});

    }

    private void CreateHueImage()
    {
        hueTexture = new Texture2D(1,16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "HueTexture";

        for(int i=0; i < hueTexture.height; i++)
        {
            hueTexture.SetPixel(0,i,Color.HSVToRGB((float)i/hueTexture.height,1,1f));
        }

        hueTexture.Apply();
        currentHue = 0;

        hueImage.texture = hueTexture;
    }

    private void CreateSVImage()
    {
        svTexture = new Texture2D(16, 16);
        svTexture.wrapMode = TextureWrapMode.Clamp;
        svTexture.name = "SatValTexture";

        for(int y=0; y < svTexture.height; y++)
        {
            for(int x=0; x < svTexture.height; x++)
        {
            svTexture.SetPixel(x,y,Color.HSVToRGB(currentHue,(float)x/svTexture.width,(float)y/svTexture.height));
        }
        }

        svTexture.Apply();
        currentSat = 0;
        currentVal = 0;

        satValImage.texture = svTexture;
    }

    public void UpdateSVImage()
    {
        
        currentHue = hueSlider.value;
        Debug.Log("HueValue: " + currentHue);

        for(int y=0; y < svTexture.height; y++)
        {
            for(int x=0; x < svTexture.height; x++)
        {
            svTexture.SetPixel(x,y,Color.HSVToRGB(currentHue,(float)x/svTexture.width,(float)y/svTexture.height));
        }
        }
        
        svTexture.Apply();

    }


}
