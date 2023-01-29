using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Major.SpaceInvaders.Player
{
    public class PlayerController : MonoBehaviour
    {
        private ShipMovement _movement;
        private ShipShooter _shooter;

        private void Awake()
        {
            _movement = GetComponent<ShipMovement>();
            _shooter = GetComponent<ShipShooter>();
        }

        private void OnMove(InputValue value)
        {
            _movement.SetMoveDirection(value.Get<Vector2>());
        }

        private void OnFire(InputValue value)
        {
            _shooter.Shoot();
        }
    }
}
