using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CommandPattern;

public class MenuButtonsController : MonoBehaviour
{
    [SerializeField]
    public GameObject PlayButton;
    [SerializeField]
    public GameObject OptionsButton;
    [SerializeField]
    public GameObject CreditsButton;
    [SerializeField]
    GameObject Camera;
    [SerializeField]
    Light SceneLight;
    enum State { Idle, Animation, Switch};
    private State CurrentState = State.Idle;
    private float AnimationTimer = 0.0f;
    private readonly float AnimationDuration = 0.5f;
    string SceneToLoad = "MainMenu";

    private void Update()
    {
        if(CurrentState == State.Animation)
        {
            AnimationTimer += Time.deltaTime;

            UpdateAnimation();

            if (AnimationTimer > AnimationDuration)
            {
                CurrentState = State.Switch;
            }
        }
        else if(CurrentState == State.Switch)
        {
            // Switch state in case we have to add code here later.
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    public void SwitchToCutScene()
    {
        CurrentState = State.Animation;
        DisableButtons();
        SceneToLoad = "CutScene";
    }
    
    public void SwitchToOptions()
    {
        CurrentState = State.Animation;
        DisableButtons();
        SceneToLoad = "Options";
    }

    public void SwitchToCredits()
    {
        //Debug.Log("Quitting game");
        CurrentState = State.Animation;
        SceneToLoad = "Credits";
        //Application.Quit();
    }

    private void UpdateAnimation()
    {
        float buttonMovementSpeed = 2000;
        float distanceToMove = Time.deltaTime * buttonMovementSpeed;
        Vector2 buttonMovementVectorLeft = new Vector2(-distanceToMove, 0);
        Vector2 buttonMovementVectorRight = new Vector2(distanceToMove, 0);

        PlayButton.transform.Translate(buttonMovementVectorLeft);
        OptionsButton.transform.Translate(buttonMovementVectorRight);
        CreditsButton.transform.Translate(buttonMovementVectorRight);
    }

    private void DisableButtons()
    {
        PlayButton.GetComponent<Button>().interactable = false;
        OptionsButton.GetComponent<Button>().interactable = false;
        CreditsButton.GetComponent<Button>().interactable = false;
    }
}
