using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour
{
    private float cutSceneTime;
    public GameObject background;
    //private Color bgColor;
    private Color boopBeep;
    private Color boopBeep2;

    // Start is called before the first frame update
    void Start()
    {
        // how long the cutScene will last 
        cutSceneTime = 13.3f;
        boopBeep = new Color(background.GetComponent<SpriteRenderer>().color.r,
                                                                         background.GetComponent<SpriteRenderer>().color.g,
                                                                         background.GetComponent<SpriteRenderer>().color.b,
                                                                         1);
        boopBeep2 = new Color(background.GetComponent<SpriteRenderer>().color.r,
                                                                         background.GetComponent<SpriteRenderer>().color.g,
                                                                         background.GetComponent<SpriteRenderer>().color.b,
                                                                         0.5f);
        //bgColor = background.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        cutSceneTime -= Time.deltaTime;

        if (cutSceneTime <= 2f)
        {
            background.GetComponent<SpriteRenderer>().color = boopBeep;                                                                    
        }
        if (cutSceneTime <= 1.75f)
        {
            background.GetComponent<SpriteRenderer>().color = boopBeep2;
        }
        if (cutSceneTime <= 1.5f)
        {
            background.GetComponent<SpriteRenderer>().color = boopBeep;
        }
        if (cutSceneTime <= 1.25f)
        {
            background.GetComponent<SpriteRenderer>().color = boopBeep2;
        }
        if (cutSceneTime <= 1f)
        {
            background.GetComponent<SpriteRenderer>().color = boopBeep;
        }
        if (cutSceneTime <= .75f)
        {
            background.GetComponent<SpriteRenderer>().color = boopBeep2;
        }
        if (cutSceneTime <= 0.5f)
        {
            background.GetComponent<SpriteRenderer>().color = boopBeep;
        }
        if (cutSceneTime <= .25f)
        {
            background.GetComponent<SpriteRenderer>().color = boopBeep2;
        }
        if (cutSceneTime <= 0f || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GamePlay");
        }
    }
}
