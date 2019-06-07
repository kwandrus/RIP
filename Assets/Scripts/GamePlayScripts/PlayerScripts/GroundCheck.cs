using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private GameObject Player;

    void Start()
    {
        // Gets parent's gameObject
        this.Player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Walkable")
        {
            Player.GetComponent<ADSRManager>().SetGrounded(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Walkable")
        {
            Player.GetComponent<ADSRManager>().SetGrounded(false);
        }
    }
}
