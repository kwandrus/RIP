using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointController : MonoBehaviour
{
    private bool CanCollide = true;
    private string MessageText = "Checkpoint reached!";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (CanCollide)
            {
                GetComponent<ParticleSystem>().Play();
                GetComponent<AudioSource>().Play();
                CanCollide = false;
                GameObject.FindObjectOfType<Canvas>().GetComponent<MessageDisplayScript>().DisplayMessage(MessageText);
            }
        }
    }
}
