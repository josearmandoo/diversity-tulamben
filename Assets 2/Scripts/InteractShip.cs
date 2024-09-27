using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractShip : MonoBehaviour
{
    private bool isPlayerInRange;

    public GameObject Text;

    public GameObject ShipCanvas;

    private GameObject GameSystemObj;
    private GameSystem GameSystemScript;

    private void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        GameSystemScript = GameSystemObj.GetComponent<GameSystem>();
    }

    // This function is called when another collider enters the trigger collider attached to this object.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(true);
            isPlayerInRange = true;
            Debug.Log("Player is in range, press 'F' to interact.");
        }
    }

    // This function is called when another collider exits the trigger collider attached to this object.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(false);
            isPlayerInRange = false;
            Debug.Log("Player is out of range.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            GameSystemScript.isPause = true;
            Interact();
        }
    }

    // Define the interaction behavior here
    private void Interact()
    {
        ShipCanvas.SetActive(true);
    }
}
