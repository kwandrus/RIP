using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloatAnimation : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve AnimationCurve;

    private Vector3 Position;
    private float AnimationTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationTimer += Time.deltaTime;
        if(AnimationTimer > AnimationCurve.length)
        {
            AnimationTimer = 0.0f;
        }
        Vector3 newPosition = Position;
        newPosition += new Vector3(0, AnimationCurve.Evaluate(AnimationTimer / AnimationCurve.length), 0);
        gameObject.transform.position = newPosition;
    }
}
