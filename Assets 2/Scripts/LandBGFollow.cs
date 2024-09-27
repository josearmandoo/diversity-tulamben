using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandBGFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos = player.transform.position;

        if (playerPos.x > 6 && playerPos.x < 190)
        {
            this.transform.position = new Vector3(playerPos.x+4f, this.transform.position.y);
        }

        //this.transform.position = new Vector3(playerPos.x+4f, this.transform.position.y);

    }
}
