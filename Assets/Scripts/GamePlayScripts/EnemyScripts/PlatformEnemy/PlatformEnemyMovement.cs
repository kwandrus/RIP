using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemyMovement : MonoBehaviour
{
    [SerializeField]
    float Speed;
    // Make not serialized later.
    [SerializeField]
    float limitOffset;
    private float leftLimit;
    private float rightLimit;
    private Transform Tile;
    private bool IsIdle = false;
    private bool IsMovingRight = true;

    private PlatformEnemyAnimation platformEnemyyAnimation;

    // Start is called before the first frame update
    void Start()
    {
        platformEnemyyAnimation = gameObject.GetComponent<PlatformEnemyAnimation>();
        Tile = gameObject.transform.parent.GetChild(1);
        BoxCollider2D tileCollider = Tile.GetComponent<BoxCollider2D>();
        leftLimit = Tile.transform.localPosition.x  + limitOffset;
        rightLimit = Tile.transform.localPosition.x + tileCollider.size.x - limitOffset;
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

    private void MoveRight()
    {
        // If enemy has reached the left side of the tile, start moving left.
        if (gameObject.transform.localPosition.x > rightLimit)
        {
            IsMovingRight = false;
        }
        else
        {
            gameObject.transform.Translate(new Vector2(Speed * Time.deltaTime, 0));
        }
    }

    private void MoveLeft()
    {
        // If enemy has reached the right side of the tile, start moving left.
        if(gameObject.transform.localPosition.x < leftLimit)
        {
            IsMovingRight = true;
        }
        else
        {
            gameObject.transform.Translate(new Vector2(-Speed * Time.deltaTime, 0));
        }
    }
}
