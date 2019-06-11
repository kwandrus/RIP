using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is so messy. 

public class EndingWalk : MonoBehaviour
{
    public GameObject textBub; // Player text
    public GameObject textBub2; // Enemy text

    Animator animator;

    private float BeginningWalk; // distance player walks
    private float SecondSpeechDelay; // time before second speech bubble

    private float SecondWalk;

    // Start is called before the first frame update
    void Start()
    {
        BeginningWalk = 2.4f;
        SecondSpeechDelay = 2.2f;
        SecondWalk = 12.5f;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BeginningWalk <= 0.0f)
        {
            animator.SetBool("isRunning", false);

            if (this.gameObject.tag == "player")
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

            if(textBub.activeSelf == false)
            {
                textBub.SetActive(true);
            }

            if(SecondSpeechDelay > 0.0f)
            {
                SecondSpeechDelay -= Time.deltaTime;
            }

            else
            {
                textBub2.SetActive(true);
            }


        }

        else
        {
            BeginningWalk -= Time.deltaTime;

            this.gameObject.transform.Translate(1, 0, 0);

            if (this.gameObject.tag == "player")
            {
                animator.SetBool("isRunning", true);
            }
        }

        if(SecondWalk > 0.0f)
        {
            SecondWalk -= Time.deltaTime;
        }
        else
        {
            if(this.gameObject.tag == "player")
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                animator.SetBool("isRunning", true);
                this.gameObject.transform.Translate(0.5f, 0, 0);
            }
        }


    }
}
