using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public GameObject textBub;
    private float walkPlayer;
    private float walkEnemy;


    // Start is called before the first frame update
    void Start()
    {
        walkPlayer = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        walkPlayer -= Time.deltaTime;

        // Gets player to 1/3 of the screen
        if (walkPlayer >= 0f) 
        {
            this.gameObject.transform.Translate(1, 0, 0); 
        }

        // After player stops, text bubble
        if (walkPlayer < 0f)
        {
            textBub.SetActive(true);
        }



    }
}
