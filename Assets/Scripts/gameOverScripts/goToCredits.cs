using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToCredits : MonoBehaviour
{
    private float lifetime; 
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
