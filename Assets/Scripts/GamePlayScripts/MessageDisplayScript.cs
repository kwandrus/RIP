using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class MessageDisplayScript : MonoBehaviour
    {
        [SerializeField] private Text TextBox;
        private float DisplayMessageDuration = 2.0f;
        private float DisplayMessageTimer = 0.0f;
        private bool IsActive = false;

        private void Start()
        {
            TextBox.enabled = false;
        }

        private void Update()
        {
            if (IsActive)
            {
                DisplayMessageTimer += Time.deltaTime;
                if (DisplayMessageTimer >= DisplayMessageDuration)
                {
                    IsActive = false;
                    TextBox.enabled = false;
                    DisplayMessageTimer = 0.0f;
                }
            }
        }

        public void DisplayMessage(string messageText)
        {
            TextBox.enabled = true;
            TextBox.text = messageText;
            IsActive = true;
        }
    }
}
