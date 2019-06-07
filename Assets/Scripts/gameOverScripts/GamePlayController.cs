using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay
{

    public class GamePlayController : MonoBehaviour
    {
        [SerializeField]
        private float TimeLimit;

        float Score = 0.0f;
        float Time = 0.0f;
        int numDeaths = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Time > TimeLimit)
            {
                GameOverTime();
            }
        }

        public void DeadByEnemy()
        {
            numDeaths++;
            Score -= 100;
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
    }
}