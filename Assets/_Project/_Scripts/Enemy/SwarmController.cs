using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Major.SpaceInvaders.Enemy
{
    public class SwarmController : MonoBehaviour, ISwarmController
    {
        [SerializeField] private float _moveX = 0.3f;
        [SerializeField] private float _moveY = 0.25f;
        [SerializeField] private float _startMoveDelay = 1.0f;

        public event Action OnMove;

        private bool _goingLeft = true;
        private bool _goDown = false;

        private void Start()
        {
            AsyncMoveSwarm();
        }

        private async void AsyncMoveSwarm()
        {
            bool anyAlienAlive = true;

            while (anyAlienAlive)
            {
                await Task.Delay((int)(_startMoveDelay * 1000));

                if (this == null) return; //prevent calls after the games stops

                MoveSwarm();
            }
        }

        private void MoveSwarm()
        {
            var newPosition = transform.position;
            if (_goDown)
            {
                _goDown = false;
                newPosition.y -= _moveY;
            }
            else
            {
                newPosition.x += _moveX * (_goingLeft ? -1 : 1);
            }
            transform.position = newPosition;
            OnMove?.Invoke();
        }

        public void OnHitLimits()
        {
            if (_goDown) return;

            _goDown = true;
            _goingLeft = !_goingLeft;
        }
    }
}
