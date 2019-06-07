using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

// Need to work on having the text "Typewrite" when the bubble shows up .. .
// not fully working
// Taken from https://www.youtube.com/watch?time_continue=201&v=1qbjmb_1hV4

public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currText;
    public GameObject textBub;
    private float lifetime; 


    // Start is called before the first frame update
    void Start()
    {
        lifetime = 2f; 
        StartCoroutine(ShowText());

    }


    private IEnumerator ShowText()
    {

            for (int i = 0; i < fullText.Length; i++)
            {
                currText = fullText.Substring(0, i+1);
                this.GetComponent<TMP_Text>().text = currText;

                if (i == fullText.Length - 1)
                {
                    textBub.SetActive(false);
                    this.GetComponent<TMP_Text>().text = "";
                }

            yield return new WaitForSeconds(delay);
                

            }
        
    }

}
