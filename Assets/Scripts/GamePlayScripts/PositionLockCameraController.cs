using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obscura
{
    public class PositionLockCameraController : MonoBehaviour
    {
        //[SerializeField] public Vector3 TopLeft;
        //[SerializeField] public Vector3 BottomRight;
        private Camera ManagedCamera;
        public GameObject Target;
        private float InitialCamPosx;
        private float InitialCamPosy;

        private void Awake()
        {
            this.ManagedCamera = this.gameObject.GetComponent<Camera>();
            InitialCamPosx = ManagedCamera.transform.position.x;
            InitialCamPosy = ManagedCamera.transform.position.y;

        }

        //Use the LateUpdate message to avoid setting the camera's position before
        //GameObject locations are finalized.
        void LateUpdate()
        {
   
            var targetPosition = this.Target.transform.position;
            var cameraPosition = this.ManagedCamera.transform.position;

            cameraPosition = new Vector3(targetPosition.x, InitialCamPosy, cameraPosition.z);

            this.ManagedCamera.transform.position = cameraPosition;

        }

    }
}
