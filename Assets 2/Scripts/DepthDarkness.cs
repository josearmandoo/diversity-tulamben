using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthDarkness : MonoBehaviour
{
    private GameObject GameSystemObj;
    private DepthMeter DepthScript;

    public Image targetImage; // The image whose alpha will be changed
    public float minFloatValue = 3.0f;
    public float maxFloatValue = 60.0f;
    public float maxAlpha = 170.0f / 255.0f; // 170 out of 255 for RGBA

    private float currentValue;

    private void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        DepthScript = GameSystemObj.GetComponent<DepthMeter>();
    }

    void Update()
    {
        // This is where you'd set the currentValue based on your game logic
        // For now, let's simulate it with a random value within the range
        currentValue = DepthScript.depthInMeters*-1f;

        UpdateAlpha(currentValue);
    }

    void UpdateAlpha(float value)
    {
        // Clamp the value to be within the min and max range
        value = Mathf.Clamp(value, minFloatValue, maxFloatValue);

        // Calculate the alpha based on the current value
        float alpha = Mathf.Lerp(0, maxAlpha, (value - minFloatValue) / (maxFloatValue - minFloatValue));

        // Set the new alpha value to the image
        Color color = targetImage.color;
        color.a = alpha;
        targetImage.color = color;
    }
}
