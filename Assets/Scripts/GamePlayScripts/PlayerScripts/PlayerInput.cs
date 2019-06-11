using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GamePlay.Player.Command
{
    public class PlayerInput : MonoBehaviour
    {
        private IPlayerCommand Shoot;
        private IPlayerCommand Right;
        private IPlayerCommand Left;
        private IPlayerCommand Jump;

        private IPlayerCommand[] Commands;

        PlayerAnimation animator;

        KeyCode keyShoot;
        KeyCode keyRight;
        KeyCode keyLeft;
        KeyCode keyJump;

        // Start is called before the first frame update
        void Start()
        {
            //this.Shoot = this.gameObject.AddComponent<PlayerShootCommand>();
            this.Right = ScriptableObject.CreateInstance<MovePlayerRight>();
            this.Left = ScriptableObject.CreateInstance<MovePlayerLeft>();
            this.Jump = ScriptableObject.CreateInstance<PlayerJump>();

            // Array that will hold commands.
            this.Commands = new IPlayerCommand[3];

            this.Commands[0] = this.Right;
            this.Commands[1] = this.Left;
            this.Commands[2] = this.Jump;

            animator = gameObject.GetComponent<PlayerAnimation>();

            resetControls();
        }

        // Update is called once per frame
        void Update()
        {

            // Movement script utilizes [-1,1] value of Input.GetAxis() so it I only
            // needed to implement for the axis itself, not certain direction.
            if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0.01f)
            {
                this.Left.ButtonDown(this.gameObject);
                animator.MoveLeft();
            }
            else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0.01f)
            {
                this.Left.ButtonHold(this.gameObject);
            }
            else if (Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") < 0.01f)
            {
                this.Left.ButtonUp(this.gameObject);
                animator.Idle();
            }

            if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0.01f)
            {
                this.Right.ButtonDown(this.gameObject);
                animator.MoveRight();
            }
            else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0.01f)
            {
                this.Right.ButtonHold(this.gameObject);
            }
            else if (Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") > 0.01f)
            {
                this.Right.ButtonUp(this.gameObject);
                animator.Idle();
            }

            if ((Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0.0f) || (Input.GetButtonDown("Jump")))
            {
                this.Jump.ButtonDown(this.gameObject);
            }
            else if ((Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0.0f) || (Input.GetButton("Jump")))
            {
                this.Jump.ButtonHold(this.gameObject);
            }
            else if ((Input.GetButtonUp("Vertical") && Input.GetAxis("Vertical") > 0.0f) || (Input.GetButtonUp("Jump")))
            {
                this.Jump.ButtonUp(this.gameObject);
            }

        }

        // Randomizes right, left, jump controls - guarantees at least one key will be different
        public void randomizeControls()
        {
            
            // while (keyRight == KeyCode.D && keyLeft == KeyCode.A && keyJump == KeyCode.W)
            // {
            //     float rand = Random.value;
            //     if (rand < 0.5f)
            //     {
            //         temp = keyLeft;
            //         keyLeft = keyJump;
            //         keyJump = temp;
            //     }

            //     rand = Random.value;
            //     if (rand < 0.5f)
            //     {
            //         temp = keyRight;
            //         keyRight = keyJump;
            //         keyJump = temp;
            //     }
            // }

            // Shuffles commands and then assigns them.
            FisherYatesShuffle(Commands);
            this.Right = Commands[0];
            this.Left = Commands[1];
            this.Jump = Commands[2];
        }

        public void resetControls()
        {
            // keyShoot = KeyCode.Space;
            // keyRight = KeyCode.D;
            // keyLeft = KeyCode.A;
            // keyJump = KeyCode.W;
            this.Right = ScriptableObject.CreateInstance<MovePlayerRight>();
            this.Left = ScriptableObject.CreateInstance<MovePlayerLeft>();
            this.Jump = ScriptableObject.CreateInstance<PlayerJump>();
        }

        // https://stackoverflow.com/questions/9592166/unique-number-in-random/9593077#9593077.
        // Shuffles elements of Commands array.
        private static void FisherYatesShuffle<T>(T[] array)
        {
            System.Random r = new System.Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = r.Next(0, i + 1);
                T temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }

    }

}