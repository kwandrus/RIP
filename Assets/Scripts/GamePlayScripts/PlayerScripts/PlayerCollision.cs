using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GamePlay.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        // Publishers.
        public delegate void CollideWithCigarette(Transform cigarette);
        public static event CollideWithCigarette OnCollideWithCigarette;
        public delegate void CollideWithAlcohol(Transform alcohol);
        public static event CollideWithAlcohol OnCollideWithAlcohol;
        public delegate void CollideWithCheckpoint(Vector2 position);
        public static event CollideWithCheckpoint OnCollideWithCheckpoint;
        public delegate void CollideWithHostile();
        public static event CollideWithHostile OnCollideWithHostile;
        public delegate void FallIntoAbyss();
        public static event FallIntoAbyss OnFallIntoAbyss;

        private void Update()
        {
            if (gameObject.transform.position.y < 0.0f)
            {
                OnFallIntoAbyss();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Cigarette")
            {
                OnCollideWithCigarette(collision.transform);
            }
            if (collision.transform.tag == "Alcohol")
            {
                OnCollideWithAlcohol(collision.transform);
            }
            if (collision.transform.tag == "Checkpoint")
            {
                OnCollideWithCheckpoint(collision.transform.position);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Hostile")
            {
                OnCollideWithHostile();
            }
        }
    }
}