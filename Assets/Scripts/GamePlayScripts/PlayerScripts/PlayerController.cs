using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float TimerDrunk = 2.0f;
        private bool isDrunk;

        [SerializeField] float TimerAddicted = 10.0f;
        private bool isAddicted;

        GamePlayController gamePlayController;
        PlayerAnimation playerAnimation;

        private float CigCounter;
        private float AlcoholCounter;

        private void Start()
        {
            gamePlayController = GameObject.FindObjectOfType<GamePlayController>();
            playerAnimation = gameObject.GetComponent<PlayerAnimation>();

            isDrunk = false;
            isAddicted = false;
            CigCounter = 0.0f;
            AlcoholCounter = 0.0f;
        }

        private void Update()
        {
            //Debug.Log(TimerDrunk);
            if(isDrunk)
            {
                TimerDrunk -= Time.deltaTime;
            }

            if(TimerDrunk <= 0.0f)
            {
                SceneManager.LoadScene("LoseAlcohol");
            }

            if(isAddicted)
            {
                TimerAddicted -= Time.deltaTime;
            }

            if(TimerAddicted <= 0.0f)
            {
                SceneManager.LoadScene("LoseCigarettes");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Hostile")
            {
                // Touches enemy or gets hit by enemy projectile
                // Die();
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
            else if (collision.transform.tag == "enemy")
            {
                Debug.Log("Touched enemy");
                DeadByEnemy();
            }
        }

        private void PickUpCig()
        {
            if (this.CigCounter == 2)
            {
                this.isAddicted = true;
            }
            this.CigCounter += 1;
        }

        private void PickUpAlcohol()
        {
            if (this.AlcoholCounter == 0)
            {
                this.isDrunk = true;
            }
            this.AlcoholCounter += 1;
        }

        private void NextLevel()
        {
            // Load next scene
        }

        private void GameWin()
        {
            SceneManager.LoadScene("GameOverWin");
        }


        private void DeadByEnemy()
        {
            // Teleport back to last checkpoint.
            gamePlayController.DeadByEnemy();
        }
    }

}