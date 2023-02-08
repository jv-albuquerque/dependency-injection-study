using System.Collections;
using System.Collections.Generic;
using Major.SpaceInvaders.Core;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public class EnemyController : MonoBehaviour, IHittable
    {
        [SerializeField] private List<Sprite> _sprites;

        private SpriteRenderer _render;
        private int _animationIndex = 0;

        private ISwarmController _swarmController;

        public void Set(ISwarmController controller)
        {
            _swarmController = controller;
            _swarmController.OnMove += OnMove;

            _render = GetComponent<SpriteRenderer>();
            _render.sprite = _sprites[_animationIndex];
        }

        private void OnDestroy()
        {
            _swarmController.OnMove -= OnMove;
        }

        public void Kill()
        {
            _swarmController.OnEnemyDie(this);
            Destroy(gameObject);
        }

        public void Hit()
        {
            Kill();
        }

        private void OnMove()
        {
            _animationIndex++;
            _animationIndex = _animationIndex >= _sprites.Count ? 0 : _animationIndex;

            _render.sprite = _sprites[_animationIndex];
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Bound"))
            {
                _swarmController.OnHitLimits();
            }
        }
    }
}
