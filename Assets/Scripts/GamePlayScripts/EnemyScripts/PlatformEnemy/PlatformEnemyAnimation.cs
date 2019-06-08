using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemyAnimation : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator.SetBool("isRunning", true);
    }

    public void MoveLeft()
    {
        spriteRenderer.flipX = true;
    }

    public void MoveRight()
    {
        spriteRenderer.flipX = false;
    }
}
