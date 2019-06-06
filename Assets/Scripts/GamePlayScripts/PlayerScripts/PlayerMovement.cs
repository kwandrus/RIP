using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float MaxSpeed;
    [SerializeField]
    float JumpForce;

    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }


    public void MoveLeft()
    {
        Vector2 movement = new Vector2(-MaxSpeed, rigidBody2D.velocity.y);
        rigidBody2D.GetComponent<Rigidbody2D>().velocity = movement;
    }

    public void MoveRight()
    {
        Vector2 movement = new Vector2(MaxSpeed, rigidBody2D.velocity.y);
        rigidBody2D.GetComponent<Rigidbody2D>().velocity = movement;
    }

    public void Jump()
    {
        Vector2 movement = new Vector2(0, JumpForce);
        gameObject.GetComponent<Rigidbody2D>().AddForce(movement, ForceMode2D.Impulse);
    }

}