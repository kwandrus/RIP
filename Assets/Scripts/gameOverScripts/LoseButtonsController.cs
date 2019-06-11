using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CommandPattern;

public class LoseButtonsController : MonoBehaviour
{
    [SerializeField]
    public GameObject RestartButton;
    [SerializeField]
    public GameObject CreditsButton;
    [SerializeField]
    GameObject Camera;
    [SerializeField]
    Light SceneLight;
    enum State { Idle, Animation, Switch };
    private State CurrentState = State.Idle;
    private float AnimationTimer = 0.0f;
    private readonly float AnimationDuration = 0.5f;
    string SceneToLoad = "";    // No Generic Lose Scene.

    private void Update()
    {
        if (CurrentState == State.Animation)
        {
            AnimationTimer += Time.deltaTime;

            UpdateAnimation();

            if (AnimationTimer > AnimationDuration)
            {
                CurrentState = State.Switch;
            }
        }
        else if (CurrentState == State.Switch)
        {
            // Switch state in case we have to add code here later.
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    public void SwitchToGamePlay()
    {
        CurrentState = State.Animation;
        DisableButtons();
        SceneToLoad = "GamePlay";
    }

    public void SwitchToCredits()
    {
        CurrentState = State.Animation;
        DisableButtons();
        SceneToLoad = "Credits";
    }

    private void UpdateAnimation()
    {
        float buttonMovementSpeed = 2000;
        float distanceToMove = Time.deltaTime * buttonMovementSpeed;
        Vector2 buttonMovementVectorLeft = new Vector2(-distanceToMove, 0);
        Vector2 buttonMovementVectorRight = new Vector2(distanceToMove, 0);

        RestartButton.transform.Translate(buttonMovementVectorLeft);
        CreditsButton.transform.Translate(buttonMovementVectorRight);
    }

    private void DisableButtons()
    {
        RestartButton.GetComponent<Button>().interactable = false;
        CreditsButton.GetComponent<Button>().interactable = false;
    }
}
