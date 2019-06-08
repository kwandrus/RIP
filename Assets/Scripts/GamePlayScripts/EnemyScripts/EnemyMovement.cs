using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float Speed;
    private bool IsIdle = false;
    private bool IsMovingRight = true;


    private EnemyAnimation platformEnemyyAnimation;

    // Start is called before the first frame update
    void Start()
    {
        platformEnemyyAnimation = gameObject.GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsIdle)
        {

        }
        else if (IsMovingRight)
        {
            MoveRight();
            platformEnemyyAnimation.MoveRight();
        }
        else
        {
            MoveLeft();
            platformEnemyyAnimation.MoveLeft();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Wall" || collision.transform.tag == "EnemyBoundary")
        {
            if (IsMovingRight)
            {
                IsMovingRight = false;
            }
            else
            {
                IsMovingRight = true;
            }
        }
    }

    private void MoveRight()
    {
        gameObject.transform.Translate(new Vector2(Speed * Time.deltaTime, 0));
    }

    private void MoveLeft()
    {
            gameObject.transform.Translate(new Vector2(-Speed * Time.deltaTime, 0));
    }
}
