using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private int frameCount;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 myPos = this.transform.position;

        if (Mathf.Abs(playerPos.x - myPos.x) <= 400)
        {
            // once the Player is "in range" of the enemy object, the enemy
            // will start doing random actions
            int randomAction = Random.Range(0, 4);

            switch (randomAction)
            { 
                case 0:
                    anim.SetBool("burst", true);
                    break;
                case 1:
                    anim.SetBool("fireBeam", true);
                    break;
                case 2:
                    anim.SetBool("fireDouble", true);
                    break;
                case 3:
                    anim.SetBool("fireWave", true);
                    break;
            }
        }
    }
}
