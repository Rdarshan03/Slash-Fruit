using UnityEngine;

public class SpriteFillVerticalWithColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [Range(0, 1)] public float fillAmount = 1.0f;
    public Color fillColor = new Color(0.0f, 0.5f, 1.0f, 1.0f); // Default light blue water color
    public float waveSpeed = 1.0f;
    public float waveAmplitude = 0.01f;
    public float waveFrequency = 10.0f;
    private float currentFillAmount;
    void Update()
    {
        // Set the fill amount on the material
      currentFillAmount = Mathf.Lerp(currentFillAmount, fillAmount, waveSpeed/2 * Time.deltaTime);

        // Set the smoothly updated fill amount on the material
        spriteRenderer.material.SetFloat("_FillAmount", currentFillAmount);

        // Set the fill color on the material
        spriteRenderer.material.SetColor("_FillColor", fillColor);

        // Set wave properties on the material
        spriteRenderer.material.SetFloat("_WaveSpeed", waveSpeed);
        spriteRenderer.material.SetFloat("_WaveAmplitude", waveAmplitude);
        spriteRenderer.material.SetFloat("_WaveFrequency", waveFrequency);
    }
}
