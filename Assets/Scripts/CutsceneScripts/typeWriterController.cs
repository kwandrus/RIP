using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Turns on the typewriter(text) when the textbubble appears 

public class typeWriterController : MonoBehaviour
{
    // Start is called before the first frame update
    private TypeWriter writer;

    public GameObject textBubble;


    void Start()
    {
        writer = GetComponent<TypeWriter>();
        writer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (textBubble.activeSelf == true)
        {
            writer.enabled = true;
        }

    }
}
