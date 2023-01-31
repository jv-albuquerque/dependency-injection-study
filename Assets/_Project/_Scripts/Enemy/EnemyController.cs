using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}
