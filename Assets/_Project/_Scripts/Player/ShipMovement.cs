using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Player
{
    public class ShipMovement : MonoBehaviour
    {
        private Vector2 _moveDirection = Vector2.zero;

        private void Update()
        {

        }

        public void SetMoveDirection(Vector2 dir)
        {
            _moveDirection = dir;
        }
    }
}
