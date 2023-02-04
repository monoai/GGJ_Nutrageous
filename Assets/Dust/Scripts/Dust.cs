using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField]
    private Texture2D dustTexture;
    [SerializeField]
    private SpriteRenderer dustSpriteRenderer;

    private Sprite dustSpriteInstance;
    private Texture2D dustTextureInstance;
    private Color32[] pixelColors;
    int width;
    int height;

    void Start()
    {
        pixelColors = dustTexture.GetPixels32();
        dustTextureInstance = new Texture2D(dustTexture.width, dustTexture.height);
        dustTextureInstance.SetPixels32(pixelColors);
        dustTextureInstance.Apply();
        dustSpriteInstance = Sprite.Create(dustTextureInstance, new Rect(0.0f, 0.0f, dustTexture.width, dustTexture.height), new Vector2(0.5f, 0.5f), dustSpriteRenderer.sprite.pixelsPerUnit);
        dustSpriteRenderer.sprite = dustSpriteInstance;
        width = dustTextureInstance.width;
        height = dustTextureInstance.height;
    }
  
    public void SweepPosition(Vector2 pixelPosition, int sweepRadius, int opacityStrength)
    {
        bool hasSwept = false;
        for (int offsetX = -sweepRadius; offsetX <= sweepRadius; offsetX++)
        {
            int posX = (int)pixelPosition.x + offsetX;
            int rangeY = (int)Mathf.Ceil(Mathf.Sqrt(sweepRadius * sweepRadius - offsetX * offsetX));

            if (posX >= 0 && posX < width)
            {
                for (int offsetY = -rangeY; offsetY <= rangeY; offsetY++)
                {
                    int posY = (int)pixelPosition.y + offsetY;
                    if (posY >= 0 && posY < height)
                    {
                        int index = posY * width + posX;
                        int alpha = pixelColors[index].a;
                        if (pixelColors[index].a != 0)
                        {
                            pixelColors[index].a = (byte)Mathf.Max(0, alpha - opacityStrength);
                            hasSwept = true;
                        }
                    }
                }
            }
        }

        if (hasSwept)
        {
            dustTextureInstance.SetPixels32(pixelColors);
            dustTextureInstance.Apply();
        }
    }

    void OnDestroy()
    {
        DestroyImmediate(dustSpriteInstance);
        DestroyImmediate(dustTextureInstance);
    }
}
