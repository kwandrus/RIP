using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GamePlayController : MonoBehaviour
{

    float Score = 0.0f;
    public float totalTime;
    int numDeaths = 0;

    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        timer.GetComponent<TMP_Text>().text = totalTime.ToString("F2");

        if (totalTime <= 0f)
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