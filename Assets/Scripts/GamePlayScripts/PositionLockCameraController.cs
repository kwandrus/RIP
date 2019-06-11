using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Player
{
    public class PositionLockCameraController : MonoBehaviour
    {
        //[SerializeField] public Vector3 TopLeft;
        //[SerializeField] public Vector3 BottomRight;
        private Camera ManagedCamera;
        public GameObject Target;
        [SerializeField]
        private float TileSize;
        [SerializeField]
        private float LevelBlockHeight;

        private float CameraLowerBound;
        private float CameraLeftBound;
        private float CameraUpperBound;
        // We can only define this once we have an end.
        private float CameraRightBound;

        private float CameraHeight;
        private float CameraWidth;
        private ItemWobbleAnimation wobble;

        private void Awake()
        {
            this.ManagedCamera = this.gameObject.GetComponent<Camera>();
            CameraHeight = Camera.main.orthographicSize;
            CameraWidth = CameraHeight * Screen.width / Screen.height;
            CameraLowerBound = CameraHeight;
            CameraLeftBound = CameraWidth;
            CameraUpperBound = (TileSize * LevelBlockHeight) - CameraHeight;
        }

        private void Start()
        {
            wobble = this.GetComponent<ItemWobbleAnimation>();
        }
        //Use the LateUpdate message to avoid setting the camera's position before
        //GameObject locations are finalized.
        void LateUpdate()
        {

            var targetPosition = this.Target.transform.position;
            var cameraPosition = this.ManagedCamera.transform.position;
            var cameraRotation = this.ManagedCamera.transform.rotation;

            cameraPosition = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);

            if (cameraPosition.y < CameraLowerBound)
            {
                cameraPosition.y = CameraLowerBound;
            }
            if (cameraPosition.x < CameraLeftBound)
            {
                cameraPosition.x = CameraLeftBound;
            }
            if(cameraPosition.y > CameraUpperBound)
            {
                cameraPosition.y = CameraUpperBound;
            }

            if (Target.GetComponent<PlayerController>().getDrunkState())
            {
                wobble.enabled = true;
            }
            else
            {
                wobble.enabled = false;
                cameraRotation.z = 0;
            }

            this.ManagedCamera.transform.position = cameraPosition;
            this.ManagedCamera.transform.rotation = cameraRotation;
        }

    }
}
