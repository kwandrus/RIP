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

    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {

            for (int i = 0; i < fullText.Length; i++)
            {
                currText = fullText.Substring(0, i+1);
                this.GetComponent<TMP_Text>().text = currText;
                
                // turns off text bubble and textx when sentence finishes
                if (i == fullText.Length - 1)
                {
                    textBub.SetActive(false);
                    this.GetComponent<TMP_Text>().text = "";
                }

            yield return new WaitForSeconds(delay);
            }
    }
}
