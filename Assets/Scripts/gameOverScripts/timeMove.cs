using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeMove : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private int count = 0;
    private float lifetime;
    private float lifetime2;

    private void Start()
    {
        lifetime = 4f;
        lifetime2 = 4f; 
    }

    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime >= 0f)
        {
            this.gameObject.transform.Translate(1, 0, 0);
            lifetime2 = 4f;
        }

        else
        {
            this.gameObject.transform.Translate(-1, 0, 0);
            lifetime2 -= Time.deltaTime;
            if (lifetime2 <= 0f)
            {
                lifetime = 4f;
            }

        }


    }
}
