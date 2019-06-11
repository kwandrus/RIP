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

        [SerializeField]
        private float TIME_ADD_CIG = 10.0f;

        [SerializeField] private Text pickUpText;
        private float pickUpLife = 2f;
        private bool pickUpBool = false;

        private float RightLevelBoundary;

        public delegate void DeathAbyss();
        public static event DeathAbyss OnDeathAbyss;
        public delegate void DeathEnemy();
        public static event DeathEnemy OnDeathEnemy;
        public delegate void PlayerReachedEndpoint();
        public static event PlayerReachedEndpoint OnPlayerReachedEndpoint;

        GamePlayController gamePlayController;
        PlayerAudio playerAudio;

        private void Start()
        {
            gamePlayController = GameObject.FindObjectOfType<GamePlayController>();
            playerAudio = gameObject.GetComponent<PlayerAudio>();
            //playerAudio = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerAudio>();
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
                playerAudio.DeathGrunt();
                OnDeathAbyss();
                Death();
            }

            if(gameObject.transform.position.x >= RightLevelBoundary)
            {
                OnPlayerReachedEndpoint();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Hostile")
            {
                if (!isDrunk)
                {
                    playerAudio.DeathGrunt();
                    OnDeathEnemy();
                    Death();
                }
            }
            //if (collision.transform.tag == "Wall")
            //{
            //    this.gameObject.transform.Translate(new Vector2(-0.1f, 0.0f));
            //}
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Cigarette")
            {
                PickUpCig();
                GetComponent<PlayerAudio>().PickUpItem();
                displayMessageCig();
                Destroy(collision.transform.gameObject);
            }
            if (collision.transform.tag == "Alcohol")
            {
                PickUpAlcohol();
                GetComponent<PlayerAudio>().PickUpItem();
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
            gamePlayController.AddTime(TIME_ADD_CIG);
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
