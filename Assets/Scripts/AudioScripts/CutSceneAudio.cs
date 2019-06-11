using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAudio : MonoBehaviour
{
    [SerializeField] private AudioSource cutSceneSong;

    public void Start()
    {
        cutSceneSong.Play();
    }
}
