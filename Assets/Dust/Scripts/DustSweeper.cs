using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSweeper : MonoBehaviour
{
    [SerializeField]
    private int sweepRadius = 20;
    [Range(0, 255)]
    [SerializeField]
    private int opacityStrength = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, 2.0f);
            if (hit.collider != null)
            {
                Vector2 pixelPosition = GetPositionInLocalDustPixelPosition(hit);
                if (pixelPosition != Vector2.positiveInfinity)
                {
                    Dust dustComponent = hit.collider.GetComponent<Dust>();
                    if (dustComponent != null)
                    {
                        dustComponent.SweepPosition(pixelPosition, sweepRadius, opacityStrength);
                    }
                }
            }

        }
    }

    Vector2 GetPositionInLocalDustPixelPosition(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            SpriteRenderer spriteRenderer = hit.collider.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                int textureHalfWidth = spriteRenderer.sprite.texture.width / 2;
                int textureHalfHeight = spriteRenderer.sprite.texture.height / 2;
                Vector2 objectCenter = hit.collider.transform.position;
                Vector2 worldDistanceImpactFromCenter = hit.point - objectCenter;
                Vector2 pixelImpact = worldDistanceImpactFromCenter * spriteRenderer.sprite.pixelsPerUnit + new Vector2(textureHalfWidth, textureHalfHeight);
                return pixelImpact;
            }
        }
        return Vector2.positiveInfinity;
    }
}
