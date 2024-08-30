using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public List<ZigzagStyle> zigzagStyles; // List of different zigzag styles

    private void Start()
    {
        if (zigzagStyles.Count == 0)
        {
            Debug.LogError("No zigzag styles provided!");
            return;
        }
        // Start the animation with a random style
        PlayZigzagAnimation(GetRandomZigzagStyle());
    }

    void PlayZigzagAnimation(ZigzagStyle style)
    {
        // Create a sequence for the zigzag rotation
        Sequence rotationSequence = DOTween.Sequence();

        // Calculate time for each half of a zigzag
        float halfDuration = style.duration / (2 * style.zigzagCount);

        // Add rotation tweens to the sequence
        for (int i = 0; i < style.zigzagCount; i++)
        {
            rotationSequence.Append(transform.DORotate(new Vector3(0, 0, style.angle), halfDuration, RotateMode.LocalAxisAdd)
                .SetEase(style.easeType)
                .OnComplete(() => Debug.Log("Rotation to angle completed")));

            rotationSequence.Append(transform.DORotate(new Vector3(0, 0, -style.angle), halfDuration, RotateMode.LocalAxisAdd)
                .SetEase(style.easeType)
                .OnComplete(() => Debug.Log("Rotation back completed")));
        }

        // Restart the animation with a new random style after completion
        rotationSequence.OnKill(() => PlayZigzagAnimation(GetRandomZigzagStyle()));

        // Optional: Add a delay before starting the sequence
        rotationSequence.PrependInterval(0.0f);
    }

    ZigzagStyle GetRandomZigzagStyle()
    {
        // Randomly select a style from the list
        return zigzagStyles[Random.Range(0, zigzagStyles.Count)];
    }
}

[System.Serializable]
public class ZigzagStyle
{
    public float duration = 2f; // Duration of one zigzag cycle
    public float angle = 45f; // Angle of rotation
    public int zigzagCount = 5; // Number of zigzags
    public Ease easeType = Ease.InOutSine; // Type of easing for smoothness
}