using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour, ISelectHandler
{
    public string loadLevel; 

    public void OnSelect(BaseEventData eventData)
    {
        SceneManager.LoadScene(loadLevel);
    }
}
