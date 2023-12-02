using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMerger : MonoBehaviour
{
    [SerializeField] private Sprite[] spritesToMerge = null;
    [SerializeField] private SpriteRenderer finalSpriteRenderer = null;

    private Color color;

    private void Start()
    {
        Merge();
    }
    private void Merge()
    {
        Resources.UnloadUnusedAssets();
        var newText = new Texture2D(644,900);

        for(int x=0; x < newText.width; x++)
        {
            for(int y=0;y<newText.height;y++)
            {
                newText.SetPixel(x,y,new Color(1,1,1,0));
            }
        }

        for(int i=0;i<spritesToMerge.Length;i++)
        {
            for(int x=0; x < spritesToMerge[i].texture.width; x++)
        {
            for(int y=0;y<spritesToMerge[i].texture.height;y++)
            {
               
                if(spritesToMerge[i].texture.GetPixel(x,y).a == 0){
                    color = newText.GetPixel(x,y);

                }else{
                    color = spritesToMerge[i].texture.GetPixel(x,y);
                }

                newText.SetPixel(x,y,color);        
            }
        }
        }
    newText.Apply();
    var finalSprite = Sprite.Create(newText, new Rect(0,0,newText.width,newText.height), new Vector2(0.5f,0.5f));
    finalSprite.name = "Merged Sprite";
    finalSpriteRenderer.sprite = finalSprite;

    }

}
