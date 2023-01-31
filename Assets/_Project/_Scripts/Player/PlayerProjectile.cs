using System.Collections;
using System.Collections.Generic;
using Major.SpaceInvaders.Core;
using Major.SpaceInvaders.Enemy;
using Unity.VisualScripting;
using UnityEngine;

namespace Major.SpaceInvaders.Player
{
    public class PlayerProjectile : MonoBehaviour
    {
        public event System.Action OnDestroyed;

        [SerializeField] private float speed = 10f;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            rb.velocity = Vector2.up * speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Enemy"))
            {
                collision.GetComponent<IHittable>().Hit();
            }

            Release();
        }

        private void Release()
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
