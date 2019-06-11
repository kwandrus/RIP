using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudio : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundSong;

    public void Start()
    {
        backgroundSong.Play();
    }
}
