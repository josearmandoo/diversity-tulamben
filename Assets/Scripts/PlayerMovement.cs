using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float ascendSpeed = 5f;
    public float descendSpeed = 2f;
    public float fastDescendSpeed = 5f;
    public float horizontalSpeed = 3f;
    public float idleDescendSpeed = 1f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private GameObject GameSystemObj;
    private GameSystem GameSystemScript;
    private PlayerSavedStat SaveScript;
    private float notPause = 1f;
    private float multiplierItem = 1f;

    private bool floatingFX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        GameSystemScript = GameSystemObj.GetComponent<GameSystem>();
        SaveScript = GameSystemObj.GetComponent<PlayerSavedStat>();

        if (SaveScript.gameData.Flipper1)
        {
            multiplierItem = multiplierItem + 0.2f;
        }

        if (SaveScript.gameData.Flipper2)
        {
            multiplierItem = multiplierItem + 0.3f;
        }
    }

    void Update()
    {
        float verticalVelocity = -idleDescendSpeed;
        float horizontalVelocity = 0f;

        if (GameSystemScript.isPause)
        {
            notPause = 0f;
        }
        else
        {
            notPause = 1f;
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("Swim", 1);
        }
        else
        {
            anim.SetInteger("Swim", 0);
        }

        if (Input.GetMouseButton(1))
        {
            anim.SetBool("CameraActive", true);
        }
        else
        {
            anim.SetBool("CameraActive", false);
        }


        if (this.transform.position.y > 0)
        {
            floatingFX = true;
        }

        if (this.transform.position.y < -0.3)
        {
            floatingFX = false;
        }

        if (floatingFX)
        {
            verticalVelocity = -0.5f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            verticalVelocity = ascendSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalVelocity = -fastDescendSpeed;
        }

        if (Input.GetKey(KeyCode.A) && this.transform.position.x > -1.5f)
        {
            sprite.flipX = true;
            horizontalVelocity = -horizontalSpeed;
            if (verticalVelocity == -idleDescendSpeed)
            {
                verticalVelocity = -descendSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.D) && this.transform.position.x < 197.5f)
        {
            sprite.flipX = false;
            horizontalVelocity = horizontalSpeed;
            if (verticalVelocity == -idleDescendSpeed)
            {
                verticalVelocity = -descendSpeed;
            }
        }

        rb.velocity = new Vector2(horizontalVelocity*notPause* multiplierItem, verticalVelocity*notPause*multiplierItem);
    }
}
