using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public GameObject textBub;
    public GameObject textBub2;

    private float walkPlayer; // distance player walks

    private float walkEnemyTime;  // time it takes for player to come to scene
    private float walkEnemyDist;  // time it takes for player to come to scene


    private int count1; // makes bubble appear once for player (so it can disappear)
    private int count2; // makes bubble appear once for player (so it can disappear)

    // Start is called before the first frame update
    void Start()
    {
        walkPlayer = 1f;
        count1 = 0;
        count2 = 0;

        walkEnemyTime = 6f;
        walkEnemyDist = 1f; 
    }

    // Update is called once per frame
    void Update()
    {

        walkPlayer -= Time.deltaTime;

        if (this.gameObject.tag == "player")
        {
            // Gets player to 1/3 of the screen
            if (walkPlayer >= 0f)
            {
                this.gameObject.transform.Translate(1, 0, 0);
            }

            // After player stops, text bubble
            if (walkPlayer < 0f && count1 == 0)
            {
                textBub.SetActive(true);
                count1++;
            }
        }



        walkEnemyTime -= Time.deltaTime;

        if (this.gameObject.tag == "enemy")
        {
            if (walkEnemyTime <= 0f)
            {
                walkEnemyDist -= Time.deltaTime;

                if (walkEnemyDist >= 0f)
                    this.gameObject.transform.Translate(-1, 0, 0);

                if (walkEnemyDist < 0f && count2 == 0)
                {
                    textBub2.SetActive(true);
                    count2++;
                }
            }
        }

    }
}
