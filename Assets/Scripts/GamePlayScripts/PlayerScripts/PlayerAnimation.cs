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

    private void FixedUpdate()
    {
        if (rigidBody2D.velocity.x < 1 && rigidBody2D.velocity.x > -1)
        {
            animator.SetBool("Running", false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveLeft()
    {
        spriteRenderer.flipX = true;
        animator.SetBool("Running", true);
    }

    public void MoveRight()
    {
        spriteRenderer.flipX = false;
        animator.SetBool("Running", true);
    }

    public void Shoot()
    {

    }

    public void Jump()
    {

    }

}
