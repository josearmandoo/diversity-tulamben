using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveWaterFloatFX : MonoBehaviour
{
    public float amplitude = 1f; // The height of the up and down movement
    public float frequency = 1f; // The speed of the up and down movement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Store the starting position
    }

    void Update()
    {
        // Calculate the new Y position
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Update the object's position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
