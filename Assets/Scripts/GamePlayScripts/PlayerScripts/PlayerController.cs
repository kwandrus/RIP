using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float DrunkDuration;
        private float drunkTimer;
        private bool isDrunk = false;
        private float numAlcoholsCollected = 0;
        [SerializeField]
        private float AddictionIntervalDuration;
        private float addictionIntervalTimer;
        private bool isAddicted = false;
        private float numCigsCollected = 0;


        GamePlayController gamePlayController;
        PlayerAnimation playerAnimation;


        private void Start()
        {
            gamePlayController = GameObject.FindObjectOfType<GamePlayController>();
            playerAnimation = gameObject.GetComponent<PlayerAnimation>();
            drunkTimer = DrunkDuration;
            addictionIntervalTimer = AddictionIntervalDuration;
        }

        private void Update()
        {
            if(isDrunk)
            {
                drunkTimer += Time.deltaTime;
                if(drunkTimer >= DrunkDuration)
                {
                    isDrunk = false;
                }
            }

            if(isAddicted)
            {
                addictionIntervalTimer += Time.deltaTime;
                if(addictionIntervalTimer >= AddictionIntervalDuration)
                {
                    gamePlayController.GameOverAddiction();
                }
            }

            if(gameObject.transform.position.y < 0)
            {
                DeadByAbyss();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Hostile")
            {
                DeadByEnemy();
            }
            if (collision.transform.tag == "Cigarette")
            {
                PickUpCig();
                Destroy(collision.transform.gameObject);
            }
            if (collision.transform.tag == "Alcohol")
            {
                PickUpAlcohol();
                Destroy(collision.transform.gameObject);
            }
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

        private void PickUpCig()
        {
            if (this.numCigsCollected >= 2)
            {
                this.isAddicted = true;
            }
            this.numCigsCollected += 1;
        }

        private void PickUpAlcohol()
        {
            if (this.numAlcoholsCollected == 0)
            {
                this.isDrunk = true;
            }
            this.numAlcoholsCollected += 1;
        }

        private void NextLevel()
        {
            // Load next scene
        }

        private void GameWin()
        {
            SceneManager.LoadScene("GameOverWin");
        }


        private void DeadByAbyss()
        {
            gamePlayController.DeadByAbyss();
        }

        private void DeadByEnemy()
        {
            // Teleport back to last checkpoint.
            gamePlayController.DeadByEnemy();
        }
    }

}