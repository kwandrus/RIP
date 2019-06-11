using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GamePlay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float DrunkDuration;
        [SerializeField]
        private int NumToAlcoholPoisoning;
        private float drunkTimer;
        private bool isDrunk = false;
        private int numAlcoholsCollected = 0;
        [SerializeField]
        private float AddictionIntervalDuration;
        [SerializeField]
        private int NumToGetAddicted;
        private float AddictionIntervalTimer;
        private bool IsAddicted = false;
        private int NumCigsCollected = 0;

        [SerializeField] private Text pickUpText;
        private float pickUpLife = 2f;
        private bool pickUpBool = false;

        private float RightLevelBoundary;

        GamePlayController gamePlayController;
        PlayerAnimation playerAnimation;

        private void Start()
        {
            gamePlayController = GameObject.FindObjectOfType<GamePlayController>();
            playerAnimation = gameObject.GetComponent<PlayerAnimation>();
            drunkTimer = 0;
            AddictionIntervalTimer = 0;
            RightLevelBoundary = GameObject.FindGameObjectWithTag("Endpoint").transform.position.x;
        }

        private void LateUpdate()
        {
            if (pickUpBool)
            {
                pickUpLife -= Time.deltaTime;

                if (pickUpLife <= 0f)
                {
                    pickUpText.text = "";
                    pickUpLife = 2f;
                    pickUpBool = false; 
                }


            }
            if (isDrunk)
            {
                this.drunkTimer += Time.deltaTime;
                if (drunkTimer >= DrunkDuration)
                {
                    this.isDrunk = false;
                    gameObject.GetComponent<Command.PlayerInput>().resetControls();
                    this.drunkTimer = 0.0f;
                }

            }

            if (IsAddicted)
            {
                AddictionIntervalTimer += Time.deltaTime;
                if (AddictionIntervalTimer >= AddictionIntervalDuration)
                {
                    gamePlayController.GameOverAddiction();
                }
            }

            if (gameObject.transform.position.y < 0.0f)
            {
                DeadByAbyss();
            }

            if(gameObject.transform.position.x >= RightLevelBoundary)
            {
                gamePlayController.PlayerReachedEndPoint();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Hostile")
            {
                DeadByEnemy();
            }
            //if (collision.transform.tag == "Wall")
            //{
            //    this.gameObject.transform.Translate(new Vector2(-0.1f, 0.0f));
            //}
            if (collision.transform.tag == "Next")
            {
                // Touches next level marker
                // Next Level();
            }
            if (collision.transform.tag == "End")
            {
                // Touches end game marker
                // GameWin();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Cigarette")
            {
                PickUpCig();
                displayMessageCig();
                Destroy(collision.transform.gameObject);
            }
            if (collision.transform.tag == "Alcohol")
            {
                PickUpAlcohol();
                displayMessageAlc();
                Destroy(collision.transform.gameObject);
            }
            if(collision.transform.tag == "Checkpoint")
            {
                gamePlayController.PlayerReachedCheckpoint(collision.transform.position);
            }
        }

        private void PickUpCig()
        {
            pickUpBool = true;
            this.NumCigsCollected += 1;
            AddictionIntervalTimer = 0.0f;
            if (this.NumCigsCollected >= NumToGetAddicted && !IsAddicted)
            {
                gamePlayController.Addicted();
                IsAddicted = true;
            }
        }

        private void PickUpAlcohol()
        {
            pickUpBool = true;
            this.isDrunk = true;
            this.numAlcoholsCollected += 1;
            this.drunkTimer = 0.0f;
            if (this.numAlcoholsCollected >= NumToAlcoholPoisoning)
            {
                gamePlayController.GameOverAlcohol();
            }
            gameObject.GetComponent<Command.PlayerInput>().randomizeControls();
        }


        private void DeadByAbyss()
        {
            gamePlayController.DeadByAbyss();
            Death();
        }

        private void DeadByEnemy()
        {
            // Teleport back to last checkpoint.
            gamePlayController.DeadByEnemy();
            Death();
        }

        private void Death()
        {
            drunkTimer = 0.0f;
            AddictionIntervalTimer = 0.0f;
            gameObject.GetComponent<Command.PlayerInput>().resetControls();
        }

        private void displayMessageCig()
        {
            pickUpText.text = "+1 Cigarette";
        }
        private void displayMessageAlc()
        {
            pickUpText.text = "+1 Booze";
        }

        public bool getDrunkState()
        {
            return isDrunk;
        }
    }

}