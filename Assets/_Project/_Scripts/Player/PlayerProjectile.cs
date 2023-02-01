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

        [SerializeField] private float _speed = 10f;
        [SerializeField] private LayerMask _layersToHit;

        private Vector2 _direction = Vector2.up;

        private float _moveDistance;

        private void FixedUpdate()
        {
            _moveDistance = _speed * Time.fixedDeltaTime;

            if (!VerifyCollition())
            {
                Move();
            }
        }

        private bool VerifyCollition()
        {
            var hits = Physics2D.RaycastAll(transform.position, _direction, _moveDistance, _layersToHit);

            if(hits.Length > 0)
            {
                hits[0].collider.GetComponent<IHittable>()?.Hit();
                transform.position = hits[0].transform.position;
                Release();
                return true;
            }

            return false;
        }

        private void Move()
        {
            transform.position += (Vector3)(_moveDistance * _direction);
        }

        private void Release()
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
