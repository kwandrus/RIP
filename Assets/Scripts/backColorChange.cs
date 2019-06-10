using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backColorChange : MonoBehaviour
{
    // [SerializeField] public GameObject background;
    private float lifetime;

    private void Start()
    {
        lifetime = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime < 0f)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            lifetime = 1f; 
        }
    }
}
