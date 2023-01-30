using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Player
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private float _acceleretion = 10.0f;
        [SerializeField] private float _maxSpeed = 1.0f;

        private Vector2 _moveDirection = Vector2.zero;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            AddVelocity();
        }

        private void AddVelocity()
        {
            var currentSpeed = _acceleretion * _maxSpeed * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -_maxSpeed, _maxSpeed);
            rb.velocity = _moveDirection * currentSpeed;
        }

        public void SetMoveDirection(Vector2 dir)
        {
            _moveDirection = dir;
        }
    }
}
