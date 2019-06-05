using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alcoholRain : MonoBehaviour
{
    public GameObject alc1;
    public GameObject alc2;
    public GameObject alc3;
    private int RandNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandNum = Random.Range(1, 45);

        // Positions of where alcohol is spawned is hard coded to match canvas
        if (RandNum == 1)
        {
            var drop = (GameObject)Instantiate(alc1, new Vector3(Random.Range(-200, 200) + transform.position.x, 315, -1),
                                    Quaternion.identity);
            Destroy(drop, 10);
        }

        if (RandNum == 2)
        {
            var drop = (GameObject)Instantiate(alc2, new Vector3(Random.Range(-200, 200) + transform.position.x, 315, -1),
                                    Quaternion.identity);
            Destroy(drop, 10);
        }

        if (RandNum == 3)
        {
            var drop = (GameObject)Instantiate(alc3, new Vector3(Random.Range(-200, 200) + transform.position.x, 315, -1),
                                    Quaternion.identity);
            Destroy(drop, 10);
        }

    }
}
