using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Based off of the class example from Dr. Jam himself.
public class ADSRManager : MonoBehaviour
{
    [SerializeField] private float Speed = 5.0f;

    [SerializeField] private float AttackDuration = 0.5f;
    [SerializeField] private AnimationCurve Attack;

    [SerializeField] private float DecayDuration = 0.25f;
    [SerializeField] private AnimationCurve Decay;

    [SerializeField] private float SustainDuration = 1.0f;
    [SerializeField] private AnimationCurve Sustain;

    [SerializeField] private float ReleaseDuration = 0.25f;
    [SerializeField] private AnimationCurve Release;
    [SerializeField] private float JUMP_FACTOR = 2.0f;
    [SerializeField] private float MoveTimer = 2.0f;

    private float AttackTimer;
    private float DecayTimer;
    private float SustainTimer;
    private float ReleaseTimer;
    private float ElapsedTime;

    private float InputDirection = 0.0f;

    public enum Phase { Attack, Decay, Sustain, Release, None };

    public enum Direction { Horizontal, None };

    private Phase CurrentPhase;

    // Tells whether player is moving horizontally or not.
    private Direction Movement;

    // Whether or not player is touching the ground.
    [SerializeField] private bool Grounded = false;

    void Start()
    {
        this.CurrentPhase = Phase.None;
        this.Movement = Direction.None;
    }


    void Update()
    {
        // If player is not standing still, move x position.
        if (this.CurrentPhase != Phase.None)
        {
            var position = this.gameObject.transform.position;
            position.x += this.InputDirection * this.Speed * this.ADSREnvelope() * Time.deltaTime;
            this.gameObject.transform.position = position;
        }
    }

    // Getters and Setters.
    public Direction GetDirection()
    {
        return this.Movement;
    }

    public void SetDirection(Direction direction)
    {
        this.Movement = direction;
    }

    public void SetPhase(Phase phase)
    {
        this.CurrentPhase = phase;
    }

    public float getInputDirection()
    {
        return InputDirection;
    }

    public Phase GetPhase()
    {
        return CurrentPhase;
    }

    public void SetInputDirection(float direction)
    {
        this.ElapsedTime += direction;
        if ((ElapsedTime / MoveTimer) >= 1.0f)
        {
            this.InputDirection = 1.0f;
        }
        else if ((ElapsedTime / MoveTimer) <= -1.0f)
        {
            this.InputDirection = -1.0f;
        }
        else
        {
            this.InputDirection = ElapsedTime / MoveTimer;
        }
    }

    public void SetGrounded(bool logic)
    {
        this.Grounded = logic;
    }

    public bool GetGrounded()
    {
        return this.Grounded;
    }

    public float GetJump()
    {
        return this.JUMP_FACTOR;
    }

    public void SetPhaseNone()
    {
        this.Movement = Direction.None;
    }

    // Calculation of ADSR Envelope
    float ADSREnvelope()
    {
        float velocity = 0.0f;

        if (Phase.Attack == this.CurrentPhase)
        {
            velocity = this.Attack.Evaluate(this.AttackTimer / this.AttackDuration);
            this.AttackTimer += Time.deltaTime;
            if (this.AttackTimer > this.AttackDuration)
            {
                this.CurrentPhase = Phase.Decay;
            }
        }
        else if (Phase.Decay == this.CurrentPhase)
        {
            if (this.DecayDuration == 0.0f)
            {
                velocity = 0.0f;
            }
            else
            {
                velocity = this.Decay.Evaluate(this.DecayTimer / this.DecayDuration);
            }
            this.DecayTimer += Time.deltaTime;
            if (this.DecayTimer > this.DecayDuration)
            {
                this.CurrentPhase = Phase.Sustain;
            }
        }
        else if (Phase.Sustain == this.CurrentPhase)
        {
            velocity = this.Sustain.Evaluate(this.SustainTimer / this.SustainDuration);
            this.SustainTimer += Time.deltaTime;

            // Transition to release only if there is no direction pressed.
            if (Direction.None == this.Movement)
            {
                this.CurrentPhase = Phase.Release;
            }
        }
        else if (Phase.Release == this.CurrentPhase)
        {
            velocity = this.Release.Evaluate(this.ReleaseTimer / this.ReleaseDuration);
            this.ReleaseTimer += Time.deltaTime;
            if (this.ReleaseTimer > this.ReleaseDuration && Grounded)
            {
                this.CurrentPhase = Phase.None;
            }
        }
        return velocity;
    }

    public void ResetTimers()
    {
        this.AttackTimer = 0.0f;
        this.DecayTimer = 0.0f;
        this.SustainTimer = 0.0f;
        this.ReleaseTimer = 0.0f;
        this.ElapsedTime = 0.0f;
    }
}
