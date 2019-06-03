using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScroll : MonoBehaviour
{
    [SerializeField] public float AutoScrollSpeed;
    private Camera ManagedCamera;

    private void Awake()
    {
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        var cameraPosition = this.ManagedCamera.transform.position;

        // end of background
        if (cameraPosition.x + AutoScrollSpeed >= 591) 
        {
            this.ManagedCamera.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z);
        }

        else
        {
            this.ManagedCamera.transform.position = new Vector3(cameraPosition.x + AutoScrollSpeed, cameraPosition.y, cameraPosition.z);
        }
    }
}


