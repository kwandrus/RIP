using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Command
{
    public class PlayerInput : MonoBehaviour
    {
        private IPlayerCommand Shoot;
        private IPlayerCommand Right;
        private IPlayerCommand Left;
        private IPlayerCommand Jump;

        Animator animator;

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
            //playerAnimation = gameObject.GetComponent<PlayerAnimation>();
            animator = gameObject.GetComponent<Animator>();

            resetControls();
        }

        // Update is called once per frame
        void Update()
        {
            var animator = this.gameObject.GetComponent<Animator>();

            // Movement script utilizes [-1,1] value of Input.GetAxis() so it I only
            // needed to implement for the axis itself, not certain direction.
            if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0.01f)
            {
                this.Left.ButtonDown(this.gameObject);
                animator.SetBool("isRunning", true);

            }
            else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0.01f)
            {
                this.Left.ButtonHold(this.gameObject);
            }
            else if (Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") < 0.01f)
            {
                this.Left.ButtonUp(this.gameObject);
                animator.SetBool("isRunning", false);
            }

            if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0.01f)
            {
                this.Right.ButtonDown(this.gameObject);
                animator.SetBool("isRunning", true);
            }
            else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0.01f)
            {
                this.Right.ButtonHold(this.gameObject);
            }
            else if (Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") > 0.01f)
            {
                this.Right.ButtonUp(this.gameObject);
                animator.SetBool("isRunning", false);
            }

            if (Input.GetButtonDown("Vertical"))
            {
                // Positive number means that it is going upwards, aka a jump.
                if (Input.GetAxis("Vertical") > 0.0f)
                {
                    this.Jump.ButtonDown(this.gameObject);
                }
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                this.Jump.ButtonDown(this.gameObject);
            }

        }

        // Randomizes right, left, jump controls - guarantees at least one key will be different
        void randomizeControls()
        {
            KeyCode temp;
            while (keyRight == KeyCode.D && keyLeft == KeyCode.A && keyJump == KeyCode.W)
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

}