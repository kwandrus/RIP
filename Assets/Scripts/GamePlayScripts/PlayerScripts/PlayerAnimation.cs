using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        spriteRenderer.flipX = true;
        animator.SetBool("isRunning", true);
    }

    public void MoveRight()
    {
        spriteRenderer.flipX = false;
        animator.SetBool("isRunning", true);
    }

    public void Idle()
    {
        animator.SetBool("isRunning", false);
    }

    public void Death()
    {
        animator.SetBool("isDead", true);
    }

}