using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoActive : MonoBehaviour
{
    public GameObject followObject; // Assign the 2D object in the Inspector
    public bool isFollowing;

    private GameObject GameSystemObj;
    private PlayerBarStats PlayerBarScript;

    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        PlayerBarScript = GameSystemObj.GetComponent<PlayerBarStats>();
    }

    void Update()
    {
        // Check if the right mouse button is held down
        if (Input.GetMouseButtonDown(1) && PlayerBarScript.currentBattery > 0f)
        {
            PlayerBarScript.isBatteryDepleting = true;
            isFollowing = true;
            if (followObject != null)
            {
                Cursor.visible = false;
                followObject.SetActive(true); // Show the object
            }
        }
        if (Input.GetMouseButtonUp(1) || PlayerBarScript.currentBattery == 0f)
        {
            PlayerBarScript.isBatteryDepleting = false;
            Destroy(GameObject.FindGameObjectWithTag("MinigameObj"));
            isFollowing = false;
            if (followObject != null)
            {
                Cursor.visible = true;
                followObject.SetActive(false); // Hide the object
            }
        }

        
    }

    private void FixedUpdate()
    {
        // If the object is active and should follow the mouse
        if (isFollowing && followObject != null)
        {
            FollowMousePosition();
        }
    }

    void FollowMousePosition()
    {
        // Convert the mouse position to world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z to 0 since we're in 2D

        // Update the object's position to follow the mouse
        followObject.transform.position = mousePosition;
    }
}
