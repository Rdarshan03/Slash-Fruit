using UnityEngine;

public class SpriteFillVerticalWithColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [Range(0, 1)] public float fillAmount = 1.0f;
    public Color fillColor = Color.red; // Default fill color is red

    void Update()
    {
        // Set the fill amount on the material
        spriteRenderer.material.SetFloat("_FillAmount", fillAmount);

        // Set the fill color on the material
        spriteRenderer.material.SetColor("_FillColor", fillColor);
    }
}
