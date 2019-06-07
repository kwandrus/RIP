using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        PlayerAnimation playerAnimation = gameObject.GetComponent<PlayerAnimation>();

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerMovement.Jump();
            playerAnimation.Jump();
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerMovement.MoveLeft();
            playerAnimation.MoveLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Crouch?
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerMovement.MoveRight();
            playerAnimation.MoveRight();
        }
    }
}