using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private GameObject Player;
    private ADSRManager ADSR;
    private PlayerAudio playerAudio;
    private Rigidbody2D Body;

    void Start()
    {
        // Gets parent's gameObject
        this.Player = gameObject.transform.parent.gameObject;
        this.ADSR = this.Player.GetComponent<ADSRManager>();
        this.playerAudio = Player.GetComponent<PlayerAudio>();
        this.Body = this.Player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (this.Body.velocity.y == 0.0f)
        {
            Player.GetComponent<ADSRManager>().SetGrounded(true);
            playerAudio.JumpLand();

            // fixed bug where releasing horizontal movement during a jump would cause the player to keep sliding once landed
            if (ADSR.GetPhase() == ADSRManager.Phase.Sustain && !Input.GetButton("Horizontal"))
            {
                ADSR.SetPhase(ADSRManager.Phase.Release);
                ADSR.SetDirection(ADSRManager.Direction.None);
            }
        }
        else if (this.Body.velocity.y != 0.0f)
        {
            ADSR.SetGrounded(false);
        }
    }

    /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Walkable" || collision.transform.tag == "Wall")
        {
            Player.GetComponent<ADSRManager>().SetGrounded(true);
            playerAudio.JumpLand();

            // fixed bug where releasing horizontal movement during a jump would cause the player to keep sliding once landed
            if (ADSR.GetPhase() == ADSRManager.Phase.Sustain && !Input.GetButton("Horizontal"))
            {
                ADSR.SetPhase(ADSRManager.Phase.Release);
                ADSR.SetDirection(ADSRManager.Direction.None);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Walkable" || collision.transform.tag == "Wall")
        {
            Player.GetComponent<ADSRManager>().SetGrounded(false);
        }
    } */
}
