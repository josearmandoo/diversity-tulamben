using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBnF : MonoBehaviour
{
    public float speed = 3.0f; // Speed of the movement
    public float distance = 100.0f; // Distance to move from the starting point in pixels

    private RectTransform rectTransform;
    private Vector2 startPosition;
    private bool movingRight = true;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if (movingRight)
        {
            rectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;
            if (rectTransform.anchoredPosition.x >= startPosition.x + distance)
            {
                movingRight = false;
            }
        }
        else
        {
            rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;
            if (rectTransform.anchoredPosition.x <= startPosition.x)
            {
                movingRight = true;
            }
        }
    }
}
