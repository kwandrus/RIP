using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCutSceneController : MonoBehaviour
{
    private float cutSceneTime;
    public GameObject background;

    private Color fadingColor;
    private float fadingFactor;

    // Start is called before the first frame update
    void Start()
    {
        cutSceneTime = 16.3f;
        fadingColor = new Color(background.GetComponent<SpriteRenderer>().color.r,
                                                                 background.GetComponent<SpriteRenderer>().color.g,
                                                                 background.GetComponent<SpriteRenderer>().color.b,
                                                                 1);
        fadingFactor = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cutSceneTime -= Time.deltaTime;

        if(cutSceneTime < 2.0f)
        {
            fadingFactor -= Time.deltaTime * 0.1f;
            fadingColor = new Color(background.GetComponent<SpriteRenderer>().color.r * fadingFactor,
                                                         background.GetComponent<SpriteRenderer>().color.g * fadingFactor,
                                                         background.GetComponent<SpriteRenderer>().color.b * fadingFactor,
                                                         1);
            background.GetComponent<SpriteRenderer>().color = fadingColor;
        }

        if (cutSceneTime <= 0f || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
