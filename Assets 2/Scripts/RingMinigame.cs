using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMinigame : MonoBehaviour
{
    public float shrinkSpeed = 1f; // Speed at which the ring shrinks
    public float targetSize = 0.5f; // The size at which the player must click
    public RingMinigameManager gameManager;
    public Transform framePos;

    private void Start()
    {
        shrinkSpeed = Random.Range(1.0f, 2.0f);
    }

    void Update()
    {
        // Shrink the ring over time
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if(transform.localScale.x > 6.5f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
                gameManager.OnRingMissed();
            }
        }

        // Check if the ring has reached the target size
        if (transform.localScale.x <= 6.5f)
        {
            // If the player clicks the ring
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
                gameManager.OnRingClicked();
            }
        }

        // Check if the ring has become too small
        if (transform.localScale.x <= 5.5)
        {
            Destroy(gameObject);
            gameManager.OnRingMissed();
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(framePos.position.x,framePos.position.y,framePos.position.z);
    }
}
