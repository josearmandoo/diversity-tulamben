using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardFishMove : MonoBehaviour
{
    public float swimSpeed = 2.0f;  // Speed of swimming
    public float horizontalBound = 5.0f;  // Horizontal boundary
    public float verticalBound = 2.0f;  // Vertical boundary

    private Vector3 startPosition;
    private float time;
    private bool facingRight = true;

    void Start()
    {
        // Record the starting position
        startPosition = transform.position;
    }

    void Update()
    {
        // Update time
        time += Time.deltaTime;

        // Calculate new position using a sine wave for vertical movement and linear movement for horizontal
        float newX = startPosition.x + Mathf.PingPong(time * swimSpeed, horizontalBound * 2) - horizontalBound;
        float newY = startPosition.y + Mathf.Sin(time * swimSpeed) * verticalBound;

        // Check if we need to flip the fish
        if (newX > transform.position.x && !facingRight)
        {
            Flip();
        }
        else if (newX < transform.position.x && facingRight)
        {
            Flip();
        }

        // Update the position
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void Flip()
    {
        // Switch the way the fish is facing
        facingRight = !facingRight;

        // Multiply the fish's x local scale by -1 to flip it
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
