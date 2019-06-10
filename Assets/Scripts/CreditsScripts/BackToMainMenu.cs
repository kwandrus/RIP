using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{

    [SerializeField]
    private float InputFreezeDuration;
    private float InputFreezeTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        InputFreezeTimer += Time.deltaTime;
        if(Input.anyKeyDown && InputFreezeTimer >= InputFreezeDuration)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
