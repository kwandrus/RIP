using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundSong;

    public void Start()
    {
        backgroundSong.Play();
    }
}
