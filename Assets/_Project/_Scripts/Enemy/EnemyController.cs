using System.Collections;
using System.Collections.Generic;
using Major.SpaceInvaders.Core;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public class EnemyController : MonoBehaviour, IHittable
    {
        private ISwarmController _swarmController;

        public void SetController(ISwarmController controller)
        {
            _swarmController = controller;
        }

        public void Kill()
        {
            Destroy(gameObject);
        }

        public void Hit()
        {
            Kill();
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
