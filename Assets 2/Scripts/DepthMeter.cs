using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DepthMeter : MonoBehaviour
{
    public Transform playerTransform;  // Reference to the player's transform
    public TextMeshProUGUI depthText;  // Reference to the TextMeshPro text object
    public float depthInMeters;

    private const float unitsToMeters = 0.5f; // Conversion factor: 10 units in Unity equals 5 meters

    void Update()
    {
        UpdateDepth();
    }

    void UpdateDepth()
    {
        // Calculate depth in meters based on player's Y position
        depthInMeters = playerTransform.position.y * unitsToMeters;

        // Display the depth, ensuring it's positive (depth cannot be negative)
        depthText.text = Mathf.Abs(depthInMeters).ToString("0.0") + "m";
    }
}
