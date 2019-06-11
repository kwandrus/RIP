using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource jumpUpSound;
    [SerializeField] private AudioSource jumpLandSound;
    [SerializeField] private AudioSource deathGruntSound;
    [SerializeField] private AudioSource pickUpItemSound;

    public void JumpUp()
    {
        jumpUpSound.Play();
    }

    public void JumpLand()
    {
        jumpLandSound.Play();
    }

    public void DeathGrunt()
    {
        deathGruntSound.Play();
    }

    public void PickUpItem()
    {
        pickUpItemSound.Play();
    }
}
