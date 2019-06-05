/*
 * 
 * Add this script to player
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{

    //drunk boolean from somewhere?


    private IPlayerCommand Shoot;
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Jump;

    KeyCode keyShoot;
    KeyCode keyRight;
    KeyCode keyLeft;
    KeyCode keyJump;

    // Start is called before the first frame update
    void Start()
    {
        this.Shoot = this.gameObject.AddComponent<PlayerShootCommand>();
        this.Right = ScriptableObject.CreateInstance<MovePlayerRight>();
        this.Left = ScriptableObject.CreateInstance<MovePlayerLeft>();
        this.Jump = ScriptableObject.CreateInstance<PlayerJump>();

        resetControls();
    }

    // Update is called once per frame
    void Update()
    {
        if(drunk)
        {
            randomizeControls();
        }
        else
        {
            resetControls();
        }
        if (Input.GetKeyDown(keyShoot))
        {
            this.Shoot.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(keyRight))
        {
            this.Right.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(keyLeft))
        {
            this.Left.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(keyJump))
        {
            this.Jump.Execute(this.gameObject);
        }
    }

    // Randomizes right, left, jump controls - guarantees at least one key will be different
    void randomizeControls()
    {
        KeyCode temp;
        while(keyRight == KeyCode.D && keyLeft == KeyCode.A && keyJump == KeyCode.W)
        {
            float rand = Random.value;
            if (rand < 0.5f)
            {
                temp = keyLeft;
                keyLeft = keyJump;
                keyJump = temp;
            }

            rand = Random.value;
            if (rand < 0.5f)
            {
                temp = keyRight;
                keyRight = keyJump;
                keyJump = temp;
            }
        }
    }

    void resetControls()
    {
        keyShoot = KeyCode.Space;
        keyRight = KeyCode.D;
        keyLeft = KeyCode.A;
        keyJump = KeyCode.W;
    }

}
