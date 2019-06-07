using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Command
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float TimerDrunk = 5.0f;
        private bool isDrunk;

        [SerializeField] float TimerAddicted = 10.0f;
        private bool isAddicted;

        private void Update()
        {
            if(isDrunk)
            {
                TimerDrunk -= Time.deltaTime;
            }

            if(isAddicted)
            {
                TimerAddicted -= Time.deltaTime;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.tag == "alcohol")
            {
                isDrunk = true;
                // startTimer
            }

            else if (collision.transform.tag == "cigarette")
            {
                isAddicted = true;
                // starttimer
            }
        }

    }

}