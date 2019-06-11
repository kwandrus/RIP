using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using GamePlay.Player;

namespace GamePlay
{
    public class GamePlayController : MonoBehaviour
    {

        // These states should not include normal triggers, but be used for continuous behavior like animation timers and animations.
        // Start: Any intial actions before gameplay happen.
        // Playing: Normal gameplay state.
        // Death: Any actions to occur right after death is intiated happen and before we transition to the checkpoint.
        // Checkpoint: Any behavior to happen after death state and as we are transitioning to the last checkpoint.
        // GameOver: Any post-loss behavior should happen here.
        enum State { Start, Playing, Death, Checkpoint, GameOver, Win }

        [SerializeField]
        Vector2 SpawnPoint;
        [SerializeField]
        float TotalTime;
        [SerializeField]
        Camera MainCamera;
        [SerializeField]
        private Camera SecondaryCamera;

        private float Score = 0.0f;
        private float totalTimeLeft;
        private int numDeaths = 0;
        private bool playerIsAddicted = false;

        private float timeModifier = 1.0f;

        // There is probably a much better way to implement state change.
        private State currentState = State.Start;
        private float startStateDuration = 5.0f;
        private float startStateTimer = 0.0f;
        private float deathStateDuration = 1.5f;
        private float deathStateTimer = 0.0f;
        private float checkpointStateDuration = 2.0f;
        private float checkpointStateTimer = 0.0f;
        private float gameOverStateDuration = 5.0f;
        private float gameOverStateTimer = 0.0f;
        private float winStateDuartion = 0.0f;
        private float winStateTimer = 0.0f;

        // UI
        public GameObject timer;
        public GameObject deathUI;
        public GameObject scoreUI;

        private GameObject player;
        private Vector2 currentCheckpoint;
        private Vector3 lastDeathCameraLocation;

        // Start is called before the first frame update
        void Start()
        {
            currentCheckpoint = SpawnPoint;
            totalTimeLeft = TotalTime;
            player = GameObject.FindGameObjectWithTag("Player");
            SecondaryCamera.enabled = false;
            Score = 1000;
        }

        // Update is called once per frame
        void Update()
        {
            if (currentState == State.Playing)
            {
                Score -= Time.deltaTime;
            }
            timer.GetComponent<TMP_Text>().text = totalTimeLeft.ToString("F2");
            deathUI.GetComponent<TMP_Text>().text = numDeaths.ToString();
            scoreUI.GetComponent<TMP_Text>().text = Score.ToString("F1");

            switch (currentState)
            {
                case State.Start:
                    currentState = State.Playing;
                    break;
                case State.Playing:
                    EnterPlayState();
                    totalTimeLeft -= Time.deltaTime * timeModifier;
                    if (totalTimeLeft <= 0f)
                    {
                        GameOverTime();
                    }
                    break;
                case State.Death:
                    UpdateDeathState();
                    break;
                case State.Checkpoint:
                    UpdateCheckpointState();
                    break;
                case State.GameOver:
                    break;
                case State.Win:
                    winStateTimer += Time.deltaTime;
                    if (winStateTimer >= winStateDuartion)
                    {
                        SceneManager.LoadScene("EndingCutscene");
                    }
                    break;
            }
        }

        private void OnEnable()
        {
            Player.PlayerController.OnDeathAbyss += DeathByAbyss;
            Player.PlayerController.OnDeathEnemy += DeathByEnemy;
            Player.PlayerController.OnPlayerReachedEndpoint += PlayerReachedEndpoint; 
        }

        public void AddTime(float time)
        {
            this.totalTimeLeft += time;
        }

        // Called once when player touches enemy.
        public void DeathByEnemy()
        {
            if (currentState == State.Playing)
            {
                // Where the dead body will be located.
                Vector3 deadBodyLocation = player.transform.position;
                // Spawn the dead body at the player's feet, this requires us to get the bottom side of the ground check box collider.
                deadBodyLocation.y = player.transform.Find("GroundCheck").position.y - player.GetComponentInChildren<BoxCollider2D>().size.y / 2;
                GameObject deadBody = (GameObject) GameObject.Instantiate(Resources.Load("Prefabs/DeadBody"), deadBodyLocation, Quaternion.identity);
                if (player.GetComponent<SpriteRenderer>().flipX == true)
                {
                    Vector3 deadBodyScale = deadBody.transform.localScale;
                    deadBodyScale.Scale(new Vector3(-1, 1, 1));
                    deadBody.transform.localScale = deadBodyScale;
                }
                Death();
            }
        }

        public void DeathByAbyss()
        {
            if (currentState == State.Playing)
            {
                Death();
                SecondaryCamera.GetComponent<ScreenShakeEffect>().Activate();
            }
        }

        // TODO: Add win sequence/scene.
        public void PlayerReachedEndpoint()
        {
            currentState = State.Win;
        }

        // Assumes that checkpoint's pivot lies at (0,0) of the sprite
        public void PlayerReachedCheckpoint(Vector2 checkpointLocation)
        {
            Vector2 newCheckpointLocation = new Vector2(checkpointLocation.x, checkpointLocation.y + (player.GetComponent<SpriteRenderer>().size.y / 2));
            currentCheckpoint = newCheckpointLocation;
            // We could potentially add an animation right here.
        }

        public void GameOverTime()
        {
            SceneManager.LoadScene("LoseTime");
        }

        public void GameOverAddiction()
        {
            SceneManager.LoadScene("LoseCigarettes");
        }

        public void GameOverAlcohol()
        {
            SceneManager.LoadScene("LoseAlcohol");
        }

        public void Addicted()
        {
            timeModifier = 0.50f;
        }

        // Called when we first enter the play state.
        private void EnterPlayState()
        {
            player.SetActive(true);
        }

        private void Death()
        {
            numDeaths++;
            Score -= 100;
            currentState = State.Death;

            // Don't let the player move while in death state.
            player.SetActive(false);
            // Record where the camera was at time of death so we can lerp from this position to the player.
            lastDeathCameraLocation = MainCamera.transform.position;
            MainCamera.enabled = false;
            SecondaryCamera.transform.position = lastDeathCameraLocation;
            SecondaryCamera.enabled = true;
            player.transform.position = currentCheckpoint;
        }

        // Continuously updated while in the State.Death state.
        private void UpdateDeathState()
        {
            deathStateTimer += Time.deltaTime;
            if (deathStateTimer < deathStateDuration)
            {

            }
            else
            {
                deathStateTimer = 0;
                currentState = State.Checkpoint;
            }
        }

        // Continuously updated while in the State.Checkpoint state.
        private void UpdateCheckpointState()
        {
            checkpointStateTimer += Time.deltaTime;
            if (checkpointStateTimer < checkpointStateDuration)
            {
                Vector3 newCameraPosition = Vector3.Lerp(lastDeathCameraLocation, MainCamera.transform.position, checkpointStateTimer / checkpointStateDuration);
                SecondaryCamera.transform.position = newCameraPosition;
            }
            else
            {
                checkpointStateTimer = 0;
                currentState = State.Playing;
                SecondaryCamera.enabled = false;
                MainCamera.enabled = true;
            }
        }
    }
}