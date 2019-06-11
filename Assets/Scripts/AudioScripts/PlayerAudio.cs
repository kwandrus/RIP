using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Player;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource jumpUpSound;
    [SerializeField] private AudioSource jumpLandSound;
    [SerializeField] private AudioSource deathGruntSound;
    [SerializeField] private AudioSource pickUpItemSound;

    private void OnEnable()
    {
        PlayerCollision.OnCollideWithCigarette += PickUpItem;
        PlayerCollision.OnCollideWithAlcohol += PickUpItem;
        PlayerCollision.OnCollideWithHostile += DeathGrunt;
        PlayerCollision.OnFallIntoAbyss += DeathGrunt;
    }

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

    public IEnumerator WaitForSound(GameObject player)
    {
        while (deathGruntSound.isPlaying)
        {
            yield return null;
        }

        // Don't let the player move while in death state.
        player.SetActive(false);
    }

    public void PickUpItem(Transform item)
    {
        pickUpItemSound.Play();
    }
}
