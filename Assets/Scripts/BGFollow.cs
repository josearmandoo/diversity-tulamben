using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollow : MonoBehaviour
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
        // z is -80 to appear on cam layer
        // place the left and right bound of map for below if cond
        if(playerPos.y < -4.4f)
        {
            this.transform.position = new Vector3(this.transform.position.x, playerPos.y);
        }

        if (playerPos.x > 6 && playerPos.x < 190)
        {
            this.transform.position = new Vector3(playerPos.x, this.transform.position.y);
        }
        

        //this.transform.position = new Vector3(this.transform.position.x, playerPos.y);

    }
}
