using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Major.SpaceInvaders.Player
{
    public class ShipShooter : MonoBehaviour
    {
        [SerializeField] private PlayerProjectile projectilePrefab;
        [SerializeField] private float shootOffset = 1.0f;

        private bool canShoot = true;

        public void Shoot()
        {
            if(!canShoot)
            {
                return;
            }

            canShoot = false;

            var newProjectile = Instantiate(projectilePrefab);

            newProjectile.transform.position = new Vector2(transform.position.x, transform.position.y + shootOffset);
            newProjectile.OnDestroyed += ReleaseShoot;
        }

        private void ReleaseShoot()
        {
            canShoot = true;
        }
    }
}
