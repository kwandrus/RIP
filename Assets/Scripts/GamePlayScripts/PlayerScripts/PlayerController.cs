using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player.Command
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float TimerDrunk = 2.0f;
        private bool isDrunk;

        [SerializeField] float TimerAddicted = 10.0f;
        private bool isAddicted;

        private void Start()
        {
            isDrunk = false;
            isAddicted = false;
        }

        private void Update()
        {
            Debug.Log(TimerDrunk);
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
            if(collision.transform.tag == "alcohol")
            {
                isDrunk = true;
            }

            else if (collision.transform.tag == "cigarette")
            {
                isAddicted = true;
            }
        }

    }

}