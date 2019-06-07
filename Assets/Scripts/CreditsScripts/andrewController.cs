using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://answers.unity.com/questions/570573/how-do-i-slowly-translate-a-object-to-a-other-obje.html
public class andrewController : MonoBehaviour
{
    public GameObject camPos;
    public GameObject prev;
    private Vector3 target;

    public float speed;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(camPos.transform.position.x, camPos.transform.position.y, camPos.transform.position.z);
        //lifetime = 3f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (prev.transform.position == target && prev.activeSelf == false)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (transform.position == target)
            {
                lifetime -= Time.deltaTime;
            }

            if (lifetime <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
