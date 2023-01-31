using System.Collections;
using System.Collections.Generic;
using Major.SpaceInvaders.Core;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public class EnemyController : MonoBehaviour, IHittable
    {
        public void Kill()
        {
            Destroy(gameObject);
        }

        public void Hit()
        {
            Kill();
        }   
    }
}
