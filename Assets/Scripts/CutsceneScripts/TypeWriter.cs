using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

// Makes the text act like a typewriter. 
// Taken from https://www.youtube.com/watch?time_continue=201&v=1qbjmb_1hV4

public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currText;
    public GameObject textBub;

    private float PostTextDelay;

    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(ShowText());
        PostTextDelay = fullText.Length / 8.6f;
    }

    private IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currText = fullText.Substring(0, i+1);
            this.GetComponent<TMP_Text>().text = currText;
            yield return new WaitForSeconds(delay);
        }

        // turns off text bubble and textx when sentence finishes
        if (PostTextDelay < 0.0f)
        {
            textBub.SetActive(false);
            this.GetComponent<TMP_Text>().text = "";
        }
    }

    private void Update()
    {
        if (PostTextDelay > 0.0f)
        {
            PostTextDelay -= Time.deltaTime;
        }
        else
        {
            textBub.SetActive(false);
            this.GetComponent<TMP_Text>().text = "";
        }
    }
}
