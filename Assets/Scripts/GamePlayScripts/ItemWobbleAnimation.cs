using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWobbleAnimation : MonoBehaviour
{
    [SerializeField]
    public AnimationCurve AnimationCurve;

    private Vector3 Rotation;
    private float AnimationTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Rotation = gameObject.transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationTimer += Time.deltaTime;
        if (AnimationTimer > AnimationCurve.length)
        {
            AnimationTimer = 0.0f;
        }
        Vector3 newRotation = new Vector3(Rotation.x, Rotation.y, Rotation.z + AnimationCurve.Evaluate(AnimationTimer / AnimationCurve.length));
        gameObject.transform.eulerAngles = newRotation;
        
    }
}
