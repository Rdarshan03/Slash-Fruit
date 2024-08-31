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


    private float waveSpeed_0;
    private float waveAmplitude_0;
    private float waveFrequency_0;
    public float speed;
    private void Start()
    {
        speed = waveSpeed;
    }
    void Update()
    {
        // Set the fill amount on the material
      currentFillAmount = Mathf.Lerp(currentFillAmount, fillAmount, speed / 2 * Time.deltaTime);
        waveSpeed_0 = Mathf.Lerp(waveSpeed_0, waveSpeed, speed / 2 * Time.deltaTime);
        waveAmplitude_0 = Mathf.Lerp(waveAmplitude_0, waveAmplitude, speed / 2 * Time.deltaTime);
        waveFrequency_0 = Mathf.Lerp(waveFrequency_0, waveFrequency, speed / 2 * Time.deltaTime);

        // Set the smoothly updated fill amount on the material
        spriteRenderer.material.SetFloat("_FillAmount", currentFillAmount);
        spriteRenderer.material.SetColor("_FillColor", fillColor);

        spriteRenderer.material.SetFloat("_WaveSpeed", waveSpeed_0);
        spriteRenderer.material.SetFloat("_WaveAmplitude", waveAmplitude_0);
        spriteRenderer.material.SetFloat("_WaveFrequency", waveFrequency_0);
    }
}
